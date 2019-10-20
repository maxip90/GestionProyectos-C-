using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using Common.Cache;
using Common.Seguridad;

namespace DAL
{
    public class UsuarioDAL
    {

        public void alta(BE.Usuario user) {

            using (var con = new Conexion().conectar()) {
                using (var cmd = new SqlCommand("altaUser", con)) {

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@usu_nombre", SqlDbType.VarChar).Value = user.usuNombre;
                    cmd.Parameters.Add("@usu_apellido", SqlDbType.VarChar).Value = user.usuApellido;
                    cmd.Parameters.Add("@usu_fechanac", SqlDbType.Date).Value = user.fechaNac;
                    cmd.Parameters.Add("@usu_mail", SqlDbType.VarChar).Value = user.usuMail;
                    cmd.Parameters.Add("@usu_nomuser", SqlDbType.VarChar).Value = user.usuNomUser;
                    cmd.Parameters.Add("@usu_passuser", SqlDbType.VarChar).Value = user.usuPassUser;
                    cmd.Parameters.Add("@id_idioma", SqlDbType.Int).Value = user.idIdioma;
                    cmd.Parameters.Add("@usu_bloqueado", SqlDbType.Bit).Value = user.usuBloqueado;
                    cmd.Parameters.Add("@usu_estado", SqlDbType.Bit).Value = user.usuEstado;
                    cmd.Parameters.Add("@id_equipo", SqlDbType.Int).Value = user.idEquipo;
                    cmd.Parameters.Add("@id_rol", SqlDbType.Int).Value = user.idRol;
                    cmd.Parameters.Add("@usu_cii", SqlDbType.Int).Value = user.usuCii;

                    //EJECUTA CONSULTA, OBTENGO ID PARA BUSCAR EL REGISTRO Y CALCULAR EL DVH
                    try
                    {
                        cmd.ExecuteNonQuery();
                                                
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Se produjo un error. " + ex.Message);

                    }
                }
            }
                   
        }


        public DataTable listar() {

            using(var con = new Conexion().conectar()){
                using (var da = new SqlDataAdapter("Select * from usuarios", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;                    
                }            
            }


        }

        public void eliminar(int id) {
            using (var con = new Conexion().conectar())
            {
                using (var cmd = new SqlCommand("eliminarUser",con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_usuario", id);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo eliminar" + ex.Message);
                        throw;
                    }
                }
            }
        }

        //ASIGNA DVH A LA TABLA
        public void asignaDVH(int dvh) {

            using (var con = new Conexion().conectar())
            {
                using (var cmd = new SqlCommand("", con))
                {
                    
                }
            }
        }


        //METODO LOGIN 
        public bool Login(string user, string pass) {

            using (var con = new Conexion().conectar())
            {
                using (var cmd = new SqlCommand("Select * from usuarios where usu_nomuser = @user and usu_passuser = @pass", con))
                {
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.CommandType = CommandType.Text;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            UserCache.id = dr.GetInt32(0);
                            UserCache.nombre = dr.GetString(1);
                            UserCache.apellido = dr.GetString(2);
                            UserCache.mail = dr.GetString(4);
                            UserCache.rol = dr.GetInt32(11);
                            
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        
        }

        //METODO LOGOUT
        public void Logout(object sender, FormClosedEventArgs e) { 
        
            
        }



        //CREO QUE HAY QUE BORRARLO
        public void obtenerRegistro(string tabla) {

            using (var con = new Conexion().conectar())
            {
                using (var da = new SqlDataAdapter("Select top 1 * from " + tabla, con))
                {
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    //DigitoVerificador.CalcularDVH(dt);


                }
            }
        }

    }
}
