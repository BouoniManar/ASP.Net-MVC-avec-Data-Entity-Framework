using System.Web;
using System.Web.Mvc;

namespace ASP.Net_MVC_avec_Data_Entity_Framework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
