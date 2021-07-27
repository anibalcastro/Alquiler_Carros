using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Objetos;

namespace Presentacion
{
    public partial class FrmLogin : Form
    {

        Negocio.nInicio nLogin;
        public FrmLogin()
        {
            InitializeComponent();
            nLogin = new nInicio();
            CrearXML();
          
        }


        public void CrearXML()
        {
            if (!File.Exists(@"C:\Users\admin\source\repos\Alquiler_Carros\Datos\ArchivosXML\Usuarios.XML"))
            {
                nLogin.CrearXML(@"C:\Users\admin\source\repos\Alquiler_Carros\Datos\ArchivosXML\Usuarios.XML", "Login");
            }
            else
            {
                nLogin.LeerXML(@"C:\Users\admin\source\repos\Alquiler_Carros\Datos\ArchivosXML\Usuarios.XML");
            }
        }

      


        /// <summary>
        /// Secciones del app
        /// ADMIN FrmDashboard
        /// Usuario FrmUsuario
        /// </summary>
        /// <param name="rol"></param>
        public void roles(int rol)
        {
            if (rol.Equals(1))
            {
                //Admin
                this.Hide();
                FrmDashboard admin = new FrmDashboard();
                admin.Show();
            } 
            else
            {
                FrmAlquilerCarros alquiler = new FrmAlquilerCarros();
                alquiler.recibirUsuario(nLogin.retornarInfo());
                alquiler.Show();
                this.Hide();
            }

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            int user = Convert.ToInt32(this.txtUsuario.Text);
            string password = this.txtContrasena.Text;


            bool valido = nLogin.validarUsuario(user, password);
            int rol = nLogin.retornarRol();

            if (valido)
            {
                MessageBox.Show("Bienvenido", "Bienvenida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.roles(rol);
            }
            else
            {
                MessageBox.Show("Usuario o contraseña son incorrectas", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmRegistro registro = new FrmRegistro();
            registro.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmRegistro registro = new FrmRegistro();
            registro.Show();
        }
    }
}
