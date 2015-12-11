using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace AirlineReversationSystemApplication
{
    /// <summary>
    /// Interaction logic for AddFlightAirlineCarrier.xaml
    /// </summary>
    public partial class AddFlightAirlineCarrier : Window
    {

        Person p;
        Pricedal pd = new Pricedal();
        public AddFlightAirlineCarrier(Person p)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            this.p = p;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
           // Pricedal pd = new Pricedal();

            AirlineCarrier ac = new AirlineCarrier();
            //ac.AirLineID = Convert.ToInt32(Airline_ID1.Text);
            Regex time = new Regex(@"^(?ni:(?=\d)((?'year'((1[6-9])|([2-9]\d))\d\d)(?'sep'[/.-])(?'month'0?[1-9]|1[012])\2(?'day'((?<!(\2((0?[2469])|11)\2))31)|(?<!\2(0?2)\2)(29|30)|((?<=((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(16|[2468][048]|[3579][26])00)\2\3\2)29)|((0?[1-9])|(1\d)|(2[0-8])))(?:(?=\x20\d)\x20|$))?((?<time>((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2}))?)$");
           // Regex regEmail = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            int distance;
            if (Airline_Company.Text == "" || int.TryParse(Airline_Company.Text, out distance) || Flight_No.Text == "" || Department_Time.Text == "" ||  Arrival_Time1.Text == "" || Origin_City1.SelectedValue.ToString() == "" || Destination_City1.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please fill all fields");
            }
            if (Department_Time.Text == "" || !time.IsMatch(Department_Time.Text) || Arrival_Time1.Text == "" || !time.IsMatch(Arrival_Time1.Text))
            {
                MessageBox.Show("Enter Correct Time");
            }
            else if (Origin_City1.SelectedValue.ToString() == Destination_City1.SelectedValue.ToString())
            {
                MessageBox.Show("Cannot Select Same City");
            }
            else if (Arrival_Time1.Text == Department_Time.Text)
            {
                MessageBox.Show("Cannot Select Same Time");
            }
         
            else
            {
                ac.AirLineName = Airline_Company.Text;
                ac.FlightNo = Flight_No.Text;
                ac.ArrivalTime = Arrival_Time1.Text;
                ac.DepartureTime = Department_Time.Text;
                ac.Dates = Date1.SelectedDate.ToString();
                ac.OriginCity = Origin_City1.SelectedValue.ToString();
                ac.DestinationCity = Destination_City1.SelectedValue.ToString();
                ac.Seat = Seat1.Text;

                Economy ec = new Economy();
                String economySeats = ec.calculateseat(ac.Seat);

                EconomyPlus ecp = new EconomyPlus();
                String economyPlusSeats = ecp.calculateseat(ac.Seat);

                BusinessClass bc = new BusinessClass();
                String businessSeats = bc.calculateseat(ac.Seat);


                airlinedal air = new airlinedal();
                Price pr = new Price();



                air.addFlightAirlineCarrier(ac, p);

                MessageBox.Show("Economy Price" + ec.Price + "Economy Plus" + ecp.Price + "Business " + bc.Price);
                MessageBox.Show("Sucessfully Added a New Flight");
                pd.addprice(p, ac, ec, ecp, bc, pr);
                this.Hide();
                AirlineCarrierPage arcp = new AirlineCarrierPage(p);
                arcp.Show();

            }
        
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            int distance;
            if
               (Airline_Company.Text == "" || int.TryParse(Airline_Company.Text, out distance) || Flight_No.Text == "" || int.TryParse(Flight_No.Text, out distance) || Department_Time.Text == "" || Arrival_Time1.Text == "" || Date1.SelectedDate.ToString() == "" || Origin_City1.SelectedValue.ToString() == "" || Destination_City1.SelectedValue.ToString() == "" || Seat1.Text == "" && int.TryParse(Seat1.Text, out distance))
                MessageBox.Show("Please Fill in all the Tables");
            else
            {
                Airline_Company.Clear();
                Flight_No.Clear();
                Department_Time.Clear();
                Arrival_Time1.Clear();
                //Origin_City1.ClearValue();
                //Destination_City1.Clear();
                Seat1.Clear();

            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AirlineCarrierPage acp = new AirlineCarrierPage(p);
            acp.Show();
        }

       
    }
}
