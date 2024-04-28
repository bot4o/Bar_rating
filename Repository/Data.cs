using Bar_rating.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using System;

namespace Bar_rating.Repository
{
    public class Data : IData
    {
        private readonly IConfiguration configuration;
        private readonly string dbcon = "";
        private readonly IWebHostEnvironment webhost;

        public Data(IConfiguration configuration, IWebHostEnvironment webhost)
        {
            this.configuration = configuration;
            dbcon = this.configuration.GetConnectionString("ApplicationDbContextConnection");
            this.webhost = webhost;
        }
        public bool DeleteMember(string id)
        {
            bool isDeleted = false;
            SqlConnection con = GetSqlConnection();
            try
            {
                con.Open();
                string qry = String.Format($"DELETE FROM AspNetUsers WHERE Id = '{id}'" );
                SqlDataReader reader = GetData(qry, con); 
                isDeleted = SaveData(qry, con);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return isDeleted;
        }
        public List<Member> GetAllMembers()
        {
            List<Member> drivers = new List<Member>();
            Member dr;
            SqlConnection con = GetSqlConnection();
            try
            {
                con.Open();
                string qry = "Select * from dbo.AspNetUsers;";
                SqlDataReader reader = GetData(qry, con);
                while (reader.Read())
                {
                    dr = new Member();
                    dr.Id = reader["ID"].ToString();
                    dr.UserName = reader["UserName"].ToString();
                    dr.PasswordHash = reader["PasswordHash"].ToString();
                    dr.Email = reader["Email"].ToString();
                    drivers.Add(dr);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            return drivers;
        }
        private SqlDataReader GetData(string qry, SqlConnection con)
        {
            SqlDataReader reader = null;
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                reader = cmd.ExecuteReader();
            }
            catch (Exception)
            {
                throw;
            }
            return reader;
        }
        private SqlConnection GetSqlConnection()
        {
            return new SqlConnection(dbcon);
        }


        private bool SaveData(string qry, SqlConnection con)
        {
            bool isSaved = false;
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.ExecuteNonQuery();
                isSaved = true;
            }
            catch (Exception)
            {
                throw;
            }
            return isSaved;
        }

    }
}
