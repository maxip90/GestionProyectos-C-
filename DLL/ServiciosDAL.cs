using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
   public class ServiciosDAL
    {

       public DataTable listarRolesIdioma(string query) {

           SqlConnection con = new Conexion().conectar();
           SqlDataAdapter da = new SqlDataAdapter(query, con);
           DataTable dt = new DataTable();
           da.Fill(dt);
           return dt; 
       }

       public DataTable obtenerUltimoRegistro(string tabla, string id) {
           using (var con = new Conexion().conectar())
           {
               using (var da = new SqlDataAdapter("Select top 1 * from " + tabla + " order by " + id + " desc", con)){
                  
                   DataTable dt = new DataTable();
                   da.Fill(dt);
                   return dt;
               }
           }
       
       }

       public void asignaDVH(string tabla, string idCampo, int id, int dvh) {

           using (var con = new Conexion().conectar())
           {
               using (var cmd = new SqlCommand("Update " + tabla + " set dvh = " +dvh+
                                                " where " +idCampo+ " = "+id+"", con))
               {
                   cmd.ExecuteNonQuery();
               }
           }
       
       }
       
    }
}
