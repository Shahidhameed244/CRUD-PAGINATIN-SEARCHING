using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Session4.Models
{
    public class DBACESS
    {
        public static string connection = @"Data Source=DESKTOP-44PAKFG\MSSQLSERVER02; initial catalog=CRUD;integrated Security=true";
        public SqlConnection con = new SqlConnection(connection);
        public SqlCommand cmd = null;
        public void OpenCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void CloseCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public void InsertUpdateDelete(string query)
        {
            OpenCon();
            cmd = new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            CloseCon();
        }
    }
}