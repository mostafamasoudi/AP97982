using Microsoft.VisualStudio.TestTools.UnitTesting;
using A1S1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace A1S1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        

        [TestMethod()]
        public void CaculateLengthTest()
        {
            int entezar = 21;
            int result = Program.CaculateLength("this is a test string");
            Assert.AreEqual(entezar, result);
        }

        [TestMethod()]
        public void LetterCountTest()
        {
            int entezar = 16;
            int result = Program.LetterCount("من همیشه سر وقت هستم");
            Assert.AreEqual(entezar, result);
        }

        [TestMethod()]
        public void LineCountTest()
        {
            int entezar = 4;
            int result = Program.LineCount("salam\nchetori\nkhobi\n");
            Assert.AreEqual(entezar, result);
        }

        [TestMethod()]
        public void FileLineCountTest()
        {
            string address = GetTestFile(out int lineCount, out int charCount);
            Assert.AreEqual(lineCount, Program.FileLineCount(address));
        }

        private static string GetTestFile(out int lineCount, out int charCount)
        {
            charCount = 0;
            string tmpFile = Path.GetTempFileName();
            lineCount = new Random(0).Next(10, 100);
            List<string> lines = new List<string>();
            for (int i = 0; i < lineCount; i++)
            {
                string line = $"Line number {i}";
                charCount += line.Length;
                lines.Add(line);
            }
            File.WriteAllLines(tmpFile, lines);
            return tmpFile;
        }

        [TestMethod()]
        public void ListFilesTest()
        {
            string[] expfiles = GetTestDir(out string tmpDir);
            string[] actfiles = Program.ListFiles(tmpDir);
            for(int i=0;i<expfiles.Length;i++)
            {
                for (int j= 0;j < actfiles.Length;j++)
                {
                    if(expfiles[i]==actfiles[j])
                    {
                        expfiles[i] = null;
                    }
                }
            }
            foreach(string exp in expfiles)
            {
                Assert.AreEqual(null,exp);
            }
        }

        private static string[] GetTestDir(out string tmpDir)
        {
            tmpDir = Path.GetTempFileName();
            if (File.Exists(tmpDir))
                File.Delete(tmpDir);
            if (!Directory.Exists(tmpDir))
                Directory.CreateDirectory(tmpDir);
            else
                foreach (string file in Directory.GetFiles(tmpDir))
                    File.Delete(file);

            int rndNum = new Random(0).Next(10, 20);
            List<string> files = new List<string>();
            for (int i = 0; i < rndNum; i++)
            {
                string fileName = Path.Combine(tmpDir, $"file{i}.txt");
                File.WriteAllText(fileName, $"file{i}.txt content");
                files.Add(fileName);
            }
            return files.ToArray();
        }
        [TestMethod()]
        public void FileSizeTest()
        {
            string address = GetTestFile(out int lineCount, out int charCount);
            Assert.AreEqual(charCount, Program.FileSize(address));
        }
    }
}