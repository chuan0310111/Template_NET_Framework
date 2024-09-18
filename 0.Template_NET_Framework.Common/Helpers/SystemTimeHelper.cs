using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0.Template_NET_Framework.Common.Helpers
{
    /// <summary>
    ///   系統時間
    /// </summary>
    class SystemTimeHelper
    {
        /// <summary>
        ///// The now
        /// </summary>
        public static Func<DateTime> Now = () => DateTime.Now;

        /// <summary>
        /// Sets the date time
        /// </summary>
        /// <param name="dateTimeNow"></param>
        public static void SetDateTime(DateTime dateTimeNow)
        {
            Now = () => dateTimeNow;
        }

        internal static void Reset()
        { 
            Now = () => DateTime.Now; 
        }
    }
}
