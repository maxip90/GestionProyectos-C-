using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace Gestion_Proyectos
{
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormLogIn_Load(object sender, EventArgs e)
        {
            txtUser.Focus();
            lblError.Visible = false;
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "")
            {
                if (txtPass.Text != "")
                {
                    
                    UsuarioBLL userBLL = new UsuarioBLL();
                    var loginOK = userBLL.loginUser(txtUser.Text.ToLower(), txtPass.Text);

                    if (loginOK == true)
                    {
                        FormPrincipal mainMenu = new FormPrincipal();
                        mainMenu.Show();
                        this.Hide();
                    }
                    else
                    {
                        msjError("Usuario o contraseña incorrectos, intete de nuevo");
                        txtUser.Clear();
                        txtPass.Clear();
                        txtUser.Focus();
                    }
                }
                else msjError("Ingresar Contraseña");
                   
            }
            else msjError("Ingresar Usuario");
            
        }

        private void msjError(string msj) {
            lblError.Text = "     " + msj;
            lblError.Visible = true;
        
        }
    }
}
