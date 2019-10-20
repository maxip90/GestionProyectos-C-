using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Cache;

namespace Gestion_Proyectos
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            cargaUserData();
        }

        //METODO CARGA DATOS DE USUARIO EN FORM
        public void cargaUserData() {

            lblNomUser.Text = UserCache.nombre + ", " + UserCache.apellido;
            lblRol.Text = UserCache.rol.ToString();
            
        }



        static int cont = 0;

        //BOTON CERRAR
        private void pbCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //BOTON MAXIMIZAR/MINIMIZAR
        private void pbMaxMin_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }

            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        //BOTON MINIMIZAR
        private void pbMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //METODO QUE CARGA PANEL PRINCIPAL CON FORM CORRESPONDIENTE

        
        public void abrirFormEnPanel(object formHijo) {
            
            
            if (this.panelPrincipal.Controls.Count > 0) {
                this.panelPrincipal.Controls.RemoveAt(0);
            }

            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelPrincipal.Controls.Add(fh);
            this.panelPrincipal.Tag = fh;
            fh.Show();
        }

       

        // CARGA FORM DE ADMINISTRADOR EN EL PANEL PRINCIPAL
        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            
            abrirFormEnPanel(new FormAdmin());
            //FormAdmin form = new FormAdmin();
            //form.ShowDialog();
        }

        private void horaFecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToShortTimeString() + " Hs";
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        

    }
}
