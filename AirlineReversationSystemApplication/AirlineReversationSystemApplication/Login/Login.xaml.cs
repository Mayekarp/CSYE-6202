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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace AirlineReversationSystemApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
        }


        private void Sign_In_Click(object sender, RoutedEventArgs e)
        {
            Person p = new Person();
            p.UserName = txtBoxusername.Text;
            p.Password = passwordBox.Password;
            persondal da = new persondal();
            Person p1 = da.getUserType(p);

            try
            {

                if (!p1.Equals(null))
                {

                    if (txtBoxusername.Text == "" || passwordBox.Password == "")
                    {
                        MessageBox.Show("Please Fill all the Fields");
                    }
                    else
                    {

                        if (p1.Role == "Admin")
                        {
                            MessageBox.Show("Username and Password is Correct");
                            this.Hide();
                            AdminPage ap = new AdminPage(p1);
                            ap.Show();
                        }

                        else if (p1.Role == "Airline Carrier")
                        {
                            MessageBox.Show("Username and Password is Correct");
                            this.Hide();
                            AirlineCarrierPage acp = new AirlineCarrierPage(p1);
                            acp.Show();
                        }
                        else if (p1.Role == "Customer")
                        {
                            Customer customer = new Customer();
                            customer.UserID = p1.UserID;
                            customer.UserName = p1.UserName;
                            MessageBox.Show("Username and Password is Correct");
                            this.Hide();
                            FlightCrewPage fc = new FlightCrewPage(customer);
                            fc.Show();
                        }
                        else if (p1.Role == "Flight Crew")
                        {
                            
                            MessageBox.Show("Username and Password is Correct");
                            this.Hide();
                            CrewPage fc = new CrewPage(p1);
                            fc.Show();
                        }

                    }
                    //MessageBox.Show("Incorrect Username and Password");

                }

            }

            catch (Exception)
            {

                MessageBox.Show("Exception");

            }
        }

        private void Sign_Up_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CreateNewAccount cna = new CreateNewAccount();
            cna.Show();
        }
    }
}
