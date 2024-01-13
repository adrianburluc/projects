namespace Hotel.App
{
    partial class DeschideCazare
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
            this.tabTipCazare = new System.Windows.Forms.TabControl();
            this.tabFaraRezervare = new System.Windows.Forms.TabPage();
            this.cbCategoriiCamere = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nrOaspeti = new System.Windows.Forms.NumericUpDown();
            this.nrNopti = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabCuRezervare = new System.Windows.Forms.TabPage();
            this.tbCodIdentitate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbTipClient = new System.Windows.Forms.ComboBox();
            this.labelCNP = new System.Windows.Forms.Label();
            this.btnContinua = new System.Windows.Forms.Button();
            this.tabTipCazare.SuspendLayout();
            this.tabFaraRezervare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrOaspeti)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrNopti)).BeginInit();
            this.tabCuRezervare.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabTipCazare
            // 
            this.tabTipCazare.Controls.Add(this.tabFaraRezervare);
            this.tabTipCazare.Controls.Add(this.tabCuRezervare);
            this.tabTipCazare.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabTipCazare.Location = new System.Drawing.Point(21, 28);
            this.tabTipCazare.Name = "tabTipCazare";
            this.tabTipCazare.SelectedIndex = 0;
            this.tabTipCazare.Size = new System.Drawing.Size(531, 289);
            this.tabTipCazare.TabIndex = 0;
            // 
            // tabFaraRezervare
            // 
            this.tabFaraRezervare.Controls.Add(this.cbCategoriiCamere);
            this.tabFaraRezervare.Controls.Add(this.label3);
            this.tabFaraRezervare.Controls.Add(this.nrOaspeti);
            this.tabFaraRezervare.Controls.Add(this.nrNopti);
            this.tabFaraRezervare.Controls.Add(this.label2);
            this.tabFaraRezervare.Controls.Add(this.label1);
            this.tabFaraRezervare.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabFaraRezervare.Location = new System.Drawing.Point(4, 38);
            this.tabFaraRezervare.Name = "tabFaraRezervare";
            this.tabFaraRezervare.Padding = new System.Windows.Forms.Padding(3);
            this.tabFaraRezervare.Size = new System.Drawing.Size(523, 247);
            this.tabFaraRezervare.TabIndex = 0;
            this.tabFaraRezervare.Text = "Cazare fara rezervare";
            this.tabFaraRezervare.UseVisualStyleBackColor = true;
            // 
            // cbCategoriiCamere
            // 
            this.cbCategoriiCamere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategoriiCamere.FormattingEnabled = true;
            this.cbCategoriiCamere.Location = new System.Drawing.Point(247, 44);
            this.cbCategoriiCamere.Name = "cbCategoriiCamere";
            this.cbCategoriiCamere.Size = new System.Drawing.Size(218, 37);
            this.cbCategoriiCamere.TabIndex = 7;
            this.cbCategoriiCamere.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(119, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "Camera:";
            this.label3.Visible = false;
            // 
            // nrOaspeti
            // 
            this.nrOaspeti.Location = new System.Drawing.Point(247, 171);
            this.nrOaspeti.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nrOaspeti.Name = "nrOaspeti";
            this.nrOaspeti.Size = new System.Drawing.Size(218, 35);
            this.nrOaspeti.TabIndex = 5;
            this.nrOaspeti.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nrNopti
            // 
            this.nrNopti.Location = new System.Drawing.Point(247, 103);
            this.nrNopti.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nrNopti.Name = "nrNopti";
            this.nrNopti.Size = new System.Drawing.Size(218, 35);
            this.nrNopti.TabIndex = 4;
            this.nrNopti.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(39, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Numar oaspeti:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numar nopti:";
            // 
            // tabCuRezervare
            // 
            this.tabCuRezervare.Controls.Add(this.tbCodIdentitate);
            this.tabCuRezervare.Controls.Add(this.label4);
            this.tabCuRezervare.Controls.Add(this.cbTipClient);
            this.tabCuRezervare.Controls.Add(this.labelCNP);
            this.tabCuRezervare.Location = new System.Drawing.Point(4, 38);
            this.tabCuRezervare.Name = "tabCuRezervare";
            this.tabCuRezervare.Padding = new System.Windows.Forms.Padding(3);
            this.tabCuRezervare.Size = new System.Drawing.Size(523, 247);
            this.tabCuRezervare.TabIndex = 1;
            this.tabCuRezervare.Text = "Cazare cu rezervare";
            this.tabCuRezervare.UseVisualStyleBackColor = true;
            // 
            // tbCodIdentitate
            // 
            this.tbCodIdentitate.Location = new System.Drawing.Point(221, 119);
            this.tbCodIdentitate.Name = "tbCodIdentitate";
            this.tbCodIdentitate.Size = new System.Drawing.Size(218, 35);
            this.tbCodIdentitate.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 31);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tip client:";
            // 
            // cbTipClient
            // 
            this.cbTipClient.AutoCompleteCustomSource.AddRange(new string[] {
            "Persoana fizica",
            "Persoana juridica"});
            this.cbTipClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipClient.FormattingEnabled = true;
            this.cbTipClient.Location = new System.Drawing.Point(221, 48);
            this.cbTipClient.Name = "cbTipClient";
            this.cbTipClient.Size = new System.Drawing.Size(218, 39);
            this.cbTipClient.TabIndex = 4;
            this.cbTipClient.SelectedIndexChanged += new System.EventHandler(this.cbTipClient_SelectedIndexChanged);
            // 
            // labelCNP
            // 
            this.labelCNP.AutoSize = true;
            this.labelCNP.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCNP.Location = new System.Drawing.Point(131, 119);
            this.labelCNP.Name = "labelCNP";
            this.labelCNP.Size = new System.Drawing.Size(80, 31);
            this.labelCNP.TabIndex = 3;
            this.labelCNP.Text = "CNP:";
            // 
            // btnContinua
            // 
            this.btnContinua.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinua.Location = new System.Drawing.Point(169, 355);
            this.btnContinua.Name = "btnContinua";
            this.btnContinua.Size = new System.Drawing.Size(231, 75);
            this.btnContinua.TabIndex = 4;
            this.btnContinua.Text = "Continua";
            this.btnContinua.UseVisualStyleBackColor = true;
            this.btnContinua.Click += new System.EventHandler(this.btnContinua_Click);
            // 
            // DeschideCazare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 461);
            this.Controls.Add(this.btnContinua);
            this.Controls.Add(this.tabTipCazare);
            this.Name = "DeschideCazare";
            this.Text = "DeschideCazare";
            this.Load += new System.EventHandler(this.DeschideCazare_Load);
            this.tabTipCazare.ResumeLayout(false);
            this.tabFaraRezervare.ResumeLayout(false);
            this.tabFaraRezervare.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrOaspeti)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrNopti)).EndInit();
            this.tabCuRezervare.ResumeLayout(false);
            this.tabCuRezervare.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabTipCazare;
        private System.Windows.Forms.TabPage tabFaraRezervare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabCuRezervare;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbTipClient;
        private System.Windows.Forms.Label labelCNP;
        private System.Windows.Forms.Button btnContinua;
        private System.Windows.Forms.NumericUpDown nrOaspeti;
        private System.Windows.Forms.NumericUpDown nrNopti;
        private System.Windows.Forms.TextBox tbCodIdentitate;
        private System.Windows.Forms.ComboBox cbCategoriiCamere;
        private System.Windows.Forms.Label label3;
    }
}