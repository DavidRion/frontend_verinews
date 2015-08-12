using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace verinews_v16.Models
{
    public class TweetCountPieChart
    {
        //declaration des ressources
            //chiffres
            public int nbTotalTweet;
            public int nbPositiveTweet;
            public int nbNegativeTweet;
            public int nbNeutralTweet;
            //pourcentage
            public float percentagePositiveTweet;
            public float percentageNegativeTweet;
            public float percentageNeutralTweet;
            public float percentageTotalTweet;
        
        //copy constructor
        public TweetCountPieChart(List<Tweet> listTweet)
        {
                       
            //recuperation resultat requete (si conditions les ajouter)
            /* Int64 nbTotalTwt    = requestSqlCount("SELECT COUNT(*) FROM tweet ", conn);
            nbTotalTweet = (int)nbTotalTwt;
            Int64 nbPositiveTwt = requestSqlCount("SELECT COUNT(*) FROM tweet WHERE sentiment = 1", conn);
            nbPositiveTweet = (int)nbPositiveTwt;
            Int64 nbNegativeTwt = requestSqlCount("SELECT COUNT(*) FROM tweet WHERE sentiment = -1", conn);
            nbNegativeTweet = (int)nbNegativeTwt;
            Int64 nbNeutralTwt  = requestSqlCount("SELECT COUNT(*) FROM tweet WHERE sentiment = 0", conn);
            nbNeutralTweet = (int)nbNeutralTwt;
            */

            nbTotalTweet = listTweet.Count;
            nbPositiveTweet = triPieChart(listTweet, 1); // 1=positive
            nbNegativeTweet = triPieChart(listTweet, -1); // -1=negative
            nbNeutralTweet = triPieChart(listTweet, 0); // 0=neutral

            //transformation en pourcentages
            percentagePositiveTweet = percentage(nbPositiveTweet, nbTotalTweet);
            percentageNegativeTweet = percentage(nbNegativeTweet, nbTotalTweet);
            percentageNeutralTweet  = percentage(nbNeutralTweet, nbTotalTweet);
            percentageTotalTweet    = 100.0F;

        }

        //getters
        public int getNbTotalTweet()
        {
            return nbTotalTweet;
        }
        public int getNbPositiveTweet()
        {
            return nbPositiveTweet;
        }    
        public int getNbNegativeTweet()
        {
            return nbNegativeTweet;
        }
        public int getNbNeutralTweet()
        {
            return nbNeutralTweet;
        }
        public float getPercentagePositiveTweet()
        {
            return percentagePositiveTweet;
        }
        public float getPercentageNegativeTweet()
        {
            return percentageNegativeTweet;
        }
        public float getPercentageNeutralTweet()
        {
            return percentageNeutralTweet;
        }
        public float getPercentageTotalTweet()
        {
            return percentageTotalTweet;
        }

        //setters
        public void setNbTotalTweet(int totalTwt)
        {
            nbTotalTweet = totalTwt;
        }
        public void setNbPositiveTweet(int positiveTwt)
        {
            nbPositiveTweet = positiveTwt;
        }
        public void setNbNegativeTweet(int negativeTwt)
        {
            nbNegativeTweet = negativeTwt;
        }
        public void setPercentagePositiveTweet(int percentPositiveTwt)
        {
            percentagePositiveTweet = percentPositiveTwt;
        }
        public void setPercentageNegativeTweet(int percentNegativeTwt)
        {
            percentageNegativeTweet = percentNegativeTwt;
        }
        public void setPercentageNeutralTweet(int percentNeutralTwt)
        {
            percentageNeutralTweet = percentNeutralTwt;
        }

        //transformation en pourcentage
        public float percentage(Int64 number, Int64 total)
        {
            float percentage = (((float)number * 100) / (float)total);
            return percentage;
        }

        //requete SQL Count
        public Int64 requestSqlCount(String request, NpgsqlConnection conn)
        {
            NpgsqlCommand command = new NpgsqlCommand(request, conn);
            // Execute the query and obtain a result set
            Int64 count = (Int64)command.ExecuteScalar();

            return count;
        }

        public int triPieChart(List<Tweet> listTweet, int sentiment) // SENTIMENT : 0=neutral 1=positive -1=negative
        {
            int count = 0;
            //boucle sur listTweet
            foreach (Tweet tw in listTweet)
            {
                if (tw.getSentiment() == sentiment)
                {
                    count = count + 1;
                }
            }

            return count;
        }
    }
}