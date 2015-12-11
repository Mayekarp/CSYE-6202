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
    /// Interaction logic for CreateNewAccount.xaml
    /// </summary>
    public partial class CreateNewAccount : Window
    {
       Regex regEmail = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
      
       // Regex regEmail = new Regex(@"(\w){0,3}[a-z]");
        

       public CreateNewAccount()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            comboBox.SelectedIndex = 0;
        }


        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailID1.Text;

            Person p = new Person();
            p.UserName = UserName1.Text;
            p.Password = passwordBox.Password;
            p.FirstName = FirstName1.Text;
            p.LastName = LastName1.Text;
            p.EmailID = email;
            p.Role = comboBox.SelectedValue.ToString();

            persondal da = new persondal();

            if (UserName1.Text == "" || FirstName1.Text == "" || LastName1.Text == "" || EmailID1.Text == "" || comboBox.SelectedValue.ToString() == "" || passwordBox.Password == "" && ConfirmpasswordBox.Password == "")
            {
                MessageBox.Show("Please Fill all Fields");
            }
            int distance;

            if (UserName1.Text == "" || int.TryParse(UserName1.Text, out distance) || FirstName1.Text == "" || int.TryParse(UserName1.Text, out distance) || LastName1.Text == "" || int.TryParse(UserName1.Text, out distance))
            {
                MessageBox.Show("Incorrect UserName, FirstName, LastName");
            }

           else if (email == "" || !regEmail.IsMatch(email))
            {

               
                MessageBox.Show("Incorrect EmailID");
            }
            else if (comboBox.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Select One Role");
            }

            else if (passwordBox.Password == "" || ConfirmpasswordBox.Password == "" || !(passwordBox.Password.Equals(ConfirmpasswordBox.Password)))
            {
                MessageBox.Show("Re-entered Password Incorrect");
            }

            else if (comboBox.SelectedValue.ToString() == "Customer")
            {
                if (da.checkifusernameexist(p) == false)
                {
                    MessageBox.Show("Username or emailId Already Exists");
                }
                else
                {
                    da.addLoginCustomer(p);
                    MessageBox.Show("Sucessfully Created a new Account");
                    this.Hide();
                    MainWindow mw = new MainWindow();
                    mw.Show();
                }
                

               
            }
            else if (comboBox.SelectedValue.ToString() == "Airline Carrier")
            {
                if (da.checkifusernameexist(p) == true)
                {
                    MessageBox.Show("Username or emailId Already Exists");

                }
                else
                {
                    da.addLoginAirlineCarrier(p);
                    MessageBox.Show("Sucessfully Created a new Account");
                    this.Hide();
                    MainWindow mw = new MainWindow();
                    mw.Show();
                }
               
            }
            else if (comboBox.SelectedValue.ToString() == "Flight Crew")
            {
                if (da.checkifusernameexist(p) == true)
                {
                    MessageBox.Show("Username or emailId Already Exists");
                }
                else
                {
                    da.addLoginFlightCrew(p);
                    MessageBox.Show("Sucessfully Created a new Account");
                    this.Hide();
                    MainWindow mw = new MainWindow();
                    mw.Show();
                }
                
            }
        }
    







    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        if
           (UserName1.Text == "" || FirstName1.Text == "" || LastName1.Text == "" || EmailID1.Text == "" || !regEmail.IsMatch(EmailID1.Text) || comboBox.SelectedValue.ToString() == "" || passwordBox.Password == "" || ConfirmpasswordBox.Password == "")

        {
            MessageBox.Show("Please Fill in all the Tables");
        }
        else
        {
            UserName1.Clear();
            FirstName1.Clear();
            LastName1.Clear();
            EmailID1.Clear();
            passwordBox.Clear();
            ConfirmpasswordBox.Clear();
        }

    }

    private void Back_Click(object sender, RoutedEventArgs e)
    {
        this.Hide();
        MainWindow mw = new MainWindow();
        mw.Show();
    }
}
}
