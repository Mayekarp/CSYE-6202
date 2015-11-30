using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Student_RegApp
{
    public partial class RemoveStudentReg : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter sda;

        public RemoveStudentReg()
        {
            InitializeComponent();
            
        }

        public string TextBoxValue1
        {
            get { return Student_Text.Text; }
            set { Student_Text.Text = value; }
        }

        public string TextBoxValue2
        {
            get { return Firstname_Text.Text; }
            set { Firstname_Text.Text = value; }
        }

        public string TextBoxValue3
        {
            get { return Lastname_Text.Text; }
            set { Lastname_Text.Text = value; }
        }

        public string TextBoxValue4
        {
            get { return comboBox1.SelectedItem.ToString(); }
            set { comboBox1.SelectedItem = value; }
        }

        public string TextBoxValue5
        {
            get { return radioButton1.Text; }
            set { radioButton1.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this student", "Remove Student Registration Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con = new SqlConnection("Data Source = POOJAAVINASH; Initial Catalog = Student_Registration; Integrated Security = True");
                con.Open();
                string sql = string.Format("Delete from Student_info where StudentID = " +"'"+ Student_Text.Text+"'");
                SqlCommand cmd = new SqlCommand(sql, con);

                try
                {
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("delete successful");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            else if (dialogResult == DialogResult.No)
            {
                RemoveStudentReg rsr = new RemoveStudentReg();
                rsr.Show();
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            New_Student_Registration nsr = new New_Student_Registration();
            nsr.Show();
        }
    }
}
