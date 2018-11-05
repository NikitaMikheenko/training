using System.Web.Mvc;
using System.Web.Routing;

namespace Task
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "EngineeringDepartment",
                "University/EngineeringDepartment",
                new { controller = "EngineeringDepartment", action = "Index" }
            );

            routes.MapRoute(
                "PhilologicalDepartment",
                "University/PhilologicalDepartment",
                new { controller = "PhilologicalDepartment", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "University", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
