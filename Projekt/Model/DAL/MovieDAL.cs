using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projekt.Model.DAL
{
    public class MovieDAL : DALBase
    {
        //Raderar en film
        public void DeleteMovie(int movieID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspRemoveContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MovieID", SqlDbType.Int, 4).Value = movieID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured while removing a movie from the database.");
                }
            }
        }

        //Hämtar ut information om en specifik film
        public Movie GetMovieById(int movieID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspGetContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MovieID", movieID);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var movieIdIndex = reader.GetOrdinal("MovieID");
                        var titelIndex = reader.GetOrdinal("Titel");
                        var lengthIndex = reader.GetOrdinal("Length");

                        while (reader.Read())
                        {
                            return new Movie
                            {
                                MovieID = reader.GetInt32(movieIdIndex),
                                Titel = reader.GetString(titelIndex),
                                Length = reader.GetByte(lengthIndex)
                            };
                        }
                    }


                    return null;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        //Hämtar ut alla filmer som finns i databasen
        public IEnumerable<Movie> GetMovies()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var movies = new List<Movie>(100);


                    var cmd = new SqlCommand("Person.uspGetContacts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var movieIdIndex = reader.GetOrdinal("MovieID");
                        var titelIndex = reader.GetOrdinal("Titel");
                        var lengthIndex = reader.GetOrdinal("Length");

                        while (reader.Read())
                        {
                            movies.Add(new Movie
                            {
                                MovieID = reader.GetInt32(movieIdIndex),
                                Titel = reader.GetString(titelIndex),
                                Length = reader.GetByte(lengthIndex)
                            });
                        }
                    }
                    movies.TrimExcess();


                    return movies;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting ccontacts from the database.");
                }
            }
        }

        //Lägger till en film
        public void InsertMovie(Movie movie)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspAddContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Titel", SqlDbType.NVarChar, 50).Value = movie.Titel;
                    cmd.Parameters.Add("@Length", SqlDbType.TinyInt).Value = movie.Length;

                    cmd.Parameters.Add("@MovieID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    movie.MovieID = (int)cmd.Parameters["@MovieID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured while adding the movie to the database.");
                }
            }
        }

        //Uppdaterar en film
        public void UpdateMovie(Movie movie)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspUpdateContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MovieID", SqlDbType.Int, 4).Value = movie.MovieID;

                    cmd.Parameters.Add("@Titel", SqlDbType.NVarChar, 50).Value = movie.Titel;
                    cmd.Parameters.Add("@Length", SqlDbType.TinyInt).Value = movie.Length;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured while updating a movie in the database.");
                }
            }
        }
    }
}