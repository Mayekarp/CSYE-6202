using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AirlineReversationSystemApplication
{
    class airlinedal
    {
        DBConnection objcon = new DBConnection();
        public bool addFlightAirlineCarrier(AirlineCarrier ac1, Person p)
        {
            string airLineName = ac1.AirLineName;
            string flightNo = ac1.FlightNo;
            string departureTime = ac1.DepartureTime;
            string arrivalTime = ac1.ArrivalTime;
            string date = ac1.Dates;
            string originCity = ac1.OriginCity;
            string destinationCity = ac1.DestinationCity;
            string seat = ac1.Seat;
            int userID = p.UserID;
            string userName = p.UserName;

            objcon.connection();
            string query = "Insert into AirlineFlightDetails (AirlineName, FlightNo, Departmenttime, Arrivaltime, Dates,  OriginCity, DestinationCity, Seat, UserID, UserName) values (@AirlineName, @FlightNo, @Departmenttime, @ArrivalTime, @Dates, @OriginCity, @DestinationCity, @Seat, @UserID, @UserName)";
            SqlCommand cmd = new SqlCommand(query, objcon.con);
            cmd.Parameters.AddWithValue("@AirlineName", airLineName);
            cmd.Parameters.AddWithValue("@FlightNo", flightNo);
            cmd.Parameters.AddWithValue("@Departmenttime", departureTime);
            cmd.Parameters.AddWithValue("@Arrivaltime", arrivalTime);
            cmd.Parameters.AddWithValue("@Dates", date);
            cmd.Parameters.AddWithValue("@OriginCity", originCity);
            cmd.Parameters.AddWithValue("@DestinationCity", destinationCity);
            cmd.Parameters.AddWithValue("@Seat", seat);
            cmd.Parameters.AddWithValue("@UserID", userID);
            cmd.Parameters.AddWithValue("@UserName", p.UserName);
            //cmd.ExecuteNonQuery();
            int result = cmd.ExecuteNonQuery();
            return result != 0;
        }


        public bool RemoveFlightAirlineCarrier(AirlineCarrier ac1)
        {
            int airlineID = ac1.AirLineID;
            objcon.connection();
            string sql = string.Format("Delete from AirlineFlightDetails where AirLineID = '" + airlineID + "'");
            SqlCommand cmd = new SqlCommand(sql, objcon.con);
            //cmd.ExecuteNonQuery();
            int result =
            cmd.ExecuteNonQuery();
            return result != 0;
        }

        public bool UpdateFlightAirlineCarrier(AirlineCarrier ac)
        {
            int airlineID = ac.AirLineID;
            string airLineName = ac.AirLineName;
            string flightNo = ac.FlightNo;
            string departureTime = ac.DepartureTime;
            string arrivalTime = ac.ArrivalTime;
            string date = ac.Dates;
            string originCity = ac.OriginCity;
            string destinationCity = ac.DestinationCity;
            string seat = ac.Seat;
            objcon.connection();
            string sql = string.Format("Update AirlineFlightDetails set AirlineName =@AirlineName, FlightNo =@FlightNo, Arrivaltime =@Arrivaltime, Departmenttime =@Departmenttime, Dates =@Dates, OriginCity =@OriginCity, Destinationcity =@DestinationCity, Seat =@Seat where AirlineID = '"+airlineID+"'");

            SqlCommand cmd = new SqlCommand(sql, objcon.con);
            cmd.Parameters.AddWithValue("@AirlineName", airLineName);
            cmd.Parameters.AddWithValue("@FlightNo", flightNo);
            cmd.Parameters.AddWithValue("@Departmenttime", departureTime);
            cmd.Parameters.AddWithValue("@Arrivaltime", arrivalTime);
            cmd.Parameters.AddWithValue("@Dates", date);
            cmd.Parameters.AddWithValue("@OriginCity", originCity);
            cmd.Parameters.AddWithValue("@DestinationCity", destinationCity);
            cmd.Parameters.AddWithValue("@Seat", seat);
            //cmd.Parameters.AddWithValue("@AirlineID", airlineID);
            //cmd.ExecuteNonQuery();
            int result =
            cmd.ExecuteNonQuery();
            return result != 0;
        }

        public List<AirlineCarrier> getAirlineCarrierFlightDetails(Person p)
        {

            int userid = p.UserID;
            string userName = p.UserName;

            objcon.connection();
            List<AirlineCarrier> airlinelist = new List<AirlineCarrier>();
            SqlCommand cmd = new SqlCommand("Select * from AirlineFlightDetails where UserID = '"+userid+"'", objcon.con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                AirlineCarrier ac = new AirlineCarrier();

                ac.AirLineName = dr.GetString(0);
                ac.FlightNo = dr.GetString(1);
                ac.Dates = dr.GetDateTime(2).ToString("yyyy-MM-dd");
                ac.OriginCity = dr.GetString(3);
                ac.DestinationCity = dr.GetString(4);
                ac.AirLineID = dr.GetInt32(5);
                ac.ArrivalTime = dr.GetString(6);
                ac.DepartureTime = dr.GetString(7);
                ac.Seat = dr.GetInt32(8).ToString();
                ac.UserName = dr.GetString(9);
                ac.UserID = dr.GetInt32(10);

                airlinelist.Add(ac);

                
            }
            return airlinelist;
        }
    }
}
