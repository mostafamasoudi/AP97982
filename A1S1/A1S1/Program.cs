using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S1
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
        public static int CaculateLength(string str)
        {
            return str.Length;
        }
        public static int LetterCount(string str)
        {
            int count = 0;
            foreach(char a in str)
            {
                if (char.IsLetter(a) == true)
                    count++;
            }
            return count;
        }
        public static int LineCount(string str)
        {
            int count = 0;
            while(str.Contains("\n"))
            {
                str = str.Substring(str.IndexOf('\n') + 1);
                count++;
            }
            return count+1;
        }
        public static int FileLineCount(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            return lines.Length;
        }
        public static string[] ListFiles(string dirPath)
        {
            string[] files= Directory.GetFiles(dirPath);
            return files;
        }
        public static double FileSize(string filePath)
        {
            double count = 0;
            string[] files = File.ReadAllText(filePath).Split(' ');
            foreach(string file in files)
            {
                count += file.Length;
            }
            return count;
        }

    }
}

