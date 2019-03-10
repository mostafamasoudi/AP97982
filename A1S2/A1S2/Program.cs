using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1S2
{
     public class Program
    {
        public static void Main(string[] args)
        {
            string  address= args[0];
            Console.WriteLine(Size(address));
        }
        public static double Size(string address)
        {
            double sizes = 0;
            string[] files = Directory.GetFiles(address);
            foreach (string file in files)
            {
                
                FileInfo fi = new FileInfo(file);
                sizes += fi.Length;
            }
            string[] folders = Directory.GetDirectories(address);
            if(folders.Length>0)
            {
                foreach(string folder in folders)
                {
                    sizes += Size(folder);
                }
            }
            return sizes;
        }

    }
}
