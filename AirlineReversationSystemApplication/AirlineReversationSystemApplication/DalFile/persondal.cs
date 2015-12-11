using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace AirlineReversationSystemApplication
{


    class persondal
    {
        DBConnection objcon = new DBConnection();

        public Person getUserType(Person p1)
        {
            string userName = p1.UserName;
            string password = p1.Password;

            objcon.connection();

            SqlCommand cmd = new SqlCommand("Select * from Login_Details  where username= '" + userName + "' and password= '" + password + "'", objcon.con);
            //DataTable dt = new DataTable();
            SqlDataReader dr = cmd.ExecuteReader();
            //Console.WriteLine("username" + dr.GetString(0) + "Password" + dr.GetString(1));
            Person p = new Person();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    p.UserName = dr.GetString(0);
                    p.Password = dr.GetString(1);
                    p.Role = dr.GetString(2);
                    p.UserID = dr.GetInt32(5);
                    Console.WriteLine("username" + dr.GetString(0) + "Password" + dr.GetString(1));
                }


                return p;
            }
            return p;
        }


        public bool addLoginAirlineCarrier(Person p1)
        {
            string userName = p1.UserName;
            string password = p1.Password;
            string firstName = p1.FirstName;
            string lastName = p1.LastName;
            string emailID = p1.EmailID;
            string role = p1.Role;


            objcon.connection();
            string query1 = "Insert into AirLineCarrier_Details (UserName, FirstName, LastName, EmailID, Role, Password) values (@UserName, @FirstName, @LastName, @EmailID, @Role, @Password) ";
            using (SqlCommand cmd1 = new SqlCommand(query1, objcon.con))
            {
                
                //string username = p.UserName.ToString();
                cmd1.Parameters.Add(new SqlParameter("@UserName", userName));
                //string firstname = p.FirstName.ToString();
                cmd1.Parameters.Add(new SqlParameter("@Firstname", firstName));
                //string lastname = p.LastName.ToString();
                cmd1.Parameters.Add(new SqlParameter("@LastName", lastName));
                //string emailid = p.EmailID.ToString();
                cmd1.Parameters.Add(new SqlParameter("@EmailID", emailID));
                //string Password = p.Password.ToString();
                cmd1.Parameters.Add(new SqlParameter("@Password", password));
                //string Role = p.Role.ToString();
                cmd1.Parameters.Add(new SqlParameter("@Role", role));
                int result = cmd1.ExecuteNonQuery();
                return result != 0;
            }
            


        }

        public bool addLoginCustomer(Person p1)
        {
            string userName = p1.UserName;
            string password = p1.Password;
            string firstName = p1.FirstName;
            string lastName = p1.LastName;
            string emailID = p1.EmailID;
            string role = p1.Role;

            objcon.connection();
            string query = "Insert into Login_Details (UserName, FirstName, LastName, EmailID, Role, Password) values (@UserName, @FirstName, @LastName, @EmailID, @Role, @Password)";
            SqlCommand cmd2 = new SqlCommand(query, objcon.con);
           
                   // string username = p.UserName.ToString();
                    cmd2.Parameters.AddWithValue("@UserName", userName);
                   // string firstname = p.FirstName.ToString();
                    cmd2.Parameters.AddWithValue("@Firstname", firstName);
                   // string lastname = p.LastName.ToString();
                    cmd2.Parameters.AddWithValue("@LastName", lastName);
                   // string emailid = p.EmailID.ToString();
                    cmd2.Parameters.AddWithValue("@EmailID", emailID);
                   // string Password = p.Password.ToString();
                    cmd2.Parameters.AddWithValue("@Password", password);
                    //string Role = p.Role.ToString();
                    cmd2.Parameters.AddWithValue("@Role", role);
                   int result = cmd2.ExecuteNonQuery();
            return result != 0;
                }


        public List<Person> getAirlineCarrierLoginDetails()
        {
            objcon.connection();
            List<Person> personlist = new List<Person>();
            SqlCommand cmd = new SqlCommand("Select * from AirLineCarrier_Details", objcon.con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Person p = new Person();
                
                p.UserName = dr.GetString(0);
                p.Password = dr.GetString(1);
                p.Role = dr.GetString(2);
                p.FirstName = dr.GetString(3);
                p.LastName = dr.GetString(4);
                p.UserID = dr.GetInt32(5);
                p.EmailID = dr.GetString(6);

                personlist.Add(p);

            }
            return personlist;
        }

        public bool acceptAirlineCarrierLogin(Person p1)
        {
            int userID = p1.UserID;
            string userName = p1.UserName;
            string password = p1.Password;
            string firstName = p1.FirstName;
            string lastName = p1.LastName;
            string emailID = p1.EmailID;
            string role = p1.Role;

            objcon.connection();
            string Query = "Insert into Login_Details (UserName, FirstName, LastName, EmailID, Role, Password) values (@UserName, @FirstName, @LastName, @EmailID, @Role, @Password)";
            SqlCommand cmd = new SqlCommand(Query, objcon.con);

            //string username = ((DataRowView)dataGrid.SelectedItem).Row["UserName"].ToString();
            cmd.Parameters.AddWithValue("UserName", userName);
            //string firstname = ((DataRowView)dataGrid.SelectedItem).Row["FirstName"].ToString();
            cmd.Parameters.AddWithValue("FirstName", firstName);
            // lastname = ((DataRowView)dataGrid.SelectedItem).Row["LastName"].ToString();
            cmd.Parameters.AddWithValue("LastName", lastName);
            // emailID = ((DataRowView)dataGrid.SelectedItem).Row["EmailID"].ToString();
            cmd.Parameters.AddWithValue("EmailID", emailID);
            //string role = ((DataRowView)dataGrid.SelectedItem).Row["Role"].ToString();
            cmd.Parameters.AddWithValue("Role", role);
            //string password = ((DataRowView)dataGrid.SelectedItem).Row["Password"].ToString();
            cmd.Parameters.AddWithValue("Password", password);

            //cmd.ExecuteNonQuery();
            int result =
            cmd.ExecuteNonQuery();
           return result != 0;
        }
        
        public bool rejectAirlineCarrierLogin(Person p1)
        {
            int userID = p1.UserID;
            string userName = p1.UserName;
            string password = p1.Password;
            string firstName = p1.FirstName;
            string lastName = p1.LastName;
            string emailID = p1.EmailID;
            string role = p1.Role;

            string Query = "DELETE FROM AirLineCarrier_Details WHERE UserID=" + userID + "";
            SqlCommand cmd = new SqlCommand(Query, objcon.con);
           // cmd.ExecuteNonQuery();
            int result =
            cmd.ExecuteNonQuery();
            return result != 0;
        }

        // Flight Crew

        public bool addLoginFlightCrew(Person p1)
        {
            string userName = p1.UserName;
            string password = p1.Password;
            string firstName = p1.FirstName;
            string lastName = p1.LastName;
            string emailID = p1.EmailID;
            string role = p1.Role;


            objcon.connection();
            string query1 = "Insert into AirLineCarrier_Details (UserName, FirstName, LastName, EmailID, Role, Password) values (@UserName, @FirstName, @LastName, @EmailID, @Role, @Password) ";
            using (SqlCommand cmd1 = new SqlCommand(query1, objcon.con))
            {

                //string username = p.UserName.ToString();
                cmd1.Parameters.Add(new SqlParameter("@UserName", userName));
                //string firstname = p.FirstName.ToString();
                cmd1.Parameters.Add(new SqlParameter("@Firstname", firstName));
                //string lastname = p.LastName.ToString();
                cmd1.Parameters.Add(new SqlParameter("@LastName", lastName));
                //string emailid = p.EmailID.ToString();
                cmd1.Parameters.Add(new SqlParameter("@EmailID", emailID));
                //string Password = p.Password.ToString();
                cmd1.Parameters.Add(new SqlParameter("@Password", password));
                //string Role = p.Role.ToString();
                cmd1.Parameters.Add(new SqlParameter("@Role", role));
                int result = cmd1.ExecuteNonQuery();
                return result != 0;
            }



        }

        public bool checkifusernameexist(Person p1)
        {
           
                string userName = p1.UserName;
                //string emailID = p1.EmailID;
                objcon.connection();
                string query1 = "Select * from Login_Details where UserName =@UserName";
                SqlCommand cmd1 = new SqlCommand(query1, objcon.con);
                cmd1.Parameters.AddWithValue("@UserName", userName);
                // cmd1.Parameters.AddWithValue("@EmailID", emailID);
                SqlDataReader dr =  cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
            
            
        }

    }

}

