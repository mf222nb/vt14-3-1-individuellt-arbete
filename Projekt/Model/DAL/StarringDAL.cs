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
    }
}