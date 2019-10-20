using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gestion_Proyectos
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

           
        

        private void FormAdmin_Load(object sender, EventArgs e)
        {

        }

       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormUsuarios);

            if (form != null) {
                form.BringToFront();
                return;
            }

            //aplicar singleton para no instanciar mil formularios
            this.panelAdmin.Controls.Clear();
            FormUsuarios formUsuario = new FormUsuarios();
            this.panelAdmin.Controls.Add(formUsuario.panelUser);
            this.Refresh();

            formUsuario.cargaCombos();
            formUsuario.cargarDgv();           
            
        }

        private void btnFamilias_Click(object sender, EventArgs e)
        {
            Form form = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormUsuarios);

            if (form != null)
            {
                form.BringToFront();
                return;
            }

            //aplicar singleton para no instanciar mil formularios
            this.panelAdmin.Controls.Clear();
            this.panelAdmin.Controls.Add(new FormFamilia().panelFamilia);
            this.Refresh();


        }
    }
}
