using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0.Template_NET_Framework.Common.Interface
{
    public interface ILogger
    {
        void Info(string logMessage);
        void Info(string logMessage, IDictionary<string, object> infos);
        void Warn(string logMessage);
        void Warn(string logMessage, IDictionary<string, object> infos);
        void Error(string logMessage);
        void Error(string logMessage, IDictionary<string, object> infos);
        void Trace(string logMessage);
        void Trace(string logMessage, IDictionary<string, object> infos);
        void Debug(string logMessage);
        void Debug(string logMessage, IDictionary<string, object> infos);
    }
}
