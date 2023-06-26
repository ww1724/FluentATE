using ATE.Common;
using ATE.Common.Contracts;
using ATE.Service.Contracts;
using ATE.Share;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATE.Service
{
    public class LoggerService : ILoggerService, IAppService
    {
        public string Id => "Core.LoggerService";

        public string ServiceName => "日志服务";

        public bool IsRunning { get; private set; }

        public string StateString => "default";

        private ILogger Logger { get; set; }

        private string logLevel = "Error";

        public LoggerService()
        {
            Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File(AppFields.LogFilePath)
                .CreateLogger();
        }

        public void Log(string message)
        {
            switch (logLevel)
            {
                case "Error": 
                    Logger.Error(message); break;
                case "Info":
                    Logger.Information(message); break;
                case "Warning": 
                    Logger.Warning(message); break;
                default: Logger.Error(message); break;
            }
        }

        public void SetLogLevel(string level)
        {
            logLevel = level;
        }

        public void Error(string message)
        {
            Logger.Error(message);
        }

        public void Error(string message, Exception exception)
        {
            Logger.Error(exception.Message, exception);
        }

        public void Info(string message)
        {
            Logger.Information(message);
        }

        public void Warn(string message)
        {
            Logger.Warning(message);
        }
    }
}
