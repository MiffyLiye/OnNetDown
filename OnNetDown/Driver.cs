using System.Threading;

namespace OnNetDown
{
    public class Driver
    {
        public Driver(OnNetDownConfig config)
        {
            Config = config;
            Inspector = new NetStatusInspector(config.NetworkInterfaceName);
            NetDownCommandRunner = new CommandRunner(config.Shell, config.OnNetDownCommand);
            UnknownErrorCommandRunner = new CommandRunner(config.Shell, config.OnNetDownCommand);
        }

        private OnNetDownConfig Config { get; }
        private NetStatusInspector Inspector { get; }
        private CommandRunner NetDownCommandRunner { get; }
        private CommandRunner UnknownErrorCommandRunner { get; }

        public void Drive()
        {
            var disconnectedCount = 0;
            var unknownErrorCount = 0;
            while (true)
            {
                switch (Inspector.GetStatus())
                {
                    case NetStatus.Connected:
                        disconnectedCount = 0;
                        unknownErrorCount = 0;
                        break;
                    case NetStatus.Disconnected:
                        disconnectedCount += 1;
                        break;
                    case NetStatus.Unknown:
                        unknownErrorCount += 1;
                        break;
                }

                if (disconnectedCount == Config.RetryTimes)
                {
                    NetDownCommandRunner.Run();
                    return;
                }
                if (unknownErrorCount == Config.RetryTimes)
                {
                    UnknownErrorCommandRunner.Run();
                    return;
                }

                Thread.Sleep(Config.RetryInterval);
            }
        }
    }
}