using System.Configuration;
using System;
using System.Collections.Specialized;

namespace OnNetDown
{
    public class OnNetDownConfig
    {
        public OnNetDownConfig(string configFileName)
        {
            AppSettings = new Lazy<NameValueCollection>(() =>
            {
                return ConfigurationManager.AppSettings;
            });
        }

        private Lazy<NameValueCollection> AppSettings { get; }

        public string NetworkInterfaceName => AppSettings.Value["NetworkInterface"];
        public string Shell => AppSettings.Value["Shell"];
        public string OnNetDownCommand => AppSettings.Value["OnNetDownCommand"];
        public string OnErrorCommand => AppSettings.Value["OnErrorCommand"];
        public TimeSpan RetryInterval => TimeSpan.Parse(AppSettings.Value["RetryInterval"]);
        public int RetryTimes => int.Parse(AppSettings.Value["RetryTimes"]);
        public string LogFile => AppSettings.Value["LogFile"];
    }
}