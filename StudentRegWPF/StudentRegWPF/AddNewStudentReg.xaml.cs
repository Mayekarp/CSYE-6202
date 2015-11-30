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
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DBconnection objcon = new DBconnection();
            objcon.connection();
            if
                (Student_Id.Text == "" || First_Name1.Text == "" || Last_Name1.Text == "")
                MessageBox.Show("Please Fill in all the Tables");
            else
            {
                string query = "Insert into Student_Info (StudentID, Firstname, Lastname, Department, EnrollmentType) values (@StudentID, @Firstname, @Lastname, @Department, '" + EnrollmentType + "')";
                SqlCommand cmd = new SqlCommand(query, objcon.con);
                cmd.Parameters.AddWithValue("@StudentID", Student_Id.Text);
                cmd.Parameters.AddWithValue("@Firstname", First_Name1.Text);
                cmd.Parameters.AddWithValue("@Lastname", Last_Name1.Text);
                cmd.Parameters.AddWithValue("@Department", Department1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@enrollmentType", Full_Time.ToString());
                cmd.ExecuteNonQuery();

                MessageBox.Show("Sucessfully Added New Student");
                this.Hide();
                NewStudentRegistration nsr = new NewStudentRegistration();
                nsr.Show();
            }
        }
        String EnrollmentType;
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if 
                (Student_Id.Text == "" || First_Name1.Text == "" || Last_Name1.Text == "")
                MessageBox.Show("Please Fill in all the Tables");
            
            else 
                Student_Id.Clear();
                First_Name1.Clear();
                Last_Name1.Clear();
                //comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            
        }

        private void Part_Time_Checked(object sender, RoutedEventArgs e)
        {
            EnrollmentType = "Part Time";
        }

        private void Full_Time_Checked(object sender, RoutedEventArgs e)
        {
            EnrollmentType = "Full Time";

        }
    }
}
