using PhoneBook.DAL;
using PhoneBookWebService.BasicAuthentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;

namespace PhoneBookWebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();
            // Web API odata routes
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<People>("PeopleOdata");
            builder.EntitySet<City>("Cities");
            builder.EntitySet<Country>("Countries");
            builder.EntitySet<State>("States");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new BasicAuthenticationAttribute());
            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
