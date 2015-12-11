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

namespace AirlineReversationSystemApplication
{
    /// <summary>
    /// Interaction logic for CrewPage.xaml
    /// </summary>
    public partial class CrewPage : Window
    {
        Person p;
        public CrewPage(Person p)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            this.p = p;
            populateflightcrew();
            populateAirlineCarrier();
        }

        persondal pd = new persondal();
        public void populateflightcrew()
        {
           FlightCrewDataGrid.ItemsSource = pd.displayflightcrewDetails(p);
        }

        public void populateAirlineCarrier()
        {
            airlinedal air = new airlinedal();
            AirlineDataGrid.ItemsSource = air.getAllFlights();
        }
    }
}
