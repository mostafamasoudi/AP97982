using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> result = new List<string>();
            string[] tweetfiles = Directory.GetFiles(@"..\..\TwitterData\Tweets");
            string[] wordfiles = Directory.GetFiles(@"..\..\TwitterData\Words");
            foreach (string file in tweetfiles)
            {
                FileInfo fi = new FileInfo(file);
                string name = fi.Name;
                string[] tweets = File.ReadAllLines(file);
                string[] poswords= Q1_GetWords(wordfiles[1]);
                string[] negwords = Q1_GetWords(wordfiles[0]);
                double avg = Q5_GetAvgPopChargeOfTweets(tweets, negwords, poswords);
                result.Add($"{name}:{avg}");
            }
            string[] results = result.ToArray();
            File.WriteAllLines(@"..\..\result.txt", results);
            
        }


        public static string[] Q1_GetWords(string path)
        {
            string[] words = File.ReadAllLines(path);
            return words;
        }
        public static bool Q2_IsInWords(string[] words, string word)
        {
            foreach(string a in words)
            {
                if (a == word)
                    return true;
            }
            return false;
        }
        public static string[] Q3_GetWordsOfTweet(string tweet)
        {
            string [] words=tweet.Split('!','?','#','@',' ','"',',','.',';','،');
            return words;
        }
        public static int Q4_GetPopChargeOfTweet(string tweet,string[] posWords, string[]negWords)
        {
            int count = 0;
            string[] wordoftweet = Q3_GetWordsOfTweet(tweet);
            foreach(string posword in posWords)
            {
                if (Q2_IsInWords(wordoftweet, posword))
                    count++;
            }
            foreach (string negword in negWords)
            {
                if (Q2_IsInWords(wordoftweet, negword))
                    count--;
            }
            return count;
        }
        public static double Q5_GetAvgPopChargeOfTweets(string[]tweets, string[] negWords,string[] posWords)
        {
            double sum = 0;
            foreach(string tweet in tweets)
            {
                sum += Q4_GetPopChargeOfTweet(tweet, posWords, negWords);
            }
            double avg = sum / tweets.Length;
            return avg;
        }

    }
}
