using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace verinews_v16.Models
{
    public class Tweet
    {
        //declaration ressources
        private int tweet_id;
        private String tweet_text;
        private int sentiment;
        private DateTime tweet_date;
        private String tweet_type;
        
        //constructor
        public Tweet()
        {
            tweet_id = 0;
            tweet_text = null;
            sentiment = 0;
            tweet_date = DateTime.Now;
        }

        //setters
        public void setTweetId(int twId)
        {
            tweet_id = twId; 
        }
        public void setTweetText(String twTxt)
        {
            tweet_text = twTxt;
        }
        public void setSentiment(int sent)
        {
            sentiment = sent;
        }
        public void setTweetDate(DateTime date)
        {
            tweet_date = date;
        }
        public void setTweetType(String typ)
        {
            tweet_type = typ;
        }

        //getters
        public int getTweetId()
        {
            return tweet_id;
        }
        public String getTweetText()
        {
            return tweet_text;
        }
        public int getSentiment()
        {
            return sentiment;
        }
        public DateTime getTweetDate()
        {
            return tweet_date;
        }
        public String getTweetType()
        {
            return tweet_type;
        }
      
    }
}