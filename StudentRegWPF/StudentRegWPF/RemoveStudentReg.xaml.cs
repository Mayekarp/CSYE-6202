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
    /// Interaction logic for RemoveStudentReg.xaml
    /// </summary>
    public partial class RemoveStudentReg : Window
    {
        public RemoveStudentReg()
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
            get; set;
        }

        public string TextBoxValue5
        {
            get; set;
        }


        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this student?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                DBconnection objcon = new DBconnection();
                objcon.connection();
                string sql = string.Format("Delete from Student_info where StudentID = " + "'" + Student_Id.Text + "'");
                SqlCommand cmd = new SqlCommand(sql, objcon.con);

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("delete successful");
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
                RemoveStudentReg rsr = new RemoveStudentReg();
                rsr.Show();
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
