using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin log = new FrmLogin();
            log.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin log = new FrmLogin();
            log.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCRUD_Admin admin = new FrmCRUD_Admin();
            admin.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmCRUD_Admin crud = new FrmCRUD_Admin();
            crud.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmReportes reportes = new FrmReportes();
            reportes.Show();

        }
    }
}
