namespace FotoCek.Client
{
    partial class Raporlama
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
            this.dtBaslangicZamani = new System.Windows.Forms.DateTimePicker();
            this.drpPlakaKonumu = new System.Windows.Forms.ComboBox();
            this.dtBitisZamani = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grdRapor = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblToplam = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pctGirenKisiResmi = new System.Windows.Forms.PictureBox();
            this.btnExcel = new System.Windows.Forms.PictureBox();
            this.btnGetir = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdRapor)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctGirenKisiResmi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGetir)).BeginInit();
            this.SuspendLayout();
            // 
            // dtBaslangicZamani
            // 
            this.dtBaslangicZamani.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtBaslangicZamani.Font = new System.Drawing.Font("Neo Sans TR", 15F);
            this.dtBaslangicZamani.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBaslangicZamani.Location = new System.Drawing.Point(183, 50);
            this.dtBaslangicZamani.Name = "dtBaslangicZamani";
            this.dtBaslangicZamani.Size = new System.Drawing.Size(291, 32);
            this.dtBaslangicZamani.TabIndex = 33;
            // 
            // drpPlakaKonumu
            // 
            this.drpPlakaKonumu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpPlakaKonumu.Font = new System.Drawing.Font("Neo Sans TR", 15F);
            this.drpPlakaKonumu.FormattingEnabled = true;
            this.drpPlakaKonumu.Items.AddRange(new object[] {
            "Turnike 1"});
            this.drpPlakaKonumu.Location = new System.Drawing.Point(183, 15);
            this.drpPlakaKonumu.Name = "drpPlakaKonumu";
            this.drpPlakaKonumu.Size = new System.Drawing.Size(291, 32);
            this.drpPlakaKonumu.TabIndex = 32;
            // 
            // dtBitisZamani
            // 
            this.dtBitisZamani.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtBitisZamani.Font = new System.Drawing.Font("Neo Sans TR", 15F);
            this.dtBitisZamani.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBitisZamani.Location = new System.Drawing.Point(183, 84);
            this.dtBitisZamani.Name = "dtBitisZamani";
            this.dtBitisZamani.Size = new System.Drawing.Size(291, 32);
            this.dtBitisZamani.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("NeoSans Light TR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(12, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 19);
            this.label6.TabIndex = 21;
            this.label6.Text = "Bitiş Zamanı";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("NeoSans Light TR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "Başlangıç Zamanı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("NeoSans Light TR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 19);
            this.label4.TabIndex = 19;
            this.label4.Text = "Turnike";
            // 
            // grdRapor
            // 
            this.grdRapor.AllowUserToAddRows = false;
            this.grdRapor.AllowUserToDeleteRows = false;
            this.grdRapor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdRapor.BackgroundColor = System.Drawing.Color.White;
            this.grdRapor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdRapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRapor.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdRapor.Location = new System.Drawing.Point(5, 5);
            this.grdRapor.MultiSelect = false;
            this.grdRapor.Name = "grdRapor";
            this.grdRapor.ReadOnly = true;
            this.grdRapor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdRapor.ShowEditingIcon = false;
            this.grdRapor.Size = new System.Drawing.Size(469, 308);
            this.grdRapor.TabIndex = 0;
            this.grdRapor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRapor_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.pctGirenKisiResmi);
            this.panel2.Controls.Add(this.grdRapor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 132);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(800, 318);
            this.panel2.TabIndex = 51;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.lblToplam);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnExcel);
            this.panel1.Controls.Add(this.dtBaslangicZamani);
            this.panel1.Controls.Add(this.drpPlakaKonumu);
            this.panel1.Controls.Add(this.dtBitisZamani);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnGetir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 132);
            this.panel1.TabIndex = 50;
            // 
            // lblToplam
            // 
            this.lblToplam.AutoSize = true;
            this.lblToplam.Font = new System.Drawing.Font("NeoSans Light TR", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblToplam.ForeColor = System.Drawing.Color.White;
            this.lblToplam.Location = new System.Drawing.Point(569, 84);
            this.lblToplam.Name = "lblToplam";
            this.lblToplam.Size = new System.Drawing.Size(22, 22);
            this.lblToplam.TabIndex = 36;
            this.lblToplam.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("NeoSans Light TR", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(491, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 35;
            this.label1.Text = "Toplam : ";
            // 
            // pctGirenKisiResmi
            // 
            this.pctGirenKisiResmi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pctGirenKisiResmi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pctGirenKisiResmi.Location = new System.Drawing.Point(474, 5);
            this.pctGirenKisiResmi.Name = "pctGirenKisiResmi";
            this.pctGirenKisiResmi.Size = new System.Drawing.Size(321, 308);
            this.pctGirenKisiResmi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctGirenKisiResmi.TabIndex = 1;
            this.pctGirenKisiResmi.TabStop = false;
            this.pctGirenKisiResmi.DoubleClick += new System.EventHandler(this.pctGirenKisiResmi_DoubleClick);
            // 
            // btnExcel
            // 
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.Image = global::FotoCek.Client.Properties.Resources.btnExcel;
            this.btnExcel.Location = new System.Drawing.Point(644, 15);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(122, 42);
            this.btnExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnExcel.TabIndex = 34;
            this.btnExcel.TabStop = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnGetir
            // 
            this.btnGetir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetir.Image = global::FotoCek.Client.Properties.Resources.btnGetir;
            this.btnGetir.Location = new System.Drawing.Point(495, 15);
            this.btnGetir.Name = "btnGetir";
            this.btnGetir.Size = new System.Drawing.Size(122, 42);
            this.btnGetir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnGetir.TabIndex = 16;
            this.btnGetir.TabStop = false;
            this.btnGetir.Click += new System.EventHandler(this.btnGetir_Click);
            // 
            // Raporlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Raporlama";
            this.Text = "Raporlama";
            ((System.ComponentModel.ISupportInitialize)(this.grdRapor)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctGirenKisiResmi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGetir)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctGirenKisiResmi;
        private System.Windows.Forms.DateTimePicker dtBaslangicZamani;
        private System.Windows.Forms.ComboBox drpPlakaKonumu;
        private System.Windows.Forms.DateTimePicker dtBitisZamani;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grdRapor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblToplam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnExcel;
        private System.Windows.Forms.PictureBox btnGetir;
    }
}