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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            password_text.PasswordChar = '*';
            password_text.MaxLength = '8';
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //private int _failAttempts = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection("Data Source = POOJAAVINASH; Initial Catalog = Student_Registration; Integrated Security = True");
            con.Open();
            //SqlDataAdapter sda = new SqlDataAdapter("Select UserName, Password from Login where UserName 'username" + textBox1.Text + "' and Password 'password " + textBox2.Text + "' ", con);
            //DataTable dt = new System.Data.DataTable();
            //con.Close();
            //sda.Fill(dt);

            //if (dt.Rows.Count == 1)
            //{
            //    NewStudentReg nsr = new NewStudentReg();
            //    this.Show();
            //}
            //con.Close();

            string username = textBox1.Text;
            string password = password_text.Text;

            string query = "Select * from Login where UserName =@username and Password =@password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("@username", username));
            cmd.Parameters.Add(new SqlParameter("@password", password));

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {

                MessageBox.Show("Login Sucessful");
                this.Hide();
                New_Student_Registration nsr = new New_Student_Registration();
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
