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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sign_In_Click(object sender, RoutedEventArgs e)
        {
            if (Username1.Text != "" && Password1.Text != "")
            {
                DBconnection objcon = new DBconnection();
                objcon.connection();

                //    SqlCommand com = new SqlCommand("Student_Login", objcon.con);
                //    //string query = "Select * from Login where UserName =@username and Password =@password";
                //    //SqlCommand com = new SqlCommand(query, objcon.con);
                //    com.CommandType = CommandType.StoredProcedure;
                //    com.Parameters.AddWithValue("@username", Username1.Text);
                //    com.Parameters.AddWithValue("@password", Password1.Text);

                //    int IsValidUser = Convert.ToInt32(com.ExecuteScalar());
                //    objcon.con.Close();
                //    if (IsValidUser == 1)
                //    {
                //        MessageBox.Show("Logged In Successfully");
                //    }
                //    else
                //    {
                //        MessageBox.Show("InValid Username Or Password");
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("UserId and word Is Required");
                //}
                //SqlConnection con = new SqlConnection("Data Source = POOJAAVINASH; Initial Catalog = Student_Registration; Integrated Security = True");
                //con.Open();
                string username = Username1.Text;
                string password = Password1.Text;

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
                else
                {
                    MessageBox.Show("Incorrect username or password");
                }

                dr.Close();
            }

            }
    }
}
