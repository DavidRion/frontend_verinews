using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Npgsql;
using verinews_v16.Models;
using System.Web.Script.Serialization;
using System.IO;

namespace verinews_v16.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres; " + "Password=verinews;Database=SQLverinews;");
            //ouverture connexion
            conn.Open();

            // liste des tweets
            TweetRowset TwtRowset = new TweetRowset("SELECT tweet.tweet_id, tweet.tweet_text, tweet.sentiment, tweet.tweet_date, tweet.tweet_type FROM tweet", conn);
            List<Tweet> listTweet = TwtRowset.getTweetRowset();           

            //HighCharts
                //Pie Chart Tweets + requetes count 
                TweetCountPieChart twtCountPieChart = new TweetCountPieChart(listTweet);
                //line chart (tableaux dates et compteurs pour tweets +, -, =)
                TweetCountLineChart twtCountLineChart = new TweetCountLineChart(listTweet);

            //fermeture connexion à la BDD
            conn.Close();

            //passage des données à la vue
                //liste de tous les tweets
                ViewData["listTweet"] = listTweet;
                //passage des table pour linecharts à la vue
                ViewData["tablePositive"] = twtCountLineChart.getTablePositive();
                ViewData["tableNeutral"]  = twtCountLineChart.getTableNeutral();
                ViewData["tableNegative"] = twtCountLineChart.getTableNegative();
                ViewData["tableAll"] = twtCountLineChart.getTableAll();
                //passage pourcentages tweets piechart a la vue
                ViewData["totalTweet"] = 100; // twtCountPieChart.getPercentageTotalTweet(); ;
                ViewData["percentPositiveTweet"] = twtCountPieChart.getPercentagePositiveTweet();
                ViewData["percentNegativeTweet"] = twtCountPieChart.getPercentageNegativeTweet();
                ViewData["percentNeutralTweet"] = twtCountPieChart.getPercentageNeutralTweet();

                //passage objet tweetcountpie chart a la vue *****************************************************************************************
                //serialization
                var jsonSerialiser2 = new JavaScriptSerializer();
                var json2 = jsonSerialiser2.Serialize(twtCountPieChart);
                //write string to file
                System.IO.File.WriteAllText(@"C:\Users\David\Desktop\path2.txt", json2);
                //passage donnees a la vue
                ViewData["jsonTwtPieChart"] = json2;     

                //passage objet tweetcountline chart a la vue *****************************************************************************************
                    //classe la liste par date
                    twtCountLineChart.getTableAll().Sort((x, y) => DateTime.Compare(x.getTweetCountDateDate(), y.getTweetCountDateDate()));
                    //serialization
                    var jsonSerialiser = new JavaScriptSerializer();
                    var json = jsonSerialiser.Serialize(twtCountLineChart.getTableAll()); 
                    //write string to file
                    System.IO.File.WriteAllText(@"C:\Users\David\Desktop\path.txt", json);
                    //passage donnees a la vue
                    ViewData["jsonTableLineChart"] = json; 
    
                //passage donnees linechart google a la vue
                ViewData["linechartTable"] = twtCountLineChart.getTableAll();
                ViewData["lengthLinechartTable"] = twtCountLineChart.getTableAll().Count;

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        //CODE LINE CHART, PIE CHART
        public String ajaxPie(String criteria1, String criteria2)
        {

            String criteria = null;

            // Connect to a PostgreSQL database
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=postgres; " + "Password=verinews;Database=SQLverinews;");
            //ouverture connexion
            conn.Open();

            if (!String.IsNullOrEmpty(criteria1))
            {
                criteria = " WHERE tweet.tweet_type LIKE '%" + criteria1 + "%'";
            }

            if (!String.IsNullOrEmpty(criteria2))
            {
                criteria = criteria + " OR tweet.tweet_type LIKE '%" + criteria2 + "%'";
            }

            //liste des tweets
            //TweetRowset TwtRowset = new TweetRowset("SELECT tweet.tweet_id, tweet.tweet_text, tweet.sentiment, tweet.tweet_date, tweet.tweet_type FROM tweet WHERE tweet.tweet_type LIKE '%"+criteria1+
            //    "%' OR tweet.tweet_type LIKE '%"+criteria2+"%'", conn);

            TweetRowset TwtRowset = new TweetRowset("SELECT tweet.tweet_id, tweet.tweet_text, tweet.sentiment, tweet.tweet_date, tweet.tweet_type FROM tweet " + criteria, conn);

            List<Tweet> listTweet = TwtRowset.getTweetRowset();

            // LINE CHART *************************************************************************************************************
            TweetCountLineChart twtCountLineChart = new TweetCountLineChart(listTweet);
            //classe la liste par date
            twtCountLineChart.getTableAll().Sort((x, y) => DateTime.Compare(x.getTweetCountDateDate(), y.getTweetCountDateDate()));
            //serialization
            var jsonSerialiser = new JavaScriptSerializer();
            var json = jsonSerialiser.Serialize(twtCountLineChart.getTableAll()); 

            // PIE CHART **************************************************************************************************************
            TweetCountPieChart twtCountPieChart = new TweetCountPieChart(listTweet);
            var jsonSerialiser2 = new JavaScriptSerializer();
            var json2 = jsonSerialiser2.Serialize(twtCountPieChart);

            String res = json+"<JSONSEPARATOR>"+json2;
            

            return res;

        }

    }
}