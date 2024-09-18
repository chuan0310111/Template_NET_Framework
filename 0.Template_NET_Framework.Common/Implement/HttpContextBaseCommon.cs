using _0.Template_NET_Framework.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace _0.Template_NET_Framework.Common.Implement
{

    public class HttpContextBaseCommon : IHttpContextBaseCommon
    {
        /// <summary>
        /// 取得系統messageId
        /// </summary>
        public string GetMessageId()
        {
            return HttpContext.Current?.Items["MessageId"] as string;
        }
    }
}