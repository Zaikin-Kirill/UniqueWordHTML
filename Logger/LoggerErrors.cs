using System;
using System.IO;

namespace UniqueWordHTML.Logger
{
    static class LoggerErrors
    {
        static string path = @"log.txt";

        public static void createLog()
        {
            FileInfo fileInf = new FileInfo(path);
            if (!fileInf.Exists) fileInf.Create().Close();
            
        }
        public static void writeLog(string text)
        {
            using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now + ": " + text);
                Console.WriteLine(text);
            }
        }

        
    }
}
