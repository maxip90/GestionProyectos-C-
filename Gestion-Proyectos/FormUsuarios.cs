using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Common.Seguridad;

namespace Gestion_Proyectos
{
    public partial class FormUsuarios : Form
    {
        UsuarioBLL userBLL = new UsuarioBLL();
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.panelUser.Controls.Clear();
        }

        private void btnRegistraUser_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            user.usuNombre = txtNombreUsuario.Text;
            user.usuApellido = txtApellidoUsuario.Text;
            user.idIdioma = Convert.ToInt32(cmbIdioma.SelectedValue);
            user.idRol = Convert.ToInt32(cmbRol.SelectedValue);
            user.usuMail = txtEmailUsuario.Text;
            user.fechaNac = dtpFechaNac.Value;

            userBLL.registrar(user);
            limpiaCampos();
            userBLL.listar(dgvUsers);

            //MessageBox.Show(Encriptar.encriptar3DES(user.usuNomUser, Encriptar.llave));
            //MessageBox.Show(Encriptar.desencriptar3DES(Encriptar.encriptar3DES(user.usuNomUser, Encriptar.llave), Encriptar.llave));
        }

        
        //METODO PARA CARGAR COMBOS
        public void cargaCombos()
        {
            
            ServiciosBLL serv = new ServiciosBLL();
            serv.listarRoles(cmbRol);
            serv.listarIdiomas(cmbIdioma);          


        }

        //METODO PARA LIMPIAR CAMPOS DEL FORM USUARIO
        public void limpiaCampos() {
            
            txtNombreUsuario.Clear();
            txtApellidoUsuario.Clear();
            txtEmailUsuario.Clear();
            cmbIdioma.SelectedIndex = 0;
            cmbRol.SelectedIndex = 0;
            txtNombreUsuario.Focus();

        }

        //METODO QUE CARGA DGV CON EL LSITADO DE USUARIOS
        public void cargarDgv() {
           
            UsuarioBLL userBLL = new UsuarioBLL();
            userBLL.listar(dgvUsers);
                        
        }


        private void FormUsuarios_Load(object sender, EventArgs e)
        {

            
        }

        private void btnBajaUser_Click(object sender, EventArgs e)
        {
            string idUser = null;

            if (dgvUsers.SelectedRows.Count > 0)
            {
                idUser = dgvUsers.CurrentRow.Cells["id_usuario"].Value.ToString();
                userBLL.eliminar(idUser);
            }

            userBLL.listar(dgvUsers);
        }
    }
}
