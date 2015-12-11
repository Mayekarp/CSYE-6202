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
using System.Net.Mail;
using System.Net;

namespace AirlineReversationSystemApplication
{
    /// <summary>
    /// Interaction logic for Payement.xaml
    /// </summary>
    public partial class Payement : Window
    {
        CustomerBookings cb;
        Customer customer;
        public Payement(CustomerBookings cb, Customer customer)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            this.cb = cb;
            this.customer = customer;
        }

        private void CheckOut_Click(object sender, RoutedEventArgs e)
        {

            Regex regEmail = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            if (CVV1.Text == "" || Card_Number1.Text == "" || Month_Year1.Text == "")
            {
                MessageBox.Show("Fill all Fields");
            }
             else if (Email_ID1.Text == "" || !regEmail.IsMatch(Email_ID1.Text))
            {
                MessageBox.Show("Enter Correct EmailID");
            }
            else if (checkforLength() == false)
            {
                MessageBox.Show("Enter Correct Card Details");
            }
            else 
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to book this Flight?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    cb.EmailID = Email_ID1.Text;
                    cb.CardDetails = Card_Number1.Text;
                    cb.CVV = CVV1.Text;
                    cb.Month = Month_Year1.Text;

                    var client = new SmtpClient("smtp.gmail.com", 587)
                    {
                        Credentials = new NetworkCredential("poojareservation@gmail.com", "reservationsystem"),
                        EnableSsl = true
                    };
                    
                    //Console.WriteLine("Sent");
                    //Console.ReadLine();

                    Customerdal cd = new Customerdal();
                    try
                    {
                        cd.insertIntoCustomerBookings(cb);
                        cd.UpdateNewSeatsAirlineFlight(cb);
                        client.Send("poojareservation@gmail.com", Email_ID1.Text.ToString(), "AirlineReservartionSystem", "TicketBooked");
                        MessageBox.Show("Booked successful");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    this.Hide();
                    FlightCrewPage fcp = new FlightCrewPage(customer);
                    fcp.Show();

                }
                else if (result == MessageBoxResult.No)
                {
                    this.Hide();
                   Payement py = new Payement(cb,customer);
                    py.Show();
                }
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private Boolean checkforLength()
        {
            int a = 0;
            if (int.TryParse(Card_Number1.Text, out a))
            {
                if (a < 16)
                {
                    return false;
                }
                
            }
            else if (int.TryParse(Month_Year1.Text, out a))
            {
                if (a < 4)
                {
                    return false;
                }
            }
            else if (int.TryParse(CVV1.Text, out a))
            {
                if (a < 3)
                {
                    return false;
                }
            }

            return true;   
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (CVV1.Text == "" || Card_Number1.Text == "" || Month_Year1.Text == "" || Email_ID1.Text == "")
            {
                MessageBox.Show("Fill all Fields");
            }
            else
            {
                Email_ID1.Clear();
                Card_Number1.Clear();
                CVV1.Clear();
                Month_Year1.Clear();
            }
        }
    }
}
