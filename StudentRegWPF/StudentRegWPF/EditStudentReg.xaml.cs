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
    /// Interaction logic for EditStudentReg.xaml
    /// </summary>
    public partial class EditStudentReg : Window
    {
        public EditStudentReg()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        public string TextBoxValue1
        {
            get { return Student_Id.Text; }
            set { Student_Id.Text = value; }
        }

        public string TextBoxValue2
        {
            get { return First_Name1.Text; }
            set { First_Name1.Text = value; }
        }

        public string TextBoxValue3
        {
            get { return Last_Name1.Text; }
            set { Last_Name1.Text = value; }
        }

        public string TextBoxValue4
        {
            get { return Department1.Text; }
            set { Department1.Text = value; }
        }

        public string TextBoxValue5
        {
            get; set;
        }



        private void Update_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to update this student?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DBconnection objcon = new DBconnection();
                objcon.connection();
                string sql = string.Format("Update Student_Info set Firstname = '" + First_Name1.Text + "' ,Lastname = '" + Last_Name1.Text + "',Department = '" + Department1.Text.ToString() + "', EnrollmentType = '" + Full_Time.Content.ToString() + "' where StudentID = " + "'" + Student_Id.Text + "'");

                //string sql = "Update Student_Info set StudentId =@StudentId, Firstname =@Firstname, Lastname =@Lastname, Department =@Department, EnrollmentType ='" + Enrollment_Type + "' where StudentId = @StudentId";
                SqlCommand cmd = new SqlCommand(sql, objcon.con);
                //cmd.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = Student_Id.Text;
                //cmd.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = First_Name1.Text;
                //cmd.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = Last_Name1.Text;
                //cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = Department1.SelectedItem.ToString();
                //cmd.Parameters.Add("@enrollmentType", SqlDbType.VarChar).Value = Full_Time.ToString();
                
                try
                {
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("updated successful");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Hide();
                NewStudentRegistration nsr = new NewStudentRegistration();
                nsr.Show();

            }
            
            else if (result == MessageBoxResult.No)
            {
                EditStudentReg esr = new EditStudentReg();
                esr.Show();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            NewStudentRegistration nsr = new NewStudentRegistration();
            nsr.Show();
        }
    }
}
