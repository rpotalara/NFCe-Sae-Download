using System;
using System.IO;
using System.Text;

namespace NfceSaeDownloader.Services
{
    public sealed class LogService
    {
        private readonly string _filePath;
        private readonly object _sync = new object();

        public LogService(string baseDirectory)
        {
            var logDir = Path.Combine(baseDirectory, "logs");
            Directory.CreateDirectory(logDir);
            _filePath = Path.Combine(logDir, "sae-nfce.log");
            Cleanup(logDir);
        }

        public void Info(string message)
        {
            Write("INFO", message);
        }

        public void Error(string message)
        {
            Write("ERROR", message);
        }

        private void Write(string level, string message)
        {
            lock (_sync)
            {
                File.AppendAllText(_filePath,
                    string.Format("{0:yyyy-MM-dd HH:mm:ss.fff} [{1}] {2}{3}", DateTime.Now, level, message, Environment.NewLine),
                    Encoding.UTF8);
            }
        }

        private void Cleanup(string logDir)
        {
            foreach (var file in Directory.GetFiles(logDir, "*.log"))
            {
                try
                {
                    var info = new FileInfo(file);
                    if (info.LastWriteTime < DateTime.Now.AddDays(-30))
                    {
                        info.Delete();
                    }
                }
                catch
                {
                }
            }
        }
    }
}
