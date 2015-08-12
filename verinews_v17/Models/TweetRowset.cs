using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace verinews_v16.Models
{
    public class TweetRowset
    {

        //declaration ressources
        private List<Tweet> tweetRowset;

        //constructor
        public TweetRowset(String request, NpgsqlConnection conn)
        {
            tweetRowset = new List<Tweet>();
            requestSqlRowset(request, conn);
        }

        //requete rowset
        public void requestSqlRowset(String request, NpgsqlConnection conn)
        {

            // Define a query
            NpgsqlCommand command = new NpgsqlCommand(request, conn);
            // Execute the query and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();

            // liste des tweets
            while (dr.Read())
            {
                Tweet temp = new Tweet();
                temp.setTweetText((String)dr[1]);
                temp.setSentiment((int)dr[2]);
                temp.setTweetDate((DateTime)dr[3]);
                temp.setTweetType((String)dr[4]);
                tweetRowset.Add(temp);
            }
        }

        //getter
        public List<Tweet> getTweetRowset()
        {
            return tweetRowset;
        }

    }
}