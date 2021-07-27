using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Objetos;
using Negocio;
using System.IO;

namespace Presentacion
{
    public partial class FrmAlquilerCarros : Form
    {

        ObjFiltro filtro;
        ObjUsuarios usuario;
        ObjAlquiler objeto;
        nGestionAutos nGestion;
        nAlquilar nAlquiler;

        int dias = 1;
        int monto_dia;
        int monto_total;

        string placa;
        int año_carro;
        string marca;
        string modelo;
        string estilo;
        string color;
        string silla = "No";
        string gps = "No";

      

        public FrmAlquilerCarros()
        {
            InitializeComponent();
            nGestion = new nGestionAutos();
            nAlquiler = new nAlquilar();
            this.CrearXMLCarros();
            this.CrearXMLAlquiler();
            this.CrearXMLAlquilerCopia();
        }

        public void CrearXMLCarros()
        {
            if (!File.Exists(@"C:\Users\admin\source\repos\Alquiler_Carros\Datos\ArchivosXML\Carros.XML"))
            {
                nGestion.CrearXML(@"C:\Users\admin\source\repos\Alquiler_Carros\Datos\ArchivosXML\Carros.XML", "Adobe");
            }
            else
            {
                nGestion.LeerXML(@"C:\Users\admin\source\repos\Alquiler_Carros\Datos\ArchivosXML\Carros.XML");
            }
        }

        public void CrearXMLAlquiler()
        {
            if (!File.Exists(@"C:\Users\admin\source\repos\Alquiler_Carros\Datos\ArchivosXML\Alquiler.XML"))
            {
                nAlquiler.CrearXML(@"C:\Users\admin\source\repos\Alquiler_Carros\Datos\ArchivosXML\Alquiler.XML", "Alquilados");
            }
            else
            {
                nAlquiler.LeerXML(@"C:\Users\admin\source\repos\Alquiler_Carros\Datos\ArchivosXML\Alquiler.XML");
            }
        }

        public void CrearXMLAlquilerCopia()
        {
            nAlquiler.CrearXMLCopia(@"C:\Users\admin\source\repos\Alquiler_Carros\Datos\ArchivosXML\AlquilerCopia.XML", "Alquilados");
          
        }

        public void recibirFiltro(ObjFiltro objetos)
        {
            filtro = objetos;
        }

        public void recibirUsuario(ObjUsuarios usu)
        {
            usuario = usu;
        }

        public void capturarDatos()
        {
            objeto = new ObjAlquiler
            {
                cedula = usuario.cedula,
                nombre = usuario.nombre,
                genero = usuario.genero,
                correo = usuario.correo,

                placa = txtPlaca.Text,
                año = año_carro,
                marca = marca,
                modelo = modelo,
                estilo = estilo,
                color = color,
                silla = silla,
                gps = gps,
                dias = Convert.ToInt32(dupDias.SelectedItem.ToString()),
                monto_pagar = Convert.ToInt32(txtMonto.Text),
                fecha_retiro = dtpRetiro.Value.Date,
                fecha_devolucion = dtpDevolucion.Value.Date
            };
        }

        public void llenarTabla()
        {
            List<ObjCarros> lista = nGestion.llenarListaDisponibles();

            DataTable carros = new DataTable("Carros");
            DataColumn columna0 = new DataColumn("Placa");
            DataColumn columna1 = new DataColumn("Año");
            DataColumn columna2 = new DataColumn("Precio");
            DataColumn columna3 = new DataColumn("Marca");
            DataColumn columna4 = new DataColumn("Modelo");
            DataColumn columna5 = new DataColumn("Color");
            DataColumn columna7 = new DataColumn("Estilo");
            DataColumn columna6 = new DataColumn("Estado");

            carros.Columns.Add(columna0);
            carros.Columns.Add(columna1);
            carros.Columns.Add(columna2);
            carros.Columns.Add(columna3);
            carros.Columns.Add(columna4);
            carros.Columns.Add(columna5);
            carros.Columns.Add(columna7);
            carros.Columns.Add(columna6);


            for (int x = 0; x < lista.Count; x++)
            {
                carros.Rows.Add(lista[x].placa,
                    lista[x].año,
                    lista[x].precio,
                    lista[x].marca,
                    lista[x].modelo,
                    lista[x].color,
                    lista[x].estilo,
                    lista[x].estado);
            }
            this.dtgCarros.DataSource = carros;
        }

        public void llenarTablaFiltrado(ObjFiltro filtro)
        {
            List<ObjCarros> lista = nGestion.llenarListaDisponiblesFiltrados(filtro);

            DataTable carros = new DataTable("Carros");
            DataColumn columna0 = new DataColumn("Placa");
            DataColumn columna1 = new DataColumn("Año");
            DataColumn columna2 = new DataColumn("Precio");
            DataColumn columna3 = new DataColumn("Marca");
            DataColumn columna4 = new DataColumn("Modelo");
            DataColumn columna5 = new DataColumn("Color");
            DataColumn columna7 = new DataColumn("Estilo");
            DataColumn columna6 = new DataColumn("Estado");

            carros.Columns.Add(columna0);
            carros.Columns.Add(columna1);
            carros.Columns.Add(columna2);
            carros.Columns.Add(columna3);
            carros.Columns.Add(columna4);
            carros.Columns.Add(columna5);
            carros.Columns.Add(columna7);
            carros.Columns.Add(columna6);


            for (int x = 0; x < lista.Count; x++)
            {
                carros.Rows.Add(lista[x].placa,
                    lista[x].año,
                    lista[x].precio,
                    lista[x].marca,
                    lista[x].modelo,
                    lista[x].color,
                    lista[x].estilo,
                    lista[x].estado);
            }
            this.dtgCarros.DataSource = carros;
        }

        private void FrmAlquilerCarros_Load(object sender, EventArgs e)
        {
            if (filtro == null)
            {
                this.llenarTabla();
                this.formatoFechas();
            }
            else
            {
                this.llenarTablaFiltrado(filtro);
            }
        }

        private void btnFiltros_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmFiltro filtro = new FrmFiltro();
            filtro.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void dupDias_SelectedItemChanged(object sender, EventArgs e)
        {
             dias = Convert.ToInt32(dupDias.SelectedItem.ToString());

            DateTime fecha_actual = dtpRetiro.Value.Date;
            dtpDevolucion.Value = nAlquiler.fecha_Devolucion(fecha_actual, dias);

            this.monto_por_dia();

        }

        private void dtpRetiro_ValueChanged(object sender, EventArgs e)
        {
            DateTime fecha_actual = dtpRetiro.Value.Date;
            dtpDevolucion.Value = nAlquiler.fecha_Devolucion(fecha_actual, dias);
        }

        public void mostrarPrecio()
        {
            this.txtMonto.Text = Convert.ToString(monto_total);
        }

        private void dtgCarros_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                txtPlaca.Enabled = false;

                DataGridViewRow row = dtgCarros.Rows[e.RowIndex];

                txtPlaca.Text = row.Cells["Placa"].Value.ToString();
                marca = row.Cells["Marca"].Value.ToString();
                modelo = row.Cells["Modelo"].Value.ToString();
                estilo = row.Cells["Estilo"].Value.ToString();
                color = row.Cells["Color"].Value.ToString();
                año_carro = Convert.ToInt32(row.Cells["Año"].Value.ToString());

                placa = row.Cells["Placa"].Value.ToString();

                monto_dia = nGestion.validarPrecio(placa);

                this.monto_por_dia();

            }
        }

        public void monto_por_dia()
        {
            monto_total = monto_dia * dias;
            this.mostrarPrecio();
        }

        private void cbSilla_CheckedChanged(object sender, EventArgs e)
        {
            

            if (cbSilla.Checked == true)
            {
                this.silla_12();
                this.silla = "Si";
            }
           
                

        }

        public void silla_12()
        {
            int monto_silla = ((int)(monto_total * 0.12));
            monto_total = monto_total + monto_silla;
            this.mostrarPrecio();

           
        }

        private void cbGPS_CheckedChanged(object sender, EventArgs e)
        {
        
            if (cbGPS.Checked == true)
            {
                this.gps_30();
                this.gps = "Si";
            }
          

        }

        public void formatoFechas()
        {
            this.dtpRetiro.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.dtpDevolucion.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        public void gps_30()
        {
            int monto_gps = (int)(monto_total * 0.30);
            monto_total = monto_total + monto_gps;
            this.mostrarPrecio();

        }

        public void limpiar()
        {
            this.txtPlaca.Clear();
            this.txtMonto.Clear();
            this.modelo = "";
            this.marca = "";
            this.año_carro = 0;
            this.color = "";
            this.estilo = "";
            this.dias = 1;
            this.monto_dia = 0;
            this.monto_total = 0;
            this.silla = "No";
            this.gps = "No";

            this.dtpRetiro.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.dtpDevolucion.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            objeto = null;
            filtro = null;
            this.cbGPS.Checked = false;
            this.cbSilla.Checked = false;
        }

        private void btnAlquilar_Click(object sender, EventArgs e)
        {
            string archivo = @"C:\Users\admin\source\repos\Alquiler_Carros\Datos\ArchivosXML\AlquilerCopia.XML";
            this.capturarDatos();
            nAlquiler.RegistrarAlquiler(objeto);
            nAlquiler.RegistrarAlquilerCopia(objeto);
           nGestion.modificarDisponibilidad(placa);
           MessageBox.Show("Vehiculo alquilado", "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
           nAlquiler.enviarEmail(usuario.correo,archivo);
           this.limpiar();
           this.llenarTabla();
        }
    }
}
