using System.Web;
using System.Web.Mvc;

namespace _1.Template_NET_Framework.Controller
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
