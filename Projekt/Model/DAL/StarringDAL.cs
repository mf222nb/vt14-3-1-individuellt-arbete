using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projekt.Model.DAL
{
    public class StarringDAL : DALBase
    {
        //Tar bort en roll
        public void DeleteStarring(int starringID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteStarring", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StarringID", SqlDbType.Int, 4).Value = starringID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured while removing a actor from the database.");
                }
            }
        }

        //Lägger till en roll
        public void InsertStarring(Starring starring)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_InsertStarring", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MovieID", SqlDbType.Int, 4).Value = starring.MovieID;
                    cmd.Parameters.Add("@ActorID", SqlDbType.Int, 4).Value = starring.ActorID;
                    cmd.Parameters.Add("@Character", SqlDbType.NVarChar, 40).Value = starring.Character;

                    cmd.Parameters.Add("@StarringID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    starring.StarringID = (int)cmd.Parameters["@StarringID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured while adding the actor/movie to the database.");
                }
            }
        }

        //Listar alla roller som är kopplade till någon film från databasen
        public IEnumerable<Starring> GetMovieRoles(int movieID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var roles = new List<Starring>(100);

                    var cmd = new SqlCommand("appSchema.usp_ListStarring", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MovieID", movieID);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var starringIdIndex = reader.GetOrdinal("StarringID");
                        var movieIdIndex = reader.GetOrdinal("MovieID");
                        var actorIdIndex = reader.GetOrdinal("ActorID");
                        var characterIndex = reader.GetOrdinal("Character");

                        while (reader.Read())
                        {
                            roles.Add(new Starring
                            {
                                StarringID = reader.GetInt32(starringIdIndex),
                                MovieID = reader.GetInt32(movieIdIndex),
                                ActorID = reader.GetInt32(actorIdIndex),
                                Character = reader.GetString(characterIndex)
                            });
                        }
                    }
                    roles.TrimExcess();

                    return roles;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting movies from the database.");
                }
            }
        }

        //Listar 1 roll
        public Starring GetCharacterById(int starringId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_ListOneCharacter", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@StarringID", starringId);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var starringIdIndex = reader.GetOrdinal("StarringID");
                        var movieIdIndex = reader.GetOrdinal("MovieID");
                        var actorIdIndex = reader.GetOrdinal("ActorID");
                        var characterIndex = reader.GetOrdinal("Character");

                        while (reader.Read())
                        {
                            return new Starring
                            {
                                StarringID = reader.GetInt32(starringIdIndex),
                                MovieID = reader.GetInt32(movieIdIndex),
                                ActorID = reader.GetInt32(actorIdIndex),
                                Character = reader.GetString(characterIndex)
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

        //Uppdatera en roll
        public void UpdateCharacter(Starring starring)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateCharacter", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StarringID", SqlDbType.Int, 4).Value = starring.StarringID;

                    cmd.Parameters.Add("@Character", SqlDbType.NVarChar, 40).Value = starring.Character;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured while updating a character in the database.");
                }
            }
        }
    }
}