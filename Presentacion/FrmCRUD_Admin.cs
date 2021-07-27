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
    public partial class FrmCRUD_Admin : Form
    {
        Negocio.nGestionAutos nGestion;
        Objetos.ObjCarros carros;

        bool existe_placa;
        string estado;

        
        public FrmCRUD_Admin()
        {
            InitializeComponent();
            nGestion = new nGestionAutos();
            this.CrearXML();
        }

        public void CrearXML()
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

        public void llenarTabla()
        {
            List<ObjCarros> lista = nGestion.llenarLista();

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
            this.dataGridView1.DataSource = carros;
        }

        public bool validarEspaciosBlancos()
        {
            bool valido = false;
            if(this.txtPlaca.Text == "" && this.txtAño.Text == "" && this.txtPrecio.Text == ""
                && cbMarca.SelectedItem.ToString() == "" && cbModelo.SelectedItem.ToString() == "" &&
                cbColor.SelectedItem.ToString() == "")
            {
                valido = true;
            }

            return valido;
        }

        public bool caputarDatos()
        {
            bool valido = false;
            if (this.validarEspaciosBlancos() == false)
            {
                string estilo = nGestion.validarEstilo(cbModelo.SelectedItem.ToString());
                string disponible = "Disponible";


                carros = new ObjCarros
                {
                    placa = this.txtPlaca.Text,
                    año = Convert.ToInt32(this.txtAño.Text),
                    precio = Convert.ToInt32(this.txtPrecio.Text),
                    marca = this.cbMarca.SelectedItem.ToString(),
                    modelo = this.cbModelo.SelectedItem.ToString(),
                    color = this.cbColor.SelectedItem.ToString(),
                    estilo = estilo,
                    estado = disponible
                };
                valido = true;
            }
            else
            {
                MessageBox.Show("Espacios vacios", "ERROS", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valido;
        }

        public void regresar()
        {
            this.limpiar();
            this.Hide();
            FrmDashboard dashboard = new FrmDashboard();
            dashboard.Show();
        }

        public void agregar()
        {
            if(existe_placa == false)
            {
                if (this.caputarDatos())
                {
                    nGestion.RegistrarCarros(carros);
                    MessageBox.Show("Carro Registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.limpiar();
                    this.llenarTabla();
                }
            }
          
        }

        public void modificar()
        {
            if (this.caputarDatos())
            {
                nGestion.Modificar(carros);
                MessageBox.Show("Carro Modificado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.limpiar();
                this.llenarTabla();
            }
           
        }

        public void eliminar()
        {
            if (this.caputarDatos())
            {
                nGestion.Eliminar(carros);
                MessageBox.Show("Carro Eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.limpiar();
                this.llenarTabla();
            }   
        }

        public void limpiar()
        {
            this.txtPlaca.Enabled = true;
            this.btnAgregar.Enabled = true;
            this.txtAño.Clear();
            this.txtPlaca.Clear();
            this.txtPrecio.Clear();

            this.cbMarca.SelectedIndex = 1;
            this.cbModelo.SelectedIndex = 1;
            this.cbColor.SelectedIndex = 1;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.regresar();
        }

        private void pbRegresar_Click(object sender, EventArgs e)
        {
            this.regresar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.agregar();
        }

        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {

            string marca = cbMarca.SelectedItem.ToString();
            cbModelo.Items.Clear();

            List<string> modelo = nGestion.modelos(marca);

            for (int x = 0; x < modelo.Count; x++)
            {
                cbModelo.Items.Add(modelo[x]);
            }
        }

        private void FrmCRUD_Admin_Load(object sender, EventArgs e)
        {
            this.llenarTabla();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.limpiar();
            this.btnAgregar.Enabled = false;
            if (e.RowIndex >= 0)
            {
                txtPlaca.Enabled = false;

                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtPlaca.Text = row.Cells["Placa"].Value.ToString();
                txtAño.Text = row.Cells["Año"].Value.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value.ToString();
                cbMarca.SelectedItem = row.Cells["Marca"].Value.ToString();
                cbModelo.SelectedItem = row.Cells["Modelo"].Value.ToString();
                cbColor.SelectedItem = row.Cells["Color"].Value.ToString();

                estado = row.Cells["Estado"].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (estado=="Disponible")
            {
                this.modificar();
            }
            else
            {
                MessageBox.Show("Vehiculo no se puede editar porque está alquilado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtPlaca_Validating(object sender, CancelEventArgs e)
        {
            string placa = this.txtPlaca.Text;

             existe_placa = nGestion.validarExistencia(placa);

            if (existe_placa)
            {
                MessageBox.Show("ERROR, PLACA YA EXISTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (estado == "Disponible")
            {
                this.eliminar();
            }
            else
            {
                MessageBox.Show("Vehiculo no se puede eliminar porque está alquilado", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pbEliminar_Click(object sender, EventArgs e)
        {
            this.eliminar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void pbLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            this.llenarTabla();
        }

        private void pbRefrescar_Click(object sender, EventArgs e)
        {
            this.llenarTabla();
        }
    }
}
