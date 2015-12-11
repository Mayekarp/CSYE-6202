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

namespace AirlineReversationSystemApplication
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        Person p;
        public AdminPage(Person p)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            persondal da = new persondal();
            this.p = p;
            
            loadgridlist_airlineLoginDetails();
           
        }

        public void loadgridlist_airlineLoginDetails()
        {
            dataGrid.ItemsSource = da.getAirlineCarrierLoginDetails();

        }

        persondal da = new persondal();

        private void AcceptRequest_Click(object sender, RoutedEventArgs e)
        {
            Person p = new Person();
            p.UserID = Convert.ToInt32(UserID1.Text);
            p.UserName = UserName1.Text;
            p.Password = passwordBox.Password;
            p.FirstName = FirstName1.Text;
            p.LastName = LastName1.Text;
            p.EmailID = EmailID1.Text;
            p.Role = comboBox.SelectedValue.ToString();

           
            if (this.dataGrid.SelectedItems.Count > 0)
            {

                da.acceptAirlineCarrierLogin(p);
                
                Person p1 = (Person)dataGrid.SelectedValue;
                UserName1.Text = p1.UserName.ToString();
                passwordBox.Password = p1.Password.ToString();
                FirstName1.Text = p1.FirstName.ToString();
                LastName1.Text = p1.LastName.ToString();
                comboBox.Text = p1.Role.ToString();
                EmailID1.Text = p1.EmailID.ToString();
                MessageBox.Show("Request Accepted");

                da.rejectAirlineCarrierLogin(p);


               
            }
            
        }

        private void RejectRequest_Click(object sender, RoutedEventArgs e)
        {
            Person p = new Person();
            p.UserID = Convert.ToInt32(UserID1.Text);
           

            if (this.dataGrid.SelectedItems.Count > 0)
            {
                da.rejectAirlineCarrierLogin(p);

                MessageBox.Show("Request Rejected");

            }

            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
              
            }

       

        private void Airline_Carrier_Page_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AirlineCarrierPage acp = new AirlineCarrierPage(p);
            acp.Show();
        }

        private void Flight_Crew_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CrewPage cp = new CrewPage();
            cp.Show();
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e) 
        {
           Person p= (Person)dataGrid.SelectedValue;
            UserID1.Text = p.UserID.ToString();
            UserName1.Text = p.UserName.ToString();
            passwordBox.Password = p.Password.ToString();
            FirstName1.Text = p.FirstName.ToString();
            LastName1.Text = p.LastName.ToString();
            comboBox.Text = p.Role.ToString();
            EmailID1.Text = p.EmailID.ToString();
 
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void View_Customer_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ViewCustomer vc = new ViewCustomer();
            vc.Show();
        }
    }
}
