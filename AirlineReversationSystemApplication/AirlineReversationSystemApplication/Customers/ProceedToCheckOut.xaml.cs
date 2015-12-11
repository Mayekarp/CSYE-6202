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

namespace AirlineReversationSystemApplication
{
    /// <summary>
    /// Interaction logic for ProceedToCheckOut.xaml
    /// </summary>
    public partial class ProceedToCheckOut : Window
    {
        ShowFlightDetails sfd;
        Customer customer;
        public ProceedToCheckOut(ShowFlightDetails sfd, Customer customer)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            this.sfd = sfd;
            this.customer = customer;
            Passenger.SelectedIndex = 0;
            Class_Type1.SelectedIndex = 0;
            populate();
            Proceed_for_Payement.IsEnabled = false;

        }

        private void populate()
        {
            Travel_Date1.Text = sfd.Dates;
            Origin_City1.Text = sfd.OriginCity;
            Destination_City1.Text = sfd.DestinationCity;
            Airline_Company.Text = sfd.AirLineName;
            Arrival_Time1.Text = sfd.Arrivaltime;
            Department_Time.Text = sfd.Departuretime;

        }


        private void getTotalPrice()
        {
            int passenger = Convert.ToInt32(Passenger.SelectedValue.ToString());
           

            if (Class_Type1.Text == "Economy Class")
            {
                int EconomyClass = sfd.EconomyClassPrice;
                int price = (passenger * EconomyClass);
                Price1.Text = price.ToString();
            }
            else if (Class_Type1.Text == "Economy Plus Class")
            {
                int EconomyPlusClass = sfd.EconomyPlusClassPrice;
                int price = (passenger * EconomyPlusClass);
                Price1.Text = price.ToString();
            }
            else if (Class_Type1.Text == "Business Class")
            {
                int BusinessClass = sfd.BusinessClassPrice;
                int price = (passenger * BusinessClass);
                Price1.Text = price.ToString();
            }
           

        }

        private void Check_Price_Click(object sender, RoutedEventArgs e)
        {
            if (Class_Type1.SelectedValue.ToString() == "" || Passenger.SelectedValue.ToString() == "" )
            {
                MessageBox.Show("Fill all Fields");
            }
            else
            {
                Proceed_for_Payement.IsEnabled = true;
                getTotalPrice();
            }
            
        }

        private void Proceed_for_Payement_Click(object sender, RoutedEventArgs e)
        {
            CustomerBookings cb = new CustomerBookings();
            
            cb.AirlineID = sfd.AirlineID;
            cb.CustomerUserID = customer.UserID;
            cb.UserName = customer.UserName;
            cb.FlightNo = sfd.FlightNo;
            cb.Dates = sfd.Dates;
            cb.OriginCity = sfd.OriginCity;
            cb.DestinationCity = sfd.DestinationCity;
            cb.AirLineName = sfd.AirLineName;
            cb.Arrivaltime = sfd.Arrivaltime;
            cb.Departuretime = sfd.Departuretime;
            cb.ClassType = Class_Type1.SelectedValue.ToString();
            cb.Passenger = Convert.ToInt32(Passenger.SelectedValue.ToString());
            cb.Price = Convert.ToInt32(Price1.Text);
            cb.Seats = sfd.Seats;


            this.Hide();
            Payement py = new Payement(cb, customer);
            py.Show();
        }

        

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FlightCrewPage fcp = new FlightCrewPage( customer);
            fcp.Show();
        }
    }
}
