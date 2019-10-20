using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using System.Windows.Forms;
using Common.Seguridad;
using Common.Cache;

namespace BLL
{
    public class UsuarioBLL
    {
        private string tabla = "usuarios";
        private string idCampo = "id_usuario";

        public void registrar(BE.Usuario user) {
            
            //GENERA EL USUARIO Y LA PRIMER CONTRASENIA
            generaUserAndPass(user);
            UsuarioDAL userDAL = new UsuarioDAL();
            userDAL.alta(user);
            //BUSCA EL ULTIMO REGISTRO PARA CALCULAR Y ASIGNAR EL DVH
            ServiciosBLL serv = new ServiciosBLL();
            serv.obtenerUltimoRegistro(tabla, idCampo);
            
        }

        public void listar(DataGridView dgv) {
            
            DataTable dt = new DataTable();
            UsuarioDAL userDAL = new UsuarioDAL();
            dt = userDAL.listar();

            dgv.DataSource = null;
            dgv.DataSource = dt;
            dgv.Columns["dvh"].Visible = false;
            dgv.Columns["usu_nomuser"].Visible = false;
            dgv.Columns["usu_passuser"].Visible = false;
            
                    
        }

        public void eliminar(string id) {
            
            UsuarioDAL userDAL = new UsuarioDAL();
            userDAL.eliminar(Convert.ToInt32(id));
            
            
        }

       
        public BE.Usuario generaUserAndPass(BE.Usuario user) {

            user.usuNomUser = user.usuNombre.Substring(0, 2).ToLower() + user.usuApellido.ToLower();
            //ENCRIPTA NOMBRE DE USUARIO
            user.usuNomUser = Encriptar.encriptar3DES(user.usuNomUser, Encriptar.llave);
            //ENCRIPTA PASS
            user.usuPassUser = Encriptar.encriptarMD5("123456");
            return user;
        }


        public bool loginUser(string user, string pass) {
            UsuarioDAL userDAL = new UsuarioDAL();
            
            return userDAL.Login(Encriptar.encriptar3DES(user, Encriptar.llave), Encriptar.encriptarMD5(pass));
        }

        //SEGUIR CON LA VALIDACION DE Y COMPARACION DEL NOMUSER EN LA BD PARA LOGUEAR


        //CONTINUAR CON LA VERIFICACION DE LOS PERMISOS
        //public bool tienePermiso() {

        //    DAL.SeguridadDAL segDAL = new SeguridadDAL();
            
        //}


        public void obtenerRegistro() { 
        
            
        }
    }
}
