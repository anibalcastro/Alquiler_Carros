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
using Objetos;
using Negocio;

namespace Presentacion
{
    public partial class FrmRegistro : Form
    {
        Objetos.ObjUsuarios objetos;
        Negocio.nInicio nLogin;
        public FrmRegistro()
        {
            InitializeComponent();
            nLogin = new nInicio();
            this.CrearXML();
            
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

        public void capturarDatos()
        {
            objetos = new ObjUsuarios()
            {
                cedula = Convert.ToInt32(txtCedula.Text),
                nombre = this.txtNombre.Text,
                genero = this.cbGenero.SelectedItem.ToString(),
                correo = this.txtCorreo.Text,
                contrasenna = this.txtContrasenna.Text,
                rol = 2   
            };
        }

        public void limpiar()
        {
            this.txtCedula.Clear();
            this.txtNombre.Clear();
            this.txtCorreo.Clear();
            this.txtContrasenna.Clear();
            this.cbGenero.SelectedIndex = 1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void pbLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.regresar();
        }

        public void regresar()
        {
            this.Hide();
            FrmLogin log = new FrmLogin();
            log.Show();
        }


        public void agregar()
        {
            this.capturarDatos();
            nLogin.RegistrarUsuario(objetos);
            MessageBox.Show("Usuario Registrado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.limpiar();
        }
        private void pbRegresar_Click(object sender, EventArgs e)
        {
            this.regresar();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.agregar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.agregar();
        }
    }
}
