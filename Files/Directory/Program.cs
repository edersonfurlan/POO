using System;
using System.IO;

namespace DirectoryIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"c:\temp\myfolder";

            try
            {
                var folders = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FOLDERS:");
                foreach (string s in folders)
                    Console.WriteLine(s);

                var files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FILES:");
                foreach (string s in files)
                    Console.WriteLine(s);

                Directory.CreateDirectory(path + @"\newfolder");

                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: " + e.Message);
            }
        }
    }
}
