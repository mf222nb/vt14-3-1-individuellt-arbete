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
        //Tar bort en film genom att anropa en lagrad procedur som tittar på id:t och tar bort endast den filmen på det id
        public void DeleteMovie(int movieID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteMovie", conn);
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

        //Hämtar ut information om en specifik film genom att titta på id:t och hämtar ut all information som finns på det id
        public Movie GetMovieById(int movieID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_ListOneMovie", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MovieID", SqlDbType.Int, 4).Value = movieID;

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

        //Hämtar ut alla filmer som finns i databasen genom att anropa en procedur som hämtar all data som finns på alla id:n som finns
        public IEnumerable<Movie> GetMovies()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var movies = new List<Movie>(100);

                    var cmd = new SqlCommand("appSchema.usp_ListMovies", conn);
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
                    throw new ApplicationException("An error occured while getting movies from the database.");
                }
            }
        }

        //Lägger till en film genom att anropa en lagrad procedur som skapar ett id och lägger till det användaren har skrivit in
        public void InsertMovie(Movie movie)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_InsertMovie", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Titel", SqlDbType.VarChar, 50).Value = movie.Titel;
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

        //Uppdatera en film genom att anropa en procedur som hämtar id och uppdaterar det som som användaren har skrivit in på det id som är hämtat
        public void UpdateMovie(Movie movie)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateMovie", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MovieID", SqlDbType.Int, 4).Value = movie.MovieID;

                    cmd.Parameters.Add("@Titel", SqlDbType.VarChar, 50).Value = movie.Titel;
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

        //Hämtar ut alla filmer som finns i databasen genom att anropa en procedur som hämtar all data som finns på alla id:n som finns
        public IEnumerable<Movie> GetMoviesPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var movies = new List<Movie>(100);

                    var cmd = new SqlCommand("appSchema.usp_ListMoviesPageWise", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Start", SqlDbType.Int, 4).Value = startRowIndex;
                    cmd.Parameters.Add("@Rows", SqlDbType.Int, 4).Value = maximumRows;

                    cmd.Parameters.Add("@Total", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

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
                    totalRowCount = (int)cmd.Parameters["@Total"].Value;

                    movies.TrimExcess();

                    return movies;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting movies from the database.");
                }
            }
        }
    }
}