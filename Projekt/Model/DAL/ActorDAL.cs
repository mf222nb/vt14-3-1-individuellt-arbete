using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Projekt.Model.DAL
{
    public class ActorDAL : DALBase
    {
        //Tar bort en skådespelare
        public void DeleteActor(int actorID)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspRemoveContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActorID", SqlDbType.Int, 4).Value = actorID;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured while removing a actor from the database.");
                }
            }
        }

        //Hämtar ut alla skådespelare som är för en specifik film
        public IEnumerable<Actor> GetMovieActorById(int movieID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var actors = new List<Actor>(10);

                    var cmd = new SqlCommand("Person.uspGetContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MovieID", movieID);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var actorIdIndex = reader.GetOrdinal("ActorID");
                        var firstNameIndex = reader.GetOrdinal("FirstName");
                        var lastNameIndex = reader.GetOrdinal("LastName");
                        var bornIndex = reader.GetOrdinal("Born");

                        while (reader.Read())
                        {
                            actors.Add(new Actor
                            {
                                ActorID = reader.GetInt32(actorIdIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                Born = reader.GetString(bornIndex)
                            });
                        }
                    }
                    actors.TrimExcess();

                    return actors;
                }
                catch
                {
                    throw new ApplicationException("An error occured in the data access layer.");
                }
            }
        }

        //Hämtar ut alla skådespelare från databasen
        public IEnumerable<Actor> GetActors()
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var actors = new List<Actor>(50);


                    var cmd = new SqlCommand("Person.uspGetContacts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var actorIdIndex = reader.GetOrdinal("ActorID");
                        var firstNameIndex = reader.GetOrdinal("Firstname");
                        var lastNameIndex = reader.GetOrdinal("Lastname");
                        var bornIndex = reader.GetOrdinal("Born");

                        while (reader.Read())
                        {
                            actors.Add(new Actor
                            {
                                ActorID = reader.GetInt32(actorIdIndex),
                                FirstName = reader.GetString(firstNameIndex),
                                LastName = reader.GetString(lastNameIndex),
                                Born = reader.GetString(bornIndex)
                            });
                        }
                    }
                    actors.TrimExcess();


                    return actors;
                }
                catch
                {
                    throw new ApplicationException("An error occured while getting actors from the database.");
                }
            }
        }

        //Lägger till en skådespelare
        public void InsertActor(Actor actor)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspAddContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20).Value = actor.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 25).Value = actor.LastName;
                    cmd.Parameters.Add("@Born", SqlDbType.NVarChar, 10).Value = actor.Born;

                    cmd.Parameters.Add("@ActorID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    actor.ActorID = (int)cmd.Parameters["@ActorID"].Value;
                }
                catch
                {
                    throw new ApplicationException("An error occured while adding the actor to the database.");
                }
            }
        }

        //Uppdaterar en befintlig skådespelare
        public void UpdateActor(Actor actor)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspUpdateContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActorID", SqlDbType.Int, 4).Value = actor.ActorID;

                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 20).Value = actor.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 25).Value = actor.LastName;
                    cmd.Parameters.Add("@Born", SqlDbType.NVarChar, 10).Value = actor.Born;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {
                    throw new ApplicationException("An error occured while updating a actor in the database.");
                }
            }
        }
    }
}