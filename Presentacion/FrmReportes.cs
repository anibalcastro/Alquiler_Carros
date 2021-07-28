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
    public partial class FrmReportes : Form
    {

        Negocio.nAlquilar nAlquiler;
        Negocio.nGestionAutos nGestion;

        List<ObjAlquiler> alquiler = new List<ObjAlquiler>();

        public FrmReportes()
        {
            InitializeComponent();
            nAlquiler = new nAlquilar();
            nGestion = new nGestionAutos();
            this.CrearXMLCarros();
            this.CrearXMLAlquiler();
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

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            this.formatoInicio();
            this.grafico();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDashboard admin = new FrmDashboard();
            admin.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmDashboard admin = new FrmDashboard();
            admin.Show();
        }

        public void formatoInicio()
        {
            this.dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.dtpHasta.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            this.dtpHasta.Value.AddDays(1);

             alquiler = nAlquiler.reporteFechas(this.dtpDesde.Value.Date, this.dtpHasta.Value.Date);
            this.llenarTabla(alquiler);
        }
            

        public void llenarTabla(List<ObjAlquiler> objAlquilers)
        {
            List<ObjAlquiler> lista = objAlquilers;

           

            DataTable Alquilados = new DataTable("Carros");

            DataColumn columna0 = new DataColumn("Placa");
            DataColumn columna1 = new DataColumn("Año");
            DataColumn columna2 = new DataColumn("Marca");
            DataColumn columna3 = new DataColumn("Modelo");
            DataColumn columna4 = new DataColumn("Estilo");
            DataColumn columna5 = new DataColumn("Silla");
            DataColumn columna6 = new DataColumn("GPS");
            DataColumn columna7 = new DataColumn("Cédula");
            DataColumn columna8 = new DataColumn("Nombre");
            DataColumn columna9 = new DataColumn("Correo Electronico");
            DataColumn columna10 = new DataColumn("Monto Total");

            Alquilados.Columns.Add(columna0);
            Alquilados.Columns.Add(columna1);
            Alquilados.Columns.Add(columna2);
            Alquilados.Columns.Add(columna3);
            Alquilados.Columns.Add(columna4);
            Alquilados.Columns.Add(columna5);
            Alquilados.Columns.Add(columna6);
            Alquilados.Columns.Add(columna7);
            Alquilados.Columns.Add(columna8);
            Alquilados.Columns.Add(columna9);
            Alquilados.Columns.Add(columna10);

            for (int x = 0; x < lista.Count; x++)
            {
                Alquilados.Rows.Add(lista[x].placa,
                    lista[x].año,
                    lista[x].marca,
                    lista[x].modelo,
                    lista[x].estilo,
                    lista[x].silla,
                    lista[x].gps,
                    lista[x].cedula,
                    lista[x].nombre,
                    lista[x].correo,
                    lista[x].monto_pagar);
            }
            this.dtgVehiculos.DataSource = Alquilados;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fecha_desde = dtpDesde.Value.Date;
            DateTime fecha_hasta = dtpHasta.Value.Date;

            alquiler = nAlquiler.reporteFechas(fecha_desde, fecha_hasta);
            this.llenarTabla(alquiler);
        }

        private void pbBuscar_Click(object sender, EventArgs e)
        {
            DateTime fecha_desde = dtpDesde.Value.Date;
            DateTime fecha_hasta = dtpHasta.Value.Date;

            alquiler = nAlquiler.reporteFechas(fecha_desde, fecha_hasta);
            this.llenarTabla(alquiler);
        }

        public void grafico()
        {
           
            String[] serie = { "Elantra", "Accent", "Corolla", "Yaris", "Sentra", "Tucson", "Rav4", "Pathfinder", "Qashqai" };
            int[] reporte = nAlquiler.marcasUtilizadas().ToArray();

            chartPorcentaje.Titles.Add("Porcentaje");
            
            chartPorcentaje.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;

            for (int x = 0; x < serie.Length; x++)
            {
                chartPorcentaje.Series["Series1"].Points.AddXY(serie[x], reporte[x]);
            }
        }
    }
}
