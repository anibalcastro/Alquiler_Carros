
namespace Presentacion
{
    partial class FrmAlquilerCarros
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAlquilerCarros));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.cbGPS = new System.Windows.Forms.CheckBox();
            this.cbSilla = new System.Windows.Forms.CheckBox();
            this.dtpDevolucion = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpRetiro = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dupDias = new System.Windows.Forms.DomainUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAlquilar = new System.Windows.Forms.Button();
            this.btnFiltros = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPlaca = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtgCarros = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarros)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txtMonto);
            this.splitContainer1.Panel1.Controls.Add(this.cbGPS);
            this.splitContainer1.Panel1.Controls.Add(this.cbSilla);
            this.splitContainer1.Panel1.Controls.Add(this.dtpDevolucion);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.dtpRetiro);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.dupDias);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnSalir);
            this.splitContainer1.Panel1.Controls.Add(this.btnAlquilar);
            this.splitContainer1.Panel1.Controls.Add(this.btnFiltros);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtPlaca);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.SlateGray;
            this.splitContainer1.Panel2.Controls.Add(this.dtgCarros);
            this.splitContainer1.Size = new System.Drawing.Size(874, 637);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(46, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 18);
            this.label5.TabIndex = 42;
            this.label5.Text = "MONTO TOTAL A PAGAR:";
            // 
            // txtMonto
            // 
            this.txtMonto.Enabled = false;
            this.txtMonto.Location = new System.Drawing.Point(46, 440);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(198, 20);
            this.txtMonto.TabIndex = 41;
            // 
            // cbGPS
            // 
            this.cbGPS.AutoSize = true;
            this.cbGPS.BackColor = System.Drawing.Color.Black;
            this.cbGPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGPS.ForeColor = System.Drawing.Color.White;
            this.cbGPS.Location = new System.Drawing.Point(46, 370);
            this.cbGPS.Name = "cbGPS";
            this.cbGPS.Size = new System.Drawing.Size(55, 20);
            this.cbGPS.TabIndex = 40;
            this.cbGPS.Text = "GPS";
            this.cbGPS.UseVisualStyleBackColor = false;
            this.cbGPS.CheckedChanged += new System.EventHandler(this.cbGPS_CheckedChanged);
            // 
            // cbSilla
            // 
            this.cbSilla.AutoSize = true;
            this.cbSilla.BackColor = System.Drawing.Color.Black;
            this.cbSilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSilla.ForeColor = System.Drawing.Color.White;
            this.cbSilla.Location = new System.Drawing.Point(46, 318);
            this.cbSilla.Name = "cbSilla";
            this.cbSilla.Size = new System.Drawing.Size(210, 36);
            this.cbSilla.TabIndex = 39;
            this.cbSilla.Text = "SILLA DE SEGURIDAD PARA \r\nBEBÉS";
            this.cbSilla.UseVisualStyleBackColor = false;
            this.cbSilla.CheckedChanged += new System.EventHandler(this.cbSilla_CheckedChanged);
            // 
            // dtpDevolucion
            // 
            this.dtpDevolucion.Enabled = false;
            this.dtpDevolucion.Location = new System.Drawing.Point(46, 259);
            this.dtpDevolucion.Name = "dtpDevolucion";
            this.dtpDevolucion.Size = new System.Drawing.Size(198, 20);
            this.dtpDevolucion.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(46, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 18);
            this.label4.TabIndex = 37;
            this.label4.Text = "FECHA DE DEVOLUCIÓN:";
            // 
            // dtpRetiro
            // 
            this.dtpRetiro.Location = new System.Drawing.Point(46, 184);
            this.dtpRetiro.Name = "dtpRetiro";
            this.dtpRetiro.Size = new System.Drawing.Size(198, 20);
            this.dtpRetiro.TabIndex = 36;
            this.dtpRetiro.Value = new System.DateTime(2021, 7, 21, 21, 43, 57, 0);
            this.dtpRetiro.ValueChanged += new System.EventHandler(this.dtpRetiro_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(46, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 18);
            this.label3.TabIndex = 35;
            this.label3.Text = "FECHA DE RETIRO:";
            // 
            // dupDias
            // 
            this.dupDias.Items.Add("1");
            this.dupDias.Items.Add("2");
            this.dupDias.Items.Add("3");
            this.dupDias.Items.Add("4");
            this.dupDias.Items.Add("5");
            this.dupDias.Items.Add("6");
            this.dupDias.Items.Add("7");
            this.dupDias.Items.Add("8");
            this.dupDias.Items.Add("9");
            this.dupDias.Items.Add("10");
            this.dupDias.Items.Add("11");
            this.dupDias.Items.Add("12");
            this.dupDias.Items.Add("13");
            this.dupDias.Items.Add("14");
            this.dupDias.Items.Add("15");
            this.dupDias.Items.Add("16");
            this.dupDias.Items.Add("17");
            this.dupDias.Items.Add("18");
            this.dupDias.Items.Add("19");
            this.dupDias.Items.Add("20");
            this.dupDias.Items.Add("21");
            this.dupDias.Items.Add("22");
            this.dupDias.Items.Add("23");
            this.dupDias.Items.Add("24");
            this.dupDias.Items.Add("25");
            this.dupDias.Items.Add("26");
            this.dupDias.Items.Add("27");
            this.dupDias.Items.Add("28");
            this.dupDias.Items.Add("29");
            this.dupDias.Items.Add("30");
            this.dupDias.Items.Add("31");
            this.dupDias.Items.Add("32");
            this.dupDias.Items.Add("33");
            this.dupDias.Items.Add("34");
            this.dupDias.Items.Add("35");
            this.dupDias.Items.Add("36");
            this.dupDias.Items.Add("37");
            this.dupDias.Items.Add("38");
            this.dupDias.Items.Add("39");
            this.dupDias.Items.Add("40");
            this.dupDias.Items.Add("41");
            this.dupDias.Items.Add("42");
            this.dupDias.Items.Add("43");
            this.dupDias.Items.Add("44");
            this.dupDias.Items.Add("45");
            this.dupDias.Items.Add("46");
            this.dupDias.Items.Add("47");
            this.dupDias.Items.Add("48");
            this.dupDias.Items.Add("49");
            this.dupDias.Items.Add("50");
            this.dupDias.Items.Add("51");
            this.dupDias.Items.Add("52");
            this.dupDias.Items.Add("53");
            this.dupDias.Items.Add("54");
            this.dupDias.Items.Add("55");
            this.dupDias.Items.Add("56");
            this.dupDias.Items.Add("57");
            this.dupDias.Items.Add("58");
            this.dupDias.Items.Add("59");
            this.dupDias.Items.Add("60");
            this.dupDias.Location = new System.Drawing.Point(175, 108);
            this.dupDias.Name = "dupDias";
            this.dupDias.Size = new System.Drawing.Size(69, 20);
            this.dupDias.TabIndex = 0;
            this.dupDias.Text = "1";
            this.dupDias.SelectedItemChanged += new System.EventHandler(this.dupDias_SelectedItemChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(46, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 18);
            this.label2.TabIndex = 34;
            this.label2.Text = "CANTIDAD DÍAS:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.Black;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(49, 592);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(195, 28);
            this.btnSalir.TabIndex = 32;
            this.btnSalir.Text = "REGRESAR";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAlquilar
            // 
            this.btnAlquilar.BackColor = System.Drawing.Color.Black;
            this.btnAlquilar.ForeColor = System.Drawing.Color.White;
            this.btnAlquilar.Location = new System.Drawing.Point(49, 558);
            this.btnAlquilar.Name = "btnAlquilar";
            this.btnAlquilar.Size = new System.Drawing.Size(195, 28);
            this.btnAlquilar.TabIndex = 31;
            this.btnAlquilar.Text = "ALQUILAR";
            this.btnAlquilar.UseVisualStyleBackColor = false;
            this.btnAlquilar.Click += new System.EventHandler(this.btnAlquilar_Click);
            // 
            // btnFiltros
            // 
            this.btnFiltros.BackColor = System.Drawing.Color.LawnGreen;
            this.btnFiltros.Location = new System.Drawing.Point(49, 524);
            this.btnFiltros.Name = "btnFiltros";
            this.btnFiltros.Size = new System.Drawing.Size(195, 28);
            this.btnFiltros.TabIndex = 30;
            this.btnFiltros.Text = "FILTRAR";
            this.btnFiltros.UseVisualStyleBackColor = false;
            this.btnFiltros.Click += new System.EventHandler(this.btnFiltros_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 24;
            this.label1.Text = "PLACA:";
            // 
            // txtPlaca
            // 
            this.txtPlaca.Enabled = false;
            this.txtPlaca.Location = new System.Drawing.Point(46, 67);
            this.txtPlaca.Name = "txtPlaca";
            this.txtPlaca.Size = new System.Drawing.Size(198, 20);
            this.txtPlaca.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(292, 637);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // dtgCarros
            // 
            this.dtgCarros.AllowUserToAddRows = false;
            this.dtgCarros.AllowUserToDeleteRows = false;
            this.dtgCarros.BackgroundColor = System.Drawing.Color.DimGray;
            this.dtgCarros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgCarros.Location = new System.Drawing.Point(3, 6);
            this.dtgCarros.Name = "dtgCarros";
            this.dtgCarros.Size = new System.Drawing.Size(573, 631);
            this.dtgCarros.TabIndex = 0;
            this.dtgCarros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgCarros_CellClick);
            // 
            // FrmAlquilerCarros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 637);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAlquilerCarros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALQUILER";
            this.Load += new System.EventHandler(this.FrmAlquilerCarros_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgCarros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.CheckBox cbGPS;
        private System.Windows.Forms.CheckBox cbSilla;
        private System.Windows.Forms.DateTimePicker dtpDevolucion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpRetiro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DomainUpDown dupDias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAlquilar;
        private System.Windows.Forms.Button btnFiltros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPlaca;
        private System.Windows.Forms.DataGridView dtgCarros;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}