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

namespace Presentacion
{
    public partial class FrmFiltro : Form
    {
        ObjFiltro filtro;
        Negocio.nGestionAutos nGestion;

        public FrmFiltro()
        {
            InitializeComponent();
            nGestion = new nGestionAutos();
        }

        public void caputarFiltro()
        {
            try
            {
                string estilo = nGestion.validarEstilo(cbModelo.SelectedItem.ToString());
                filtro = new ObjFiltro()
                {
                    año = Convert.ToInt32(this.txtAño.Text),
                    color = cbColor.SelectedItem.ToString(),
                    marca = cbMarca.SelectedItem.ToString(),
                    modelo = cbModelo.SelectedItem.ToString(),
                    estilo = estilo
                };
            }
            catch (InvalidCastException e)
            {
                MessageBox.Show("ERROR ESPACIOS EN BLANCO", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.caputarFiltro();
            FrmAlquilerCarros alquiler = new FrmAlquilerCarros();
            alquiler.recibirFiltro(filtro);
            this.Hide();
            alquiler.Show();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FrmAlquilerCarros alquiler = new FrmAlquilerCarros();
            this.Hide();
            alquiler.Show();
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
    }
}
