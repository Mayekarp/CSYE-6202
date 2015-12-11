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
    /// Interaction logic for AirlineCarrierPage.xaml
    /// </summary>
    public partial class AirlineCarrierPage : Window
    {
        Person p;
        public AirlineCarrierPage(Person p)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.ResizeMode = ResizeMode.NoResize;
            this.p = p;
            airlinedal air = new airlinedal();     
            loadgridlist_airlineFlightDetails();
        }

        public void loadgridlist_airlineFlightDetails()
        {
            airlinedal air = new airlinedal();
            dataGrid.ItemsSource = air.getAirlineCarrierFlightDetails(p);

        }
       

        private void Add_Flight_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddFlightAirlineCarrier afac = new AddFlightAirlineCarrier(p);
            afac.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGrid.SelectedItems.Count > 0)
            {
                this.Hide();
                UpdateFlightAirlineCarrier ufarc = new UpdateFlightAirlineCarrier(p);
                AirlineCarrier ac = (AirlineCarrier)dataGrid.SelectedValue;
                ufarc.Airline_ID1.Text = ac.AirLineID.ToString();
                ufarc.Airline_Company.Text = ac.AirLineName.ToString();
                ufarc.Flight_No.Text = ac.FlightNo.ToString();
                ufarc.Arrival_Time1.Text = ac.ArrivalTime.ToString();
                ufarc.Department_Time.Text = ac.DepartureTime.ToString();
                ufarc.Date1.Text = ac.Dates.ToString();
                ufarc.Origin_City1.Text = ac.OriginCity.ToString();
                ufarc.Destination_City2.Text = ac.DestinationCity.ToString();
                ufarc.Seat2.Text = ac.Seat.ToString();

                ufarc.Show();
            }
            
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (this.dataGrid.SelectedItems.Count > 0)
            {
                this.Hide();
                RemoveFlightAirlineCarrier rfac = new RemoveFlightAirlineCarrier(p);

                AirlineCarrier ac = (AirlineCarrier)dataGrid.SelectedValue;
                rfac.Airline_ID1.Text = ac.AirLineID.ToString();
                rfac.Airline_Company.Text = ac.AirLineName.ToString();
                rfac.Flight_No.Text = ac.FlightNo.ToString();
                rfac.Arrival_Time1.Text = ac.ArrivalTime.ToString();
                rfac.Department_Time.Text = ac.DepartureTime.ToString();
                rfac.Date1.Text = ac.Dates.ToString();
                rfac.Origin_City1.Text = ac.OriginCity.ToString();
                rfac.Destination_City1.Text = ac.DestinationCity.ToString();
                rfac.Seat1.Text = ac.Seat.ToString();


                //string test1 = ((DataRowView)dataGrid.SelectedItem).Row["AirLineID"].ToString();
                //rfac.TextBoxValue1 = test1;
                //string test2 = ((DataRowView)dataGrid.SelectedItem).Row["AirlineName"].ToString();
                //rfac.TextBoxValue2 = test2;
                //string test3 = ((DataRowView)dataGrid.SelectedItem).Row["FlightNo"].ToString();
                //rfac.TextBoxValue3 = test3;
                //string test4 = ((DataRowView)dataGrid.SelectedItem).Row["Arrivaltime"].ToString();
                //rfac.TextBoxValue4 = test4;
                //string test5 = ((DataRowView)dataGrid.SelectedItem).Row["Departmenttime"].ToString();
                //rfac.TextBoxValue5 = test5;
                //string test6 = ((DataRowView)dataGrid.SelectedItem).Row["Date"].ToString();
                //rfac.TextBoxValue6 = test6;
                //string test7 = ((DataRowView)dataGrid.SelectedItem).Row["Class"].ToString();
                //rfac.TextBoxValue7 = test7;

                //string test9 = ((DataRowView)dataGrid.SelectedItem).Row["OriginCity"].ToString();
                //rfac.TextBoxValue9 = test9;
                //string test10 = ((DataRowView)dataGrid.SelectedItem).Row["DestinationCity"].ToString();
                //rfac.TextBoxValue10 = test10;
                //string test11 = ((DataRowView)dataGrid.SelectedItem).Row["Seat"].ToString();
                //rfac.TextBoxValue11 = test11;

                rfac.Show();
            }

        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AirlineCarrier ac = (AirlineCarrier)dataGrid.SelectedValue;
            Airline_ID1.Text = ac.AirLineID.ToString();
            Airline_Company.Text = ac.AirLineName.ToString();
            Flight_No.Text = ac.FlightNo.ToString();
            Arrival_Time1.Text = ac.ArrivalTime.ToString();
            Department_Time.Text = ac.DepartureTime.ToString();
            Date1.Text = ac.Dates.ToString();
            Origin_City1.Text = ac.OriginCity.ToString();
            Destination_City1.Text = ac.DestinationCity.ToString();
            Seat1.Text = ac.Seat.ToString();
            

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
