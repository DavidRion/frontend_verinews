using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace verinews_v16.Models
{
    public class TweetCountLineChart
    {
        //declaration des ressources
        public List<TweetCountDate> tablePositive;
        public List<TweetCountDate> tableNegative;
        public List<TweetCountDate> tableNeutral;
        public List<TweetCountDate> tableAll { get; set; }

        //constructeur
        public TweetCountLineChart(List<Tweet> listTweet)
        {
            //instanciation
            tablePositive = new List<TweetCountDate>();
            tableNegative = new List<TweetCountDate>();
            tableNeutral  = new List<TweetCountDate>();
            tableAll = new List<TweetCountDate>();

            //tri des dates pour linecharts
            tablePositive = triLineChart(1, listTweet);
            tableNegative = triLineChart(-1, listTweet);
            tableNeutral  = triLineChart(0, listTweet);
            tableAll      = triAllLineChart(listTweet);
        }

        //getters
        public List<TweetCountDate> getTablePositive()
        {
            return tablePositive;
        }
        public List<TweetCountDate> getTableNegative()
        {
            return tableNegative;
        }
        public List<TweetCountDate> getTableNeutral()
        {
            return tableNeutral;
        }
        public List<TweetCountDate> getTableAll()
        {
            return tableAll;
        }

        //methodes
        public int checkDateTweet(Tweet tw, List<TweetCountDate> listCountDate)
        {
            int rt = 0;
            //boucle sur la liste pour checker si date existe deja ou pas
            if (listCountDate.Count > 0)
            {
                foreach (TweetCountDate dateCount in listCountDate)
                {
                    DateTime twDate = tw.getTweetDate();
                    DateTime datCountDate = dateCount.getTweetCountDateDate();

                    //check
                    if (twDate == datCountDate)
                    {
                        rt = 1;
                    }
                }
            }

            return rt;
        }

        public List<TweetCountDate> triLineChart(int sentimentTweet, List<Tweet> listOfTweet)
        {

            //declaration ressrouces
            List<TweetCountDate> tableLineChartTweet = new List<TweetCountDate>();
            int checkDate = 0;

            //boucle sur listTweet
            foreach (Tweet tw in listOfTweet)
            {
                //recuperation date du tweet
                DateTime dat = tw.getTweetDate();

                //test du sentiment
                if (tw.getSentiment() == sentimentTweet)
                {
                    //si date du tweet pas dans tableau date tweet
                    checkDate = checkDateTweet(tw, tableLineChartTweet);
                    if (checkDate == 0)
                    {
                        //on cree un tweetCountDate (ajoute la date + incremente compteur associé)
                        TweetCountDate twCountDat = new TweetCountDate();
                        twCountDat.setTweetCounDateDate(tw.getTweetDate());
                        twCountDat.setTweetCountDateCount(twCountDat.getTweetCountDateCount() + 1);
                        //on ajoute le tweetCountDate dans list
                        tableLineChartTweet.Add(twCountDat);
                    }
                    else //si date deja dans tableau
                    {
                        foreach (TweetCountDate tcd in tableLineChartTweet)
                        {
                            if (tcd.getTweetCountDateDate() == tw.getTweetDate())
                            {
                                //on incremente compteur
                                tcd.setTweetCountDateCount(tcd.getTweetCountDateCount() + 1);
                            }
                        }
                    }
                }
            }

            return tableLineChartTweet;
        }

        public List<TweetCountDate> triAllLineChart(List<Tweet> listOfTweet)
        {

            //declaration ressrouces
            List<TweetCountDate> tableLineChartTweet = new List<TweetCountDate>();
            int checkDate = 0;

            //boucle sur listTweet
            foreach (Tweet tw in listOfTweet)
            {
                //recuperation date du tweet
                DateTime dat = tw.getTweetDate();

                //si date du tweet pas dans tableau date tweet
                checkDate = checkDateTweet(tw, tableLineChartTweet);
                if (checkDate == 0)
                {
                    //on cree un tweetCountDate (ajoute la date + incremente compteur associé)
                    TweetCountDate twCountDat = new TweetCountDate();
                    twCountDat.setTweetCounDateDate(tw.getTweetDate());

                    if (tw.getSentiment() == 1)
                    {
                        twCountDat.setCountPositive(twCountDat.getCountPositive() + 1);
                    }
                    else if (tw.getSentiment() == 0)
                    {
                        twCountDat.setCountNeutral(twCountDat.getCountNeutral() + 1);
                    }
                    else if (tw.getSentiment() == -1)
                    {
                        twCountDat.setCountNegative(twCountDat.getCountNegative() + 1);
                    }

                    //on ajoute le tweetCountDate dans list
                    tableLineChartTweet.Add(twCountDat);
                }
                else //si date deja dans tableau
                {
                    foreach (TweetCountDate tcd in tableLineChartTweet)
                    {
                        if (tcd.getTweetCountDateDate() == tw.getTweetDate())
                        {
                            //si tweet positif
                            if (tw.getSentiment() == 1)
                            {
                                //on incremente compteur
                                tcd.setCountPositive((tcd.getCountPositive() + 1));
                            }
                            //tweet neutre
                            else if (tw.getSentiment() == 0)
                            {
                                //on incremente compteur
                                tcd.setCountNeutral((tcd.getCountNeutral() + 1));
                            }
                            //si tweet negatif
                            else if (tw.getSentiment() == -1)
                            {
                                //on incremente compteur
                                tcd.setCountNegative((tcd.getCountNegative() + 1));
                            }
                        }
                    }
                }
                
            }

            return tableLineChartTweet;
        }



    }
}