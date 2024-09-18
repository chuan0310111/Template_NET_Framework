using _0.Template_NET_Framework.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0.Template_NET_Framework.Common.Implement
{
    public class AppSettings : IAppSettings
    {
        /// <summary>
        /// 新竹縣政府
        /// </summary>
        public string hsinchuGovUrl { get; }

        public AppSettings(IDictionary<string, string> paramsDictionary) {
            this.hsinchuGovUrl = paramsDictionary["hsinchuGovUrl"];
        }
    }
}
