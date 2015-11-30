using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Student_RegApp
{
    public partial class EditStudentReg : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter sda;


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
            get; set;
        }

        public string TextBoxValue5
        {
            get; set;
        }


        public EditStudentReg()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update this student", "Update Student Registration Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                con = new SqlConnection("Data Source = POOJAAVINASH; Initial Catalog = Student_Registration; Integrated Security = True");
                con.Open();
                //string sql = string.Format("Delete from Student_info where StudentID = " + Student_Text.Text);
                String sql = string.Format("Update Student_Info set Firstname = '" + Firstname_Text.Text + "' ,Lastname = '" + Lastname_Text.Text + "',Department = '" + comboBox1.SelectedItem + "',Enrollment_Type = '" + radioButton1.Text + "' where StudentID = '" + Student_Text.Text + " ' " , con);
                SqlCommand cmd = new SqlCommand(sql, con);
                //cmd.Parameters.Add("@StudentID", Student_Text.Text);
                //cmd.Parameters.Add("@Firstname", Firstname_Text.Text);
                //cmd.Parameters.Add("@Lastname", Lastname_Text.Text);
                //cmd.Parameters.Add("@Department", comboBox1.SelectedText.ToString());

                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("update successful");
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
