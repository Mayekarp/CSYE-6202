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
    class Customerdal
    {
        DBConnection objcon = new DBConnection();
        public List<ShowFlightDetails> showflightdetails(AirlineCarrier ac1)
        {
            //string flightNo = ac1.FlightNo;
            string date = ac1.Dates;
            string originCity = ac1.OriginCity;
            string destinationCity = ac1.DestinationCity;
            //string airLineName = ac1.AirLineName;
            //string arrivaltime = ac1.ArrivalTime;
            //string departuretime = ac1.DepartureTime;
            
            List<ShowFlightDetails> showflightList = new List<ShowFlightDetails>();
           
            objcon.connection();

            SqlCommand cmd = new SqlCommand("select af.Dates, af.OriginCity , af.DestinationCity, af.AirlineName, af.Arrivaltime, af.Departmenttime, fp.EconomyClassPrice, fp.EconomyPlusClassPrice, fp.BusinessClassPrice, af.AirlineID,af.FlightNo, af.Seat from AirlineFlightDetails as af Left Join FlightPrice as fp on af.AirlineID = fp.AirlineID  where  af.OriginCity like '%" + originCity + "%' and af.DestinationCity like '%" + destinationCity + "%' and af.Dates = '" + date + "'", objcon.con);
            Console.WriteLine(cmd);
            SqlDataReader dr = cmd.ExecuteReader();


            ShowFlightDetails sfd = new ShowFlightDetails();
            //AirlineCarrier ac = new AirlineCarrier();
            //Console.WriteLine("Ddr.hass rows ke pehle");
            if (dr.HasRows)
            {
               // Console.WriteLine("Ddr.hass rows ke andar");
                if (dr.Read())
                {

                  
                    sfd.Dates = dr.GetDateTime(0).ToString("yyyy-MM-dd");
                    sfd.OriginCity = dr.GetString(1);
                    sfd.DestinationCity = dr.GetString(2);
                    sfd.AirLineName = dr.GetString(3);
                    sfd.Arrivaltime = dr.GetString(4);
                    sfd.Departuretime = dr.GetString(5);
                    string ePrice = dr.GetString(6);
                    sfd.EconomyClassPrice = Convert.ToInt32(ePrice);
                    string ecPrice = dr.GetString(7);
                    sfd.EconomyPlusClassPrice = Convert.ToInt32(ecPrice);
                    string BPrice = dr.GetString(8);
                    sfd.BusinessClassPrice = Convert.ToInt32(BPrice);
                    sfd.AirlineID =  dr.GetInt32(9);
                    sfd.FlightNo = dr.GetString(10);
                    sfd.Seats = dr.GetInt32(11);


                    // Console.WriteLine("Ddr.read ke andar after");
                    showflightList.Add(sfd);


                }
                //Console.WriteLine("Ddr.hass rows ke andar after");
                return showflightList;
            }
           // Console.WriteLine("Ddr.hass rows ke pehle after");
            return showflightList;
        }

        public bool insertIntoCustomerBookings(CustomerBookings cb)
        {
            Random rnd = new Random();
            int BookingID = rnd.Next(1, 100);
            string emailID = cb.EmailID;
            string cardDetials = cb.CardDetails;
            string cvv = cb.CVV;
            string month = cb.Month;
            string userId = Convert.ToString(cb.CustomerUserID);
            string airlineId = Convert.ToString(cb.AirlineID);
            string userName = cb.UserName;
            string FlightNo = cb.FlightNo;
            string dates = cb.Dates;
            string originCity = cb.OriginCity;
            string destinationCity = cb.DestinationCity;
            string airlineName = cb.AirLineName;
            string arrivalTime = cb.Arrivaltime;
            string departureTime = cb.Departuretime;
            string classType = cb.ClassType;
            int passenger = cb.Passenger;
            int price = cb.Price;

            objcon.connection();

            //SqlCommand cmd = new SqlCommand("Insert into CustomerBookings (Dates, OriginCity, DestionationCity, ArrivalTime, DepartureTime, AirlineName, Passengers, Price ) values (@Dates, @OriginCity, @DestionationCity, @ArrivalTime, @DepartureTime, @AirlineName, @Passengers, @Price ) ", objcon.con);
            String query = "Insert into CustomerBookings (Dates,OriginCity,DestinationCity,AirlineName,ArrivalTime,DepartureTime,ClassType,Passenger,Price, BookingID, UserID, AirlineID,UserName,EmailID, CardDetails, CVV, Month,FlightNo) values (@Dates, @OriginCity, @DestinationCity, @AirlineName, @ArrivalTime, @DepartureTime, @ClassType, @Passenger, @Price,@BookingID,@UserID, @AirlineID,@UserName,@EmailID, @CardDetails, @CVV, @Month,@FlightNo)";
            SqlCommand cmd = new SqlCommand(query, objcon.con);
            cmd.Parameters.AddWithValue("@BookingID", BookingID);
            cmd.Parameters.AddWithValue("@EmailID", emailID);
            cmd.Parameters.AddWithValue("@CardDetails", cardDetials);
            cmd.Parameters.AddWithValue("@CVV", cvv);
            cmd.Parameters.AddWithValue("@Month", month);
            cmd.Parameters.AddWithValue("@UserID", userId);
            cmd.Parameters.AddWithValue("@AirlineID", airlineId);
            cmd.Parameters.AddWithValue("@UserName", userName);
            cmd.Parameters.AddWithValue("@FlightNo", FlightNo);
            cmd.Parameters.AddWithValue("@Dates", dates);
            cmd.Parameters.AddWithValue("@OriginCity", originCity);
            cmd.Parameters.AddWithValue("@DestinationCity", destinationCity);
            cmd.Parameters.AddWithValue("@AirlineName", airlineName);
            cmd.Parameters.AddWithValue("@ArrivalTime", arrivalTime);
            cmd.Parameters.AddWithValue("@DepartureTime", departureTime);
            cmd.Parameters.AddWithValue("@ClassType", classType);
            cmd.Parameters.AddWithValue("@Passenger", passenger);
            cmd.Parameters.AddWithValue("@Price", price);
            //SqlDataReader dr = cmd.ExecuteReader();
            int result = cmd.ExecuteNonQuery();
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

        public int getUpdateNewSeats(CustomerBookings cb)
        {
            int Oldseat = cb.Seats;
            int NoOfPassengers = cb.Passenger;

            int NewSeats = Oldseat - NoOfPassengers;
            return NewSeats;
        }

        public bool UpdateNewSeatsAirlineFlight(CustomerBookings cb)
        {

            int NewSeats = getUpdateNewSeats(cb);
            String FlightNo = cb.FlightNo;
            int AirlineID = cb.AirlineID;

            objcon.connection();
            string query = "Update AirlineFlightDetails set Seat =@NewSeats where AirlineID =@AirlineID and FlightNo = @FlightNo ";
            SqlCommand cmd = new SqlCommand(query, objcon.con);
            cmd.Parameters.AddWithValue("@NewSeats", NewSeats);
            cmd.Parameters.AddWithValue("@FlightNo", FlightNo);
            cmd.Parameters.AddWithValue("@AirlineID", AirlineID);
            int result = cmd.ExecuteNonQuery();
            return result != 0;
        }


       // DBConnection objcon = new DBConnection();
        public List<CustomerBookings> getCustomerBookingDetails()
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
                cb.CardDetails = dr.GetString(14);
                cb.CVV = dr.GetString(15);
                cb.Month = dr.GetString(16);
                cb.FlightNo = dr.GetString(17);

                customerBookinglist.Add(cb);


            }
            return customerBookinglist;
        }

        public bool UnbookCustomerBookings(CustomerBookings cb)
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


        public int getUnbookedSeats(CustomerBookings cb)
        {
            int Oldseat = cb.Seats;
            int NoOfPassengers = cb.Passenger;

            int UnbookSeats = Oldseat + NoOfPassengers;
            return UnbookSeats;
        }

        public bool UpdateUnbookSeatsAirlineFlight(CustomerBookings cb)
        {

            int UnbookSeats = getUnbookedSeats(cb);
            String FlightNo = cb.FlightNo;
            int AirlineID = cb.AirlineID;

            objcon.connection();
            string query = "Update AirlineFlightDetails set Seat = Seat + @NewSeats where AirlineID = '"+AirlineID+"' and FlightNo = '"+FlightNo+"' ";
            SqlCommand cmd = new SqlCommand(query, objcon.con);
            cmd.Parameters.AddWithValue("@NewSeats", UnbookSeats);
            //cmd.Parameters.AddWithValue("@FlightNo", FlightNo);
            //cmd.Parameters.AddWithValue("@AirlineID", AirlineID);
            int result = cmd.ExecuteNonQuery();
            return result != 0;
        }
    }
}
