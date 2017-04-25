using System;
using System.IO;
using System.Linq;

namespace OnNetDown
{
    public class NetStatusInspector
    {
        private string CarrierPath { get; }

        public NetStatusInspector(string networkInterface)
        {
            CarrierPath = $"/sys/class/net/{networkInterface}/carrier";
        }

        public NetStatus GetStatus()
        {
            try
            {
                var isConnected = File.ReadLines(CarrierPath).First().Trim() == "1";
                return isConnected ? NetStatus.Connected : NetStatus.Disconnected;
            }
            catch (Exception e)
            {
                return NetStatus.Unknown;
            }
        }
    }
}