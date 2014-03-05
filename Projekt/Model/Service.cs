using Projekt.Model.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekt.Model
{
    public class Service
    {
        private static ActorDAL _ActorDAL;
        private static MovieDAL _MovieDAL;
        private static StarringDAL _StarringDAL;

        //Egenskaper som instansierar ett nytt ActorDAL-/MovieDAL-/StarringDAL-objekt eller skapar ett om det inte finns
        private static ActorDAL ActorDAL
        {
            get { return _ActorDAL ?? (_ActorDAL = new ActorDAL()); }
        }

        public static MovieDAL MovieDAL 
        {
            get { return _MovieDAL ?? (_MovieDAL = new MovieDAL()); } 
        }

        public static StarringDAL StarringDAL 
        {
            get { return _StarringDAL ?? (_StarringDAL = new StarringDAL()); } 
        }

        //Alla metoder som har med filmer att göra
        public static void DeleteMovie(Movie movie)
        {
            DeleteMovie(movie.MovieID);
        }

        public static void DeleteMovie(int movieId)
        {
            MovieDAL.DeleteMovie(movieId);
        }

        public static Movie GetMovie(int movieId)
        {
            return MovieDAL.GetMovieById(movieId);
        }

        public static IEnumerable<Movie> GetMovies()
        {
            return MovieDAL.GetMovies();
        }

        public static void SaveMovie(Movie movie)
        {
            if (movie.MovieID == 0)
            {
                MovieDAL.InsertMovie(movie);
            }
            else
            {
                MovieDAL.UpdateMovie(movie);
            }
        }
    }
}