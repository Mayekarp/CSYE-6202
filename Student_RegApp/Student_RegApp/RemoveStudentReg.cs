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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this student", "Remove Student Registration Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //string sql = string.Format("Delete ")

            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }
    }
}
