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

namespace AirlineReversationSystemApplication
{
    /// <summary>
    /// Interaction logic for RemoveFlightAirlineCarrier.xaml
    /// </summary>
    public partial class RemoveFlightAirlineCarrier : Window
    {

        Person p;
        public RemoveFlightAirlineCarrier(Person p)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            this.p = p;
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            AirlineCarrier ac = new AirlineCarrier();
            ac.AirLineID = Convert.ToInt32(Airline_ID1.Text);
            
                MessageBoxResult result = MessageBox.Show("Are you sure you want to remove this Flight?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    int airlineID = Convert.ToInt32(Airline_ID1.Text);
                    airlinedal air = new airlinedal();

                    try
                    {
                        air.RemoveFlightAirlineCarrier(ac);
                        MessageBox.Show("delete successful");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    this.Hide();
                    AirlineCarrierPage acp = new AirlineCarrierPage(p);
                    acp.Show();

                }
            
            else if (result == MessageBoxResult.No)
            {
                RemoveFlightAirlineCarrier rfac = new RemoveFlightAirlineCarrier(p);
                rfac.Show();
            }
    
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AirlineCarrierPage acp = new AirlineCarrierPage(p);
            acp.Show();
        }
    }
}
