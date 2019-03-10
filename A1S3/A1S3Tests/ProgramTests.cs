using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S3.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod()]
        public void Q1_GetWordsTest()
        {
            File.WriteAllLines(Path.GetTempFileName(), new string[] { "pos1", "pos2", "pos3" });
            string[] exp = { "pos1", "pos2", "pos3" };
            string [] act=Program.Q1_GetWords(Path.GetTempFileName());
            for (int i = 0; i < act.Length; i++)
            {
                Assert.AreEqual(exp[i],act[i]);
            }
        }

        [TestMethod()]
        public void Q2_IsInWordsTest()
        {
            string[] word = { "khob", "bad", "zesht" };
            bool exp = true;
            bool act=Program.Q2_IsInWords(word,"bad");
            Assert.AreEqual(exp, act);
        }

        [TestMethod()]
        public void Q3_GetWordsOfTweetTest()
        {
            string tweet = "pos1,pos2!pos3 pos4?pos5:pos6";
            string[] act = Program.Q3_GetWordsOfTweet(tweet);
            string[] exp = { "pos1", "pos2", "pos3", "pos4", "pos5", "pos6" };
            for(int i=0;i<act.Length;i++)
                Assert.AreEqual(exp[i], act[i]);
        }

        [TestMethod()]
        public void Q4_GetPopChargeOfTweetTest()
        {
            string tweet = "pos1 pos2 pos3.pos4?pos5!pos6.";
            string[] posword = { "pos1", "pos2" };
            string[] negword = { "pos3", "pos4", "pos5" };
            int act=Program.Q4_GetPopChargeOfTweet(tweet, posword, negword);
            int exp = -1;
            Assert.AreEqual(exp, act);
        }

        [TestMethod()]
        public void Q5_GetAvgPopChargeOfTweetsTest()
        {
            string[] tweets =
            {
                "pos1,pos3 pos5",
                "pos5 pos6.pos2",
                "pos2?pos3 pos1."
            };
            string[] posword = { "pos1", "pos2" };
            string[] negword = { "pos3", "pos4", "pos5" };
            double act = Program.Q5_GetAvgPopChargeOfTweets(tweets, negword, posword);
            double exp = -(1 / 3);
            Assert.AreEqual(exp, act);

        }
    }
}