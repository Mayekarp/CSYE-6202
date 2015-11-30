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
    /// Interaction logic for NewStudentRegistration.xaml
    /// </summary>
    public partial class NewStudentRegistration : Window
    {
        
       
        public NewStudentRegistration()
        {
            InitializeComponent();
            DBconnection objcon = new DBconnection();
            objcon.connection();
            SqlDataAdapter sda = new SqlDataAdapter("Select * from Student_Info", objcon.con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
            objcon.con.Close();

            this.ResizeMode = ResizeMode.NoResize;
        }

        public string TextBox1
        {
            get { return Student_Id_Text.Text; }
            set { Student_Id_Text.Text = value; }
        }

        public string TextBox2
        {
            get { return First_Name1_Text.Text; }
            set { First_Name1_Text.Text = value; }
        }

        public string TextBox3
        {
            get { return Last_Name1_Text.Text; }
            set { Last_Name1_Text.Text = value; }
        }

        public string TextBox4
        {
            get { return Department1_Text.Text; }
            set { Department1_Text.Text = value; }
        }

        public string TextBox5
        {
            get; set;
        }


        private void Add_Student_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddNewStudentReg ans = new AddNewStudentReg();
            ans.Show();

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (this.dataGrid.SelectedItems.Count > 0)
            //{
            //    //string Student_Id = ((DataRowView)dataGrid.SelectedItem).Row["StudentId"].ToString();
            //    //string First_Name1 = ((DataRowView)dataGrid.SelectedItem).Row["Firstname"].ToString();
            //    //string Last_Name1 = ((DataRowView)dataGrid.SelectedItem).Row["Lastname"].ToString();

            //    NewStudentRegistration nsr = new NewStudentRegistration();
            //    string test1 = ((DataRowView)dataGrid.SelectedItem).Row["StudentId"].ToString();
            //    nsr.TextBox1 = test1;
            //    string test2 = ((DataRowView)dataGrid.SelectedItem).Row["Firstname"].ToString();
            //    nsr.TextBox2 = test2;
            //    string test3 = ((DataRowView)dataGrid.SelectedItem).Row["Lastname"].ToString();
            //    nsr.TextBox3 = test3;
            //    string test4 = ((DataRowView)dataGrid.SelectedItem).Row["Department"].ToString();
            //    nsr.TextBox4 = test4;
            //    string test5 = ((DataRowView)dataGrid.SelectedItem).Row["EnrollmentType"].ToString();
            //    nsr.TextBox5 = test5;
            //}

        }

        private void Remove_Student_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGrid.SelectedItems.Count > 0)
            {
                this.Hide();
                RemoveStudentReg rsr = new RemoveStudentReg();

                string test1 = ((DataRowView)dataGrid.SelectedItem).Row["StudentId"].ToString(); 
                rsr.TextBoxValue1 = test1;
                string test2 = ((DataRowView)dataGrid.SelectedItem).Row["Firstname"].ToString();
                rsr.TextBoxValue2 = test2;
                string test3 = ((DataRowView)dataGrid.SelectedItem).Row["Lastname"].ToString();
                rsr.TextBoxValue3 = test3;
                string test4 = ((DataRowView)dataGrid.SelectedItem).Row["Department"].ToString();
                rsr.TextBoxValue4 = test4;
                string test5 = ((DataRowView)dataGrid.SelectedItem).Row["EnrollmentType"].ToString();
                rsr.TextBoxValue5 = test5;

                rsr.Show();
            }
            }

        private void Edit_Student_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGrid.SelectedItems.Count > 0)
            {
                this.Hide();
                EditStudentReg esr = new EditStudentReg();

                string test1 = ((DataRowView)dataGrid.SelectedItem).Row["StudentId"].ToString();
                esr.TextBoxValue1 = test1;
                string test2 = ((DataRowView)dataGrid.SelectedItem).Row["Firstname"].ToString();
                esr.TextBoxValue2 = test2;
                string test3 = ((DataRowView)dataGrid.SelectedItem).Row["Lastname"].ToString();
                esr.TextBoxValue3 = test3;
                string test4 = ((DataRowView)dataGrid.SelectedItem).Row["Department"].ToString();
                esr.TextBoxValue4 = test4;
                string test5 = ((DataRowView)dataGrid.SelectedItem).Row["EnrollmentType"].ToString();
                esr.TextBoxValue5 = test5;
                esr.Show();
            }

        }
    }

}
