using System.Web;
using System.Web.Mvc;

namespace Sistema_Planilla_CP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
