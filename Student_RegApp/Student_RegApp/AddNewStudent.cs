﻿using System;
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
    public partial class AddNewStudent : Form
    {
        SqlCommand cmd;
        SqlConnection con;
        SqlDataAdapter sda;

        public AddNewStudent()
        {
            InitializeComponent();

        }
        String Enrollment_Type;
        private void button1_Click(object sender, EventArgs e)
        {
         
                con = new SqlConnection("Data Source = POOJAAVINASH; Initial Catalog = Student_Registration; Integrated Security = True");
                con.Open();
            try {
                cmd.Parameters.Add("@StudentID", textBox1.Text);
                cmd.Parameters.Add("@Firstname", textBox2.Text);
                cmd.Parameters.Add("@Lastname", textBox3.Text);
                cmd.Parameters.Add("@Department", comboBox1.SelectedText.ToString());
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    MessageBox.Show("Please Fill in all the Tables");

            }
            cmd = new SqlCommand("Insert into Student_Info (StudentID, Firstname, Lastname, Department, Enrollment_Type) values (@StudentID, @Firstname, @Lastname, @Department, '" + Enrollment_Type + "')", con);
            
            MessageBox.Show("Sucessfully Added New Student");
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Enrollment_Type = "Full Time";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Enrollment_Type = "Part Time";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
            
        }
    }
}
