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
using System.Text.RegularExpressions;

namespace AirlineReversationSystemApplication
{
    /// <summary>
    /// Interaction logic for ViewCustomer.xaml
    /// </summary>
    public partial class ViewCustomer : Window
    {
        public ViewCustomer()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            populateCB();
        }
        AdminDal ad = new AdminDal();
        public void populateCB()
        {
           
            
            dataGrid.ItemsSource = ad.getCustomerBookingDetaols();

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CustomerBookings cb = (CustomerBookings)dataGrid.SelectedValue;
            BookingID.Text = cb.BookingID.ToString();
            Airline_Company.Text = cb.AirLineName.ToString();
            Flight_No.Text = cb.FlightNo.ToString();
            Arrival_Time1.Text = cb.Arrivaltime.ToString();
            Department_Time.Text = cb.Departuretime.ToString();
            Date1.Text = cb.Dates.ToString();
            Origin_City1.Text = cb.OriginCity.ToString();
            Destination_City1.Text = cb.DestinationCity.ToString();
            EmailID1.Text = cb.EmailID.ToString();
        }
        CustomerBookings cb = new CustomerBookings();
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Regex time = new Regex(@"^\d{ 1, 2 }([:.]?\d{ 1,2})?([ ]?[a | p]m)?$");
            Regex regEmail = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");


            if (Flight_No.Text == "" || Department_Time.Text == "" || EmailID1.Text == "" && !regEmail.IsMatch(EmailID1.Text)||  Arrival_Time1.Text == ""  || Origin_City1.SelectedValue.ToString() == "" || Destination_City1.SelectedValue.ToString() == "" )
            {
                MessageBox.Show("Please fill all fields");
            }
           else if (Department_Time.Text == "" && !time.IsMatch(Department_Time.Text) || Arrival_Time1.Text == "" && !time.IsMatch(Arrival_Time1.Text))
            {
                MessageBox.Show("Enter Correct Time");
            }
            else if (Origin_City1.SelectedValue.ToString() == Destination_City1.SelectedValue.ToString())
            {
                MessageBox.Show("Cannot Select Same City");
            }
            else if (EmailID1.Text == "" && !regEmail.IsMatch(EmailID1.Text))
            {
                if (ad.checkifEmailexist(cb) == true)
                {
                    MessageBox.Show("Enter Correct EmailID");
                }
                else
                {
                    MessageBox.Show("Entered EmailID is correct");
                }
                
            }else
            {
                cb.BookingID = Convert.ToInt32(BookingID.Text.ToString());
                cb.AirLineName = Airline_Company.Text;
                cb.FlightNo = Flight_No.Text;
                cb.Arrivaltime = Arrival_Time1.Text;
                cb.Departuretime = Department_Time.Text;
                cb.Dates = Date1.SelectedDate.ToString();
                cb.OriginCity = Origin_City1.SelectedValue.ToString();
                cb.DestinationCity = Destination_City1.SelectedValue.ToString();
                cb.EmailID = EmailID1.Text;
                ad.UpdateCustomerBookings(cb);
                MessageBox.Show("Successfully Updated");
            }
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            // AirlineCarrier ac = new AirlineCarrier();
            //String book = Convert.ToInt32(BookingID.Text);
            cb.BookingID = Convert.ToInt32(BookingID.Text.ToString());
            ad.RemoveCustomerBookings(cb);
            MessageBox.Show("Successfully Deleted");
        }
    }
}
