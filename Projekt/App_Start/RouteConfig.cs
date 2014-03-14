using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Projekt
{
    public class RouteConfig
    {
        //Ändrar addressfältet så att det står vad det är man går till till exempel filmer istället för Pages/MovieList.aspx
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Movies", "filmer", "~/Pages/MovieList.aspx");
            routes.MapPageRoute("MovieDetails", "filmer/{id}", "~/Pages/MovieDetails.aspx");
            routes.MapPageRoute("CreateMovie", "ny/film", "~/Pages/Create.aspx");
            routes.MapPageRoute("Actors", "skådespelare", "~/Pages/ActorList.aspx");

            routes.MapPageRoute("Default", "", "~/Pages/MovieList.aspx");
        }
    }
}