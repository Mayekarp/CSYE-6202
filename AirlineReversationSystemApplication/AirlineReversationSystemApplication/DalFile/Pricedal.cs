using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AirlineReversationSystemApplication
{
    
    class Pricedal
    {
        DBConnection objcon = new DBConnection();
        public bool addprice(Person p1, AirlineCarrier ac, Economy ec, EconomyPlus ecp, BusinessClass bc, Price pr)
          
        {
            int airlineID = getAirlineID(ac, p1);
            string flightNo = ac.FlightNo;
            string seat = ac.Seat;
            string airlineName = ac.AirLineName;
            string userName = p1.UserName;
            int UserID = p1.UserID;
            
            String ep =  ec.calculatepricedelegate();
            int EconomyClassprice = Convert.ToInt16(ep);
            String cp = ecp.calculatepricedelegate();
            int EconomyPlusClassprice = Convert.ToInt16(cp);
            String bp = bc.calculatepricedelegate();
            int BusinessClassprice = Convert.ToInt16(bp);

            

        objcon.connection();
            string Query = "Insert into FlightPrice (UserName,AirlineName,FlightNo,Seat,EconomyClassPrice,EconomyPlusClassPrice,BusinessClassPrice,AirlineID, UserID) values (@UserName,@AirlineName,@FlightNo,@Seat,@EconomyClassPrice,@EconomyPlusClassPrice,@BusinessClassPrice,@AirlineID, @UserID)";
            SqlCommand cmd = new SqlCommand(Query, objcon.con);

            //string username = ((DataRowView)dataGrid.SelectedItem).Row["UserName"].ToString();
            cmd.Parameters.AddWithValue("@UserName", userName);
            //string firstname = ((DataRowView)dataGrid.SelectedItem).Row["FirstName"].ToString();
            cmd.Parameters.AddWithValue("@FlightNo", flightNo);
            // lastname = ((DataRowView)dataGrid.SelectedItem).Row["LastName"].ToString();
            cmd.Parameters.AddWithValue("@AirlineName", airlineName);
            cmd.Parameters.AddWithValue("@AirlineID", airlineID);
            // emailID = ((DataRowView)dataGrid.SelectedItem).Row["EmailID"].ToString();
            cmd.Parameters.AddWithValue("@Seat", seat);
            //string role = ((DataRowView)dataGrid.SelectedItem).Row["Role"].ToString();
            cmd.Parameters.AddWithValue("@EconomyClassPrice", EconomyClassprice);
            //string password = ((DataRowView)dataGrid.SelectedItem).Row["Password"].ToString();
            cmd.Parameters.AddWithValue("@EconomyPlusClassPrice", EconomyPlusClassprice);
            cmd.Parameters.AddWithValue("@BusinessClassPrice", BusinessClassprice);
            
            cmd.Parameters.AddWithValue("@UserID", UserID);

            //cmd.ExecuteNonQuery();
            int result =
            cmd.ExecuteNonQuery();
            return result != 0;
        }

        public int getAirlineID(AirlineCarrier ac, Person p1)
        {
            int airlineID = ac.AirLineID;
            string flightNo = ac.FlightNo;
            int userID = p1.UserID;
            objcon.connection();
            string query = "Select AirlineID from AirlineFlightDetails where FlightNo =@FlightNo and UserID =@UserID";
            SqlCommand cmd = new SqlCommand(query, objcon.con);
            //cmd.Parameters.Add()
            cmd.Parameters.AddWithValue("@FlightNo", flightNo);
            cmd.Parameters.AddWithValue("@UserID", userID);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
    }
}
