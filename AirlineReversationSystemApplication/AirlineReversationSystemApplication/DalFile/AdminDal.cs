using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AirlineReversationSystemApplication
{
    class AdminDal
    {
        DBConnection objcon = new DBConnection();
        public List<CustomerBookings> getCustomerBookingDetaols()
        {

            objcon.connection();
            List<CustomerBookings> customerBookinglist = new List<CustomerBookings>();
            SqlCommand cmd = new SqlCommand("Select * from CustomerBookings ", objcon.con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                CustomerBookings cb = new CustomerBookings();
                cb.BookingID = dr.GetInt32(0);
                cb.CustomerUserID = dr.GetInt32(1);
                cb.AirlineID = dr.GetInt32(2);
                cb.UserName = dr.GetString(3);
                cb.EmailID = dr.GetString(4);
                cb.Dates = dr.GetString(5); 
                cb.OriginCity = dr.GetString(6);
                cb.DestinationCity = dr.GetString(7);
                cb.AirLineName = dr.GetString(8);
                cb.Arrivaltime = dr.GetString(9);
                cb.Departuretime = dr.GetString(10);
                cb.ClassType = dr.GetString(11);
                string pass = dr.GetString(12);
                cb.Passenger = Convert.ToInt32(pass);
                string price = dr.GetString(13);
                cb.Price = Convert.ToInt32(price);
                //string seat = dr.GetString(14);
                cb.CardDetails = dr.GetString(14);
                cb.CVV = dr.GetString(15);
                cb.Month = dr.GetString(16);
                cb.FlightNo = dr.GetString(17);

                customerBookinglist.Add(cb);


            }
            return customerBookinglist;
        }

        public bool UpdateCustomerBookings(CustomerBookings cb)
        {
            
            int BookingID = cb.BookingID;
            string airLineName = cb.AirLineName;
            string flightNo = cb.FlightNo;
            string departureTime = cb.Departuretime;
            string arrivalTime = cb.Arrivaltime;
            string date = cb.Dates;
            string originCity = cb.OriginCity;
            string destinationCity = cb.DestinationCity;
            string EmailID = cb.EmailID;
            objcon.connection();
            string sql = string.Format("Update CustomerBookings set AirlineName =@AirlineName, FlightNo =@FlightNo, ArrivalTime =@Arrivaltime, DepartureTime =@Departmenttime, Dates =@Dates, OriginCity =@OriginCity, Destinationcity =@DestinationCity, EmailID = @EmailID where BookingID = '" + BookingID + "'");

            SqlCommand cmd = new SqlCommand(sql, objcon.con);
            cmd.Parameters.AddWithValue("@AirlineName", airLineName);
            cmd.Parameters.AddWithValue("@FlightNo", flightNo);
            cmd.Parameters.AddWithValue("@Departmenttime", departureTime);
            cmd.Parameters.AddWithValue("@Arrivaltime", arrivalTime);
            cmd.Parameters.AddWithValue("@Dates", date);
            cmd.Parameters.AddWithValue("@OriginCity", originCity);
            cmd.Parameters.AddWithValue("@DestinationCity", destinationCity);
            cmd.Parameters.AddWithValue("@EmailID", EmailID);
            //cmd.Parameters.AddWithValue("@AirlineID", airlineID);
            //cmd.ExecuteNonQuery();
            int result =
            cmd.ExecuteNonQuery();
            return result != 0;
        }

        public bool RemoveCustomerBookings(CustomerBookings cb)
        {
            
            int BookingID = cb.BookingID;
            objcon.connection();
            string sql = string.Format("Delete from CustomerBookings where BookingID = '" + BookingID + "'");
            SqlCommand cmd = new SqlCommand(sql, objcon.con);
            //cmd.ExecuteNonQuery();
            int result =
            cmd.ExecuteNonQuery();
            return result != 0;
        }

        public bool checkifEmailexist(CustomerBookings cb)
        {
            //string userName = p1.UserName;
            string emailID = cb.EmailID;
            objcon.connection();
            string query1 = "Select * from CustomerBookings where  EmailID =@EmailId";
            SqlCommand cmd1 = new SqlCommand(query1, objcon.con);
            //cmd1.Parameters.AddWithValue("@UserName", userName);
            cmd1.Parameters.AddWithValue("@EmailID", emailID);
            int result = cmd1.ExecuteNonQuery();
            return result != 0;
        }

    }
}
