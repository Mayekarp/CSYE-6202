using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace AirlineReversationSystemApplication
{
    class DBConnection
    {
        public SqlConnection con;
        public string constr;
        public void connection()
        {
            //DataBase Connection Details  
            constr = "Data Source=POOJAAVINASH;Initial Catalog=Airline_Reservation_System;Integrated Security=True";
            con = new SqlConnection(constr);
            con.Open();

        }
    }
}
