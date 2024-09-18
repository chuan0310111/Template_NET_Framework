using NLog; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _0.Template_NET_Framework.Common.Implement
{
    public class Logger : Interface.ILogger
    {
        private readonly ILogger _logger;
        private readonly string _channel;
        private readonly HttpContextBase _httpContext;

        private LogEventInfo GetLogEventInfo(LogLevel logLevel, string msg, IDictionary<string, object> infos)
        {
            var msgId = this._httpContext?.Items["MessageId"] as string;
            var logInfo = new LogEventInfo(logLevel, "", $"[{msgId}] {msg}");
            if (infos != null && infos.Any())
            {
                foreach (var item in infos)
                {
                    logInfo.Properties.Add(item.Key, item.Value);
                }
            }

            if (infos == null && !infos.ContainsKey("spent"))
            {
                logInfo.Properties.Add("spent", 0);
            }

            logInfo.Properties.Add("messageId", msg);
            logInfo.Properties.Add("channel", this._channel);
            return logInfo;
        }

        public Logger(HttpContextBase httpContext, string channel)
        {
            this._logger = LogManager.GetCurrentClassLogger();
            this._channel = channel;
            this._httpContext = httpContext;
        }

        public void Info(string logMessage)
        {
            this.Info(logMessage, null);
        }

        public void Info(string logMessage, IDictionary<string, object> infos)
        {
            var logInfo = GetLogEventInfo(LogLevel.Info, logMessage, infos);
            this._logger.Info(logInfo);
        }

        public void Warn(string logMessage)
        {
            this.Warn(logMessage, null);
        }

        public void Warn(string logMessage, IDictionary<string, object> infos)
        {
            var logInfo = GetLogEventInfo(LogLevel.Warn, logMessage, infos);
            this._logger.Warn(logInfo);
        }

        public void Error(string logMessage)
        {
            this.Error(logMessage, null);
        }

        public void Error(string logMessage, IDictionary<string, object> infos)
        {
            var logInfo = GetLogEventInfo(LogLevel.Error, logMessage, infos);
            this._logger.Error(logInfo);
        }

        public void Trace(string logMessage)
        {
            this.Trace(logMessage, null);
        }

        public void Trace(string logMessage, IDictionary<string, object> infos)
        {
            var logInfo = GetLogEventInfo(LogLevel.Trace, logMessage, infos);
            this._logger.Trace(logInfo);
        }


        public void Debug(string logMessage)
        {
            this.Debug(logMessage, null);
        }

        public void Debug(string logMessage, IDictionary<string, object> infos)
        {
            var logInfo = GetLogEventInfo(LogLevel.Debug, logMessage, infos);
            this._logger.Debug(logInfo);
        }
    }
}
