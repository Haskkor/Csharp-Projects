using System.Web;
using System.Web.Mvc;

namespace _3NETMiniProjet1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}