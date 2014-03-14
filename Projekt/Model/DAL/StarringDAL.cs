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
        //Tar bort en roll genom att anropa en lagrad procedur som tittar på id:t och tar bort den rollen på endast det id
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

        //Lägger till en roll genom att anropa en lagrad procedur som skapar ett id och lägger till det användaren har skrivit in
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
                    cmd.Parameters.Add("@Character", SqlDbType.VarChar, 40).Value = starring.Character;

                    cmd.Parameters.Add("@StarringID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    starring.StarringID = (int)cmd.Parameters["@StarringID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured while adding the character to the database.");
                }
            }
        }

        //Listar alla roller som är kopplade till någon film från databasen
        public IEnumerable<StarringActor> GetMovieRoles(int movieID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var roles = new List<StarringActor>(100);

                    var cmd = new SqlCommand("appSchema.usp_ListStarring", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MovieID", SqlDbType.Int, 4).Value = movieID;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var starringIdIndex = reader.GetOrdinal("StarringID");
                        var movieIdIndex = reader.GetOrdinal("MovieID");
                        var actorIdIndex = reader.GetOrdinal("ActorID");
                        var characterIndex = reader.GetOrdinal("Character");
                        var actorNameIndex = reader.GetOrdinal("Actorname");

                        while (reader.Read())
                        {
                            roles.Add(new StarringActor
                            {
                                StarringID = reader.GetInt32(starringIdIndex),
                                MovieID = reader.GetInt32(movieIdIndex),
                                ActorID = reader.GetInt32(actorIdIndex),
                                Character = reader.GetString(characterIndex),
                                ActorName = reader.GetString(actorNameIndex)
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

        //Hämtar en roll genom att anropa en procedur som hämtar ett id och all annan information om den rollen
        public Starring GetCharacterById(int starringId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_ListOneCharacter", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StarringID", SqlDbType.Int, 4).Value = starringId;

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

        //Uppdatera en roll genom att anropa en procedur som hämtar id och uppdaterar det som som användaren har skrivit in på det id som är hämtat
        public void UpdateCharacter(Starring starring)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateCharacter", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@StarringID", SqlDbType.Int, 4).Value = starring.StarringID;
                    cmd.Parameters.Add("@ActorID", SqlDbType.Int, 4).Value = starring.ActorID;
                    cmd.Parameters.Add("@Character", SqlDbType.VarChar, 40).Value = starring.Character;

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