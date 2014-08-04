using System.Web.Http;
using DigestAuthDemo.Http;

namespace DigestAuthDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new BasicAuthorizationFilterAttribute(false));
            config.Filters.Add(new DigestAuthorizationFilterAttribute());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "{controller}/{id}",
                new { controller = "data", id = RouteParameter.Optional }
            );
        }
    }
}
