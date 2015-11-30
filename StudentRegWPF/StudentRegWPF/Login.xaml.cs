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

namespace StudentRegWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
       
        public MainWindow()
        {
            InitializeComponent();
            Password1.PasswordChar = '*';
            Password1.MaxLength = '8';

            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Sign_In_Click(object sender, RoutedEventArgs e)
        {
            if (Username1.Text != "" && Password1.Password != "")
            {
                DBconnection objcon = new DBconnection();
                objcon.connection();


                string username = Username1.Text;
                string password = Password1.Password;

                string query = "Select * from LoginDetails where UserName =@username and Password =@password";
                SqlCommand cmd = new SqlCommand(query, objcon.con);
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@password", password));

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                {

                    MessageBox.Show("Login Sucessful");
                    this.Hide();
                    NewStudentRegistration nsr = new NewStudentRegistration();
                    nsr.Show();

                }
            
            else if(dr.HasRows == false)
                {
                    count++;
                    //int loopAnswer = 0;
                    //   int number1 = int.Parse(Username1.Text);

                    //    for (count = 1; count <= 3; count++)
                    //    {
                    //        loopAnswer +=  number1;

                    //    }

                    //equalsBox.Text = loopAnswer.ToString();
                    if (count == 4)
                    {
                        Environment.Exit(1);
                    }
                    MessageBox.Show("Incorrect username or password");

                }

            //else
            //{
            //    Environment.Exit(1);
            //}

                dr.Close();
            }

            }
    }
}
