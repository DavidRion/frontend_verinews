using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace verinews_v16.Models
{
    public class TweetCountDate
    {

        //declaration des ressources
        public DateTime TweetCountDate_date { get; set; }
        public int TweetCountDate_count { get; set; }
        public int count_positive { get; set; }
        public int count_negative { get; set; }
        public int count_neutral { get; set; }

        //constructor
        public TweetCountDate()
        {
            TweetCountDate_date  = DateTime.Now;
            TweetCountDate_count = 0;
            count_positive       = 0;
            count_negative       = 0;
            count_neutral        = 0;
        }

        //getters
        public DateTime getTweetCountDateDate()
        {
            return TweetCountDate_date;
        }
        public int getTweetCountDateCount()
        {
            return TweetCountDate_count;
        }
        public int getCountPositive()
        {
            return count_positive;
        }
        public int getCountNegative()
        {
            return count_negative;
        }
        public int getCountNeutral()
        {
            return count_neutral;
        }
        public String getStringTweetCountDateDate()
        {
            return TweetCountDate_date.ToString();
        }
        //setters
        public void setTweetCounDateDate(DateTime date)
        {
            this.TweetCountDate_date = date;
        }
        public void setTweetCountDateCount(int count)
        {
            this.TweetCountDate_count = count;
        }
        public void setCountPositive(int count)
        {
            count_positive = count;
        }
        public void setCountNegative(int count)
        {
            count_negative = count;
        }
        public void setCountNeutral(int count)
        {
            count_neutral = count;
        }

    }
}