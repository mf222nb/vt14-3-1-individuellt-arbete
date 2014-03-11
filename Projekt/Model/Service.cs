using Projekt.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            ICollection<ValidationResult> validationresults;
            if (!movie.Validate(out validationresults))
            {
                var ex = new ValidationException("Objektet kunde inte valideras");
                ex.Data.Add("ValidationResults", validationresults);
                throw ex;
            }
            if (movie.MovieID == 0)
            {
                MovieDAL.InsertMovie(movie);
            }
            else
            {
                MovieDAL.UpdateMovie(movie);
            }
        }

        //Alla metoder som har med skådespelare att göra
        public static void DeleteActor(Actor actor)
        {
            DeleteActor(actor.ActorID);
        }

        public static void DeleteActor(int actorId)
        {
            ActorDAL.DeleteActor(actorId);
        }

        public static IEnumerable<Actor> GetActors()
        {
            return ActorDAL.GetActors();
        }

        public static Actor GetActor(int actorId)
        {
            return ActorDAL.GetActorById(actorId);
        }

        public static void SaveActor(Actor actor)
        {
            ICollection<ValidationResult> validationresults;
            if (!actor.Validate(out validationresults))
            {
                var ex = new ValidationException("Objektet kunde inte valideras");
                ex.Data.Add("ValidationResults", validationresults);
                throw ex;
            }
            if (actor.ActorID == 0)
            {
                ActorDAL.InsertActor(actor);
            }
            else
            {
                ActorDAL.UpdateActor(actor);
            }
        }

        //Metoder som har med medverkan att göra
        public static void SaveStarring(Starring starring)
        {
            ICollection<ValidationResult> validationresults;
            if (!starring.Validate(out validationresults))
            {
                var ex = new ValidationException("Objektet kunde inte valideras");
                ex.Data.Add("ValidationResults", validationresults);
                throw ex;
            }
            if (starring.StarringID == 0)
            {
                StarringDAL.InsertStarring(starring);
            }
            else
            {
                StarringDAL.UpdateCharacter(starring);
            }
        }

        public static void DeleteStarring(Starring starring)
        {
            DeleteStarring(starring.StarringID);
        }

        public static void DeleteStarring(int starringId)
        {
            StarringDAL.DeleteStarring(starringId);
        }

        public static IEnumerable<StarringActor> GetMovieCharacters(int movieId)
        {
            return StarringDAL.GetMovieRoles(movieId);
        }

        public static Starring GetCharacter(int starringId)
        {
            return StarringDAL.GetCharacterById(starringId);
        }
    }
}