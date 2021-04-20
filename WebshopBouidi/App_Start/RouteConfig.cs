using System.Web.Mvc;
using System.Web.Routing;

namespace WebshopBouidi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Appointment",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Appointment", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Contact",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
