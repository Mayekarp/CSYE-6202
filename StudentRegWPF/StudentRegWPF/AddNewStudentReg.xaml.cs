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

namespace StudentRegWPF
{
    /// <summary>
    /// Interaction logic for AddNewStudentReg.xaml
    /// </summary>
    public partial class AddNewStudentReg : Window
    {
        public AddNewStudentReg()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DBconnection objcon = new DBconnection();
            objcon.connection();
            try
            {
                SqlCommand cmd = new SqlCommand("Insert into Student_Info (StudentID, Firstname, Lastname, Department, Enrollment_Type) values (@StudentID, @Firstname, @Lastname, @Department, '" + Enrollment_Type + "')", objcon.con);
                cmd.Parameters.Add("@StudentID", Student_Id.Text);
                cmd.Parameters.Add("@Firstname", First_Name1.Text);
                cmd.Parameters.Add("@Lastname", Last_Name1.Text);
                cmd.Parameters.Add("@Department", Department1.SelectedText.ToString());
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                if (Student_Id.Text == "" || First_Name1.Text == "" || Last_Name1.Text == "")
                    MessageBox.Show("Please Fill in all the Tables");

            }
          

            MessageBox.Show("Sucessfully Added New Student");
            this.Hide();
            NewStudentRegistration nsr = new NewStudentRegistration();
            nsr.Show();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Student_Id.Clear();
            First_Name1.Clear();
            Last_Name1.Clear();
            //comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
        }
    }
}
