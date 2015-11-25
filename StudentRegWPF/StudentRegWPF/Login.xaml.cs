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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace StudentRegWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sign_In_Click(object sender, RoutedEventArgs e)
        {
            if (Username1.Text != "" && Password1.Text != "")
            {
                DBconnection objcon = new DBconnection();
                objcon.connection();

                SqlCommand com = new SqlCommand("Student_Login", objcon.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue()
            }

        }
    }
}
