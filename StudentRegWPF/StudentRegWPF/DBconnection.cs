using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StudentRegWPF
{
    class DBconnection
    {
        public SqlConnection con;
        public string constr;
        public void connection()
        {
            //DataBase Connection Details  
            constr = "Data Source=POOJAAVINASH;Initial Catalog=StudentLogin;Integrated Security=True";
            con = new SqlConnection(constr);
            con.Open();

        }
    }
}
