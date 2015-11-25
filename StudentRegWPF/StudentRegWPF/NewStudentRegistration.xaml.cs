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
        }
        
        private void Add_Student_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddNewStudentReg ans = new AddNewStudentReg();
            ans.Show();

        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Remove_Student_Click(object sender, RoutedEventArgs e)
        {
            //if (this.dataGridView1.SelectedRows.Count > 0)
            //{
            //    this.Hide();
            //    RemoveStudentReg rsr = new RemoveStudentReg();

            //    string test1 = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString();
            //    rsr.TextBoxValue1 = test1;
            //    string test2 = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
            //    rsr.TextBoxValue2 = test2;
            //    string test3 = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
            //    rsr.TextBoxValue3 = test3;
            //    rsr.Show();
            }

        private void Edit_Student_Click(object sender, RoutedEventArgs e)
        {
            //if (this.dataGridView1.SelectedRows.Count > 0)
            //{
            //    this.Hide();
            //    EditStudentReg esr = new EditStudentReg();

            //    string test1 = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString();
            //    esr.TextBoxValue1 = test1;
            //    string test2 = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[1].Value.ToString();
            //    esr.TextBoxValue2 = test2;
            //    string test3 = dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[2].Value.ToString();
            //    esr.TextBoxValue3 = test3;
            //    esr.Show();
            //}
        
    }
    }

}
