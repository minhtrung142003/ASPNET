using System.Web;
using System.Web.Mvc;

namespace Haminhtrung_2121110279_aspNET
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
