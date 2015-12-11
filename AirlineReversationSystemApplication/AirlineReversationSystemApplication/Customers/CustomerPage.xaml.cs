using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for FlightCrewPage.xaml
    /// </summary>
    public partial class FlightCrewPage : Window
    {
        Customer customer;

       //DataSourceProvider dataSource = new DataSourceProvider();
        public FlightCrewPage(Customer customer)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            populateValues();
            populateBookedFlights();
            this.customer = customer;
            Proceed_To_Checkout.IsEnabled = false;
            
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            
            Proceed_To_Checkout.IsEnabled = true;

            AirlineCarrier ac = new AirlineCarrier();
            if (Date1.SelectedDate.ToString() == "" || Origin_City1.SelectedValue.ToString() == "" || Destination_City1.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Fill all Fields");
            }
           else if (Origin_City1.SelectedValue.ToString() == Destination_City1.SelectedValue.ToString())
            {
                MessageBox.Show("Cannot Select Same Time");
            }
            else
            {
                ac.Dates = Date1.SelectedDate.Value.ToString("yyyy-MM-dd");
                string origincity = Origin_City1.SelectedValue.ToString();
                ac.OriginCity = origincity;
                ac.DestinationCity = Destination_City1.SelectedValue.ToString();

                try
                {
                    
                    StringBuilder queryaddress = new StringBuilder();
                    queryaddress.Append("https://www.google.com/maps");
                    if (origincity != string.Empty)
                    {
                        queryaddress.Append(origincity + "," + "+");
                    }
                    Browser.Navigate(queryaddress.ToString());
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error");
                }
                Customerdal cd = new Customerdal();
                dataGrid.ItemsSource = new BindingList<ShowFlightDetails>(cd.showflightdetails(ac));
            }
            
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        //    FlightCrew fc = new FlightCrew();
        //    fc.Date = Date1.Text;
        //    fc.OriginCity = Origin_City1.Text;
        //    fc.DestinationCity = Destination_City1.Text;


        //    Flightdal fd = new Flightdal();
        //    fd.showflightdetails(fc);
        }

        private void Proceed_To_Checkout_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGrid.SelectedItems.Count > 0)
            {
                ShowFlightDetails sfd = (ShowFlightDetails)dataGrid.SelectedValue;
                this.Hide();
                ProceedToCheckOut ptc = new ProceedToCheckOut(sfd, customer);
                ptc.Show();
            }
        }

        private void populateValues()
        {
            Destination_City1.SelectedIndex = 4;
            Origin_City1.SelectedIndex = 2;
            //Date1.SelectedDate = "2015/12/18";
        }
        Customerdal cd = new Customerdal();
        public void populateBookedFlights()
        {
            dataGrid1.ItemsSource = cd.getCustomerBookingDetails(); 
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomerBookings cb = (CustomerBookings)dataGrid1.SelectedValue;
            Booking_ID1.Text = cb.BookingID.ToString();

        }

        private void UnBook_Flight_Click(object sender, RoutedEventArgs e)
        {
            CustomerBookings cb = (CustomerBookings)dataGrid1.SelectedValue;
            cb.BookingID = Convert.ToInt32(Booking_ID1.Text);
            cd.UnbookCustomerBookings(cb);
            if (cd.UpdateUnbookSeatsAirlineFlight(cb) == true)
            {
                MessageBox.Show("Successfully Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }
            
            

        }
    }
}
