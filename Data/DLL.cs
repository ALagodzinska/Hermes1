using Entity;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Data
{
    public class DLL

    {
        //public List<Users> GetUser()
        //{
        //    string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    List<Users> users = new List<Users>();
        //    using (SqlConnection con = new SqlConnection(cs))
        //    {
        //        con.Open();
        //        SqlCommand get = new SqlCommand("GetUser", con);
        //        get.CommandType = CommandType.StoredProcedure;
        //        SqlDataReader dr = get.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            Users user = new Users();
        //            user.UserId = Convert.ToInt32(dr["UserId"]);
        //            user.UserName = dr["UserName"].ToString();
        //            user.Email = dr["Email"].ToString();
        //            user.Password = dr["Password"].ToString();
        //            users.Add(user);
        //        }

        //        return users;
        //    }
        //}
        public List<Users> GetUser()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.User.ToList();    
            }
        }
        public void CreateUser(Users users)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand create = new SqlCommand("CreateUser", con);
                create.CommandType = CommandType.StoredProcedure;
                create.Parameters.AddWithValue("@UserName", users.UserName);
                create.Parameters.AddWithValue("@Email", users.UserName);
                create.Parameters.AddWithValue("@Password", users.Password);

                create.ExecuteNonQuery();
            }
        }
        public void UpdateUser(Users users)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand update = new SqlCommand("UpdateUser", con);
                update.CommandType = CommandType.StoredProcedure;
                update.Parameters.AddWithValue("@UserId", users.UserId);
                update.Parameters.AddWithValue("@UserName", users.UserName);
                update.Parameters.AddWithValue("@UserName", users.UserName);
                update.Parameters.AddWithValue("@Password", users.Password);

                update.ExecuteNonQuery();
            }
        }
        public void DeleteUser(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand delete = new SqlCommand("DeleteUser", con);
                delete.CommandType = CommandType.StoredProcedure;
                delete.Parameters.AddWithValue("@UserId", id);
                delete.ExecuteNonQuery();
            }
        }

        public List<Room> GetRoom()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Room.ToList();
            }
        }

        public void CreateRoom(Room room)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand create = new SqlCommand("CreateRoom", con);
                create.CommandType = CommandType.StoredProcedure;
                create.Parameters.AddWithValue("@RoomName", room.RoomName);

                create.ExecuteNonQuery();
            }
        }

        public void DeleteRoom(int id)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand delete = new SqlCommand("DeleteRoom", con);
                delete.CommandType = CommandType.StoredProcedure;
                delete.Parameters.AddWithValue("@RoomId", id);
                delete.ExecuteNonQuery();
            }
        }
    }
}