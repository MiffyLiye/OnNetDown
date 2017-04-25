using System.Diagnostics;

namespace OnNetDown
{
    public class CommandRunner
    {
        private string Shell { get; }
        private string Command { get; }
        public CommandRunner(string shell, string command)
        {
            Shell = shell;
            Command = command;
        }

        public void Run()
        {
            var process = new Process
            {
                StartInfo =
                {
                    FileName = Shell,
                    Arguments = $"-c \"{Command}\"",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };
            process.Start();
            process.WaitForExit();
        }
    }
}