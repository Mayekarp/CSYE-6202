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
    /// Interaction logic for UpdateFlightAirlineCarrier.xaml
    /// </summary>
    public partial class UpdateFlightAirlineCarrier : Window
    {

        Person p;
        public UpdateFlightAirlineCarrier(Person p)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            this.p = p;
        }

       

        
        private void Update_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AirlineCarrierPage acp = new AirlineCarrierPage(p);
            acp.Show();
        }

        private void Update_Click_1(object sender, RoutedEventArgs e)
        {
            AirlineCarrier ac = new AirlineCarrier();
            Regex time = new Regex(@"^(?ni:(?=\d)((?'year'((1[6-9])|([2-9]\d))\d\d)(?'sep'[/.-])(?'month'0?[1-9]|1[012])\2(?'day'((?<!(\2((0?[2469])|11)\2))31)|(?<!\2(0?2)\2)(29|30)|((?<=((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|(16|[2468][048]|[3579][26])00)\2\3\2)29)|((0?[1-9])|(1\d)|(2[0-8])))(?:(?=\x20\d)\x20|$))?((?<time>((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2}))?)$");
            Regex regEmail = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

            int distance;
            if (Airline_Company.Text == "" || int.TryParse(Airline_Company.Text, out distance) || Flight_No.Text == "" || Department_Time.Text == "" || Arrival_Time1.Text == "" || Origin_City1.SelectedValue.ToString() == "" || Destination_City2.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Please fill all fields");
            }
            if (Department_Time.Text == "" || !time.IsMatch(Department_Time.Text) || Arrival_Time1.Text == "" || !time.IsMatch(Arrival_Time1.Text))
            {
                MessageBox.Show("Enter Correct Time");
            }
            else if (Origin_City1.SelectedValue.ToString() == Destination_City2.SelectedValue.ToString())
            {
                MessageBox.Show("Cannot Select Same City");
            }
            else if (Arrival_Time1.Text == Department_Time.Text)
            {
                MessageBox.Show("Cannot Select Same Time");
            }
            else
            {

                ac.AirLineID = Convert.ToInt32(Airline_ID1.Text);
                ac.AirLineName = Airline_Company.Text;
                ac.FlightNo = Flight_No.Text;
                ac.ArrivalTime = Arrival_Time1.Text;
                ac.DepartureTime = Department_Time.Text;
                ac.Dates = Date1.SelectedDate.ToString();
                ac.OriginCity = Origin_City1.SelectedValue.ToString();
                ac.DestinationCity = Destination_City2.SelectedValue.ToString();
                ac.Seat = Seat2.Text;

                MessageBoxResult result = MessageBox.Show("Are you sure you want to update this flight?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {

                    airlinedal air = new airlinedal();

                    try
                    {
                        air.UpdateFlightAirlineCarrier(ac);
                        MessageBox.Show("updated successful");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    this.Hide();
                    AirlineCarrierPage arcp = new AirlineCarrierPage(p);
                    arcp.Show();

                }

                else if (result == MessageBoxResult.No)
                {
                    UpdateFlightAirlineCarrier upfac = new UpdateFlightAirlineCarrier(p);
                    upfac.Show();
                }
            }

        }
    }
}
