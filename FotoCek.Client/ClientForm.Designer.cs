namespace FotoCek.Client
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbxGirenKisiResmi = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgConnectionStatus = new System.Windows.Forms.PictureBox();
            this.lblTarih = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRaporlama = new System.Windows.Forms.PictureBox();
            this.tmrSaat = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGirenKisiResmi)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgConnectionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRaporlama)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.pbxGirenKisiResmi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(5);
            this.panel2.Size = new System.Drawing.Size(713, 586);
            this.panel2.TabIndex = 53;
            // 
            // pbxGirenKisiResmi
            // 
            this.pbxGirenKisiResmi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxGirenKisiResmi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxGirenKisiResmi.Location = new System.Drawing.Point(5, 5);
            this.pbxGirenKisiResmi.Name = "pbxGirenKisiResmi";
            this.pbxGirenKisiResmi.Size = new System.Drawing.Size(703, 576);
            this.pbxGirenKisiResmi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxGirenKisiResmi.TabIndex = 1;
            this.pbxGirenKisiResmi.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.imgConnectionStatus);
            this.panel1.Controls.Add(this.lblTarih);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnRaporlama);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 74);
            this.panel1.TabIndex = 52;
            // 
            // imgConnectionStatus
            // 
            this.imgConnectionStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.imgConnectionStatus.Image = global::FotoCek.Client.Properties.Resources.green1;
            this.imgConnectionStatus.Location = new System.Drawing.Point(550, 26);
            this.imgConnectionStatus.Name = "imgConnectionStatus";
            this.imgConnectionStatus.Size = new System.Drawing.Size(23, 23);
            this.imgConnectionStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgConnectionStatus.TabIndex = 23;
            this.imgConnectionStatus.TabStop = false;
            this.imgConnectionStatus.Visible = false;
            // 
            // lblTarih
            // 
            this.lblTarih.AutoSize = true;
            this.lblTarih.Font = new System.Drawing.Font("NeoSans Light TR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTarih.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblTarih.Location = new System.Drawing.Point(12, 40);
            this.lblTarih.Name = "lblTarih";
            this.lblTarih.Size = new System.Drawing.Size(45, 19);
            this.lblTarih.TabIndex = 22;
            this.lblTarih.Text = "Tarih";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("NeoSans Light TR", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 19);
            this.label5.TabIndex = 21;
            this.label5.Text = "Toscelik Turnike Giriş";
            // 
            // btnRaporlama
            // 
            this.btnRaporlama.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRaporlama.Image = global::FotoCek.Client.Properties.Resources.btnGetir;
            this.btnRaporlama.Location = new System.Drawing.Point(579, 17);
            this.btnRaporlama.Name = "btnRaporlama";
            this.btnRaporlama.Size = new System.Drawing.Size(122, 42);
            this.btnRaporlama.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnRaporlama.TabIndex = 16;
            this.btnRaporlama.TabStop = false;
            this.btnRaporlama.Click += new System.EventHandler(this.btnRaporlama_Click);
            // 
            // tmrSaat
            // 
            this.tmrSaat.Enabled = true;
            this.tmrSaat.Interval = 1000;
            this.tmrSaat.Tick += new System.EventHandler(this.tmrSaat_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 660);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Toscelik Turnike Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGirenKisiResmi)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgConnectionStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRaporlama)).EndInit();
            this.ResumeLayout(false);

        }

       


        #endregion

        private System.Windows.Forms.PictureBox pbxGirenKisiResmi;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTarih;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox btnRaporlama;
        private System.Windows.Forms.Timer tmrSaat;
        private System.Windows.Forms.PictureBox imgConnectionStatus;
    }
}

