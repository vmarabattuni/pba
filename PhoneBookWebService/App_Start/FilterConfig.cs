using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace PhoneBookWebService
{
   
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
        filters.Add(new HandleErrorAttribute());
        }

      
    }
}
