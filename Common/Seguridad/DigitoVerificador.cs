using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Common.Seguridad
{
   public class DigitoVerificador
    {

       public static int CalcularDVH(DataTable dt) {
           string concatenado = "";
           DataRow fila = dt.Rows[0];

           foreach (var valor in fila.ItemArray)
           {
               concatenado += valor;
           }

           byte[] bytes = Encoding.ASCII.GetBytes(concatenado);
           int dvh = BitConverter.ToInt32(bytes, 0);
           return dvh;


           
       }


    }
}
