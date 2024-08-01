using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;

namespace Session4.Models
{
    public class Users
    {
        public int id {  get; set; }
        public string name {  get; set; }   
        public string email {  get; set; }   
        public string password {  get; set; }   
        public int role {  get; set; }   
    

    public List<Users> GetAllUsers()
    {
        DBACESS db = new DBACESS();
        db.OpenCon();
        List<Users> records = new List<Users>();
        string q = "select * from USERS";
        db.cmd = new SqlCommand(q, db.con);
        SqlDataReader sdr = db.cmd.ExecuteReader();
        while (sdr.Read())
        {
            Users users = new Users();
            users.id = int.Parse(sdr["ID"].ToString());
            users.name = sdr["NAME"].ToString();
            users.email = sdr["EMAIL"].ToString();
            users.password = sdr["PASSWORD"].ToString();
            users.role = int.Parse(sdr["ROLE"].ToString());

            records.Add(users);
        }
        db.CloseCon();
        sdr.Close();
        return records;
    }
            public List<Users> SearchUser(string search)
           {
            DBACESS db = new DBACESS();
            db.OpenCon();
            List<Users> records = new List<Users>();
            string q = "select * from USERS where NAME like '%"+search+"%'";
            db.cmd = new SqlCommand(q, db.con);
            SqlDataReader sdr = db.cmd.ExecuteReader();
            while (sdr.Read())
            {
                Users users = new Users();
                users.id = int.Parse(sdr["ID"].ToString()) ;
                users.name = sdr["NAME"].ToString();
                users.email = sdr["EMAIL"].ToString();
                users.password = sdr["PASSWORD"].ToString();
                users.role = int.Parse(sdr["ROLE"].ToString());

                records.Add(users);
            }
            db.CloseCon();
            sdr.Close();
            return records;
        }
        public Users Detials(int id)
        {
            DBACESS db = new DBACESS();
            db.OpenCon();
            Users users = new Users() ;
            string q = "select * from USERS where id ='"+id+"'";
            db.cmd = new SqlCommand(q, db.con);
            SqlDataReader sdr = db.cmd.ExecuteReader();
            sdr.Read();
                users.id = int.Parse(sdr["ID"].ToString());
                users.name = sdr["NAME"].ToString();
                users.email = sdr["EMAIL"].ToString();
                users.password = sdr["PASSWORD"].ToString();
                users.role = int.Parse(sdr["ROLE"].ToString());

            db.CloseCon();
            sdr.Close();
            return users;
        }
    }
}