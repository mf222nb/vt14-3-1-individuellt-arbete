using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Projekt
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Movies", "filmer", "~/Pages/MovieList.aspx");
            routes.MapPageRoute("MovieDetails", "filmer/{id}", "~/Pages/MovieDetails.aspx");
            routes.MapPageRoute("CreateMovie", "ny/film", "~/Pages/CreateMovie.aspx");

            routes.MapPageRoute("Default", "", "~/Pages/MovieList.aspx");
        }
    }
}