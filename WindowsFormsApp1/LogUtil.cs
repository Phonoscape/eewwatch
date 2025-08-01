using System;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace LogUtil
{
    internal class LogUtil
    {
        public static void Log(string filename, string message)
        {
            Debug.WriteLine(message);

            DateTime dateTime = DateTime.Now;

            Encoding enc = Encoding.UTF8;
            StreamWriter writer = new StreamWriter(filename, true, enc);
            
            string output = string.Format("{0} : {1}", dateTime.ToString("yyyy-MM-dd HH:mm:ss"), message);

            writer.WriteLine(output);
            writer.Close();
        }
    }
}
