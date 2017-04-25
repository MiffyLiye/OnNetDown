using System;
using System.IO;

namespace OnNetDown
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new OnNetDownConfig("App.config");
            try
            {
                var driver = new Driver(config);
                driver.Drive();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                using (var sw = new StreamWriter(config.LogFile))
                {
                    sw.WriteLine(ex.ToString());
                }
            }
        }
    }
}
