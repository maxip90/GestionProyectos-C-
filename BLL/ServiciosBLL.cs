using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Common.Seguridad;

namespace BLL
{
    public class ServiciosBLL
    {

        public void listarRoles(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            DAL.ServiciosDAL serv = new DAL.ServiciosDAL();
            dt = serv.listarRolesIdioma("Select * from roles");

            cmb.DataSource = dt;
            cmb.DisplayMember = "rol_nombre";
            cmb.ValueMember = "id_rol";
        }

        public void listarIdiomas(ComboBox cmb) {
            DataTable dt = new DataTable();
            DAL.ServiciosDAL serv = new DAL.ServiciosDAL();
            dt = serv.listarRolesIdioma("Select * from idiomas");

            cmb.DataSource = dt;
            cmb.DisplayMember = "idioma_nombre";
            cmb.ValueMember = "id_idioma";
        }

        //OBTIENE ULTIMO REGISTRO DE UNA TABLA Y LO MANDA PARA CALCULAR EL DVH
        public void obtenerUltimoRegistro(string tabla, string idCampo) {

            DAL.ServiciosDAL serv = new DAL.ServiciosDAL();
            DataTable dt = serv.obtenerUltimoRegistro(tabla, idCampo);
            //CALCULAR DVH
            int dvh = 0;
            dvh = DigitoVerificador.CalcularDVH(dt);

            //BUSCO EL ID PARA PODER UPDATEAR EL CAMPO DVH CORRESPONDIENTE
            int idNum = 0;

            foreach (DataRow fila in dt.Rows)
            {
                idNum = Convert.ToInt32(fila[idCampo].ToString());
            }

            serv.asignaDVH(tabla, idCampo, idNum, dvh);

            
        }
        

    }
}
