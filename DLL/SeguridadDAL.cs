using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Common.Cache;


namespace DAL
{
   public class SeguridadDAL
    {
        public DataTable listarPermisos(){

            using (var con = new Conexion().conectar())
            {
                using (var da = new SqlDataAdapter("listaPermisosAtomicos", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        
        }


    }
}
