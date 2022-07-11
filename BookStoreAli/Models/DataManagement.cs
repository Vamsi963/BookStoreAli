using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookStoreAli.Models
{

    public class DataManagement
    {
        SqlConnection con = new SqlConnection(@"Data Source = DESKTOP-THUOFTE\SQLEXPRESS; Initial Catalog = MVCFramework; Integrated Security=true; ");


        public bool CheckIfUserExists(User user)
        {
            int count = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("sp_UserCount", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", user.Name);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                con.Open();
                count = Convert.ToInt32( cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }



            return count > 0;
        }

        public bool Register(User user)
        {
            int count = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("sp_InsertUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", user.Name);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                con.Open();
                count = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }



            return count > 0;
        }





    }
}