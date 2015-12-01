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

using System.Data.SQLite;

namespace AirlineReservationSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dbConnectionString = @;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);

            try
            {
                sqliteCon.Open();
                string Query = "Select * from Login_Details where username= '" + this.User_Name.Text + "'and password= '" + this.Password1.Password + "' ";
                SQLiteCommand comm = new SQLiteCommand(Query, sqliteCon);
                comm.ExecuteNonQuery();
                SQLiteDataReader dr = comm.ExecuteReader();

                int count = 0;
                while (dr.Read())
                {
                    count++;
                }
                if (count == 1)
                {
                    MessageBox.Show("Username and Password Is correct");
                }
                if (count > 1)
                {
                    MessageBox.Show("Duplicate Username and Password. Please Try Again");
                }
                if (count < 1)
                {
                    MessageBox.Show("Username and Password is Not correct");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
