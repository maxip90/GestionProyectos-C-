using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace DAL
{
    public class Conexion
    {
        public SqlConnection conectar(){

            //CAMBIAR STRING DE CONEXION 
            string stringCon = ConfigurationManager.ConnectionStrings["stringConn"].ConnectionString;
            SqlConnection con = new SqlConnection(stringCon);
            con.Open();
            return con;
    }

    }
}
