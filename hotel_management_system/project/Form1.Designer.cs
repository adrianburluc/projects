namespace Hotel.App
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
            this.listBoxTipCamere = new System.Windows.Forms.ListBox();
            this.textBoxDenumire = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTipPat = new System.Windows.Forms.ComboBox();
            this.numericNrPers = new System.Windows.Forms.NumericUpDown();
            this.numericNrPaturi = new System.Windows.Forms.NumericUpDown();
            this.numericDimensiuni = new System.Windows.Forms.NumericUpDown();
            this.btnEditCamera = new System.Windows.Forms.Button();
            this.listBoxUtilitatiCamera = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAdaugaUtilitateCamera = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbUtilitati = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdaugaCamera = new System.Windows.Forms.Button();
            this.btnDeleteUtilitate = new System.Windows.Forms.Button();
            this.btnDeleteCamera = new System.Windows.Forms.Button();
            this.btnEditUtilitate = new System.Windows.Forms.Button();
            this.listBoxUtilitati = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnStergeUtilitate = new System.Windows.Forms.Button();
            this.textBoxDenumireUtilitate = new System.Windows.Forms.TextBox();
            this.btnAdaugaUtilitate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericNrPers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNrPaturi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDimensiuni)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxTipCamere
            // 
            this.listBoxTipCamere.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTipCamere.FormattingEnabled = true;
            this.listBoxTipCamere.ItemHeight = 20;
            this.listBoxTipCamere.Location = new System.Drawing.Point(9, 23);
            this.listBoxTipCamere.Name = "listBoxTipCamere";
            this.listBoxTipCamere.Size = new System.Drawing.Size(258, 104);
            this.listBoxTipCamere.Sorted = true;
            this.listBoxTipCamere.TabIndex = 1;
            this.listBoxTipCamere.SelectedValueChanged += new System.EventHandler(this.listBoxTipCamere_SelectedValueChanged);
            // 
            // textBoxDenumire
            // 
            this.textBoxDenumire.Location = new System.Drawing.Point(10, 39);
            this.textBoxDenumire.Name = "textBoxDenumire";
            this.textBoxDenumire.Size = new System.Drawing.Size(240, 26);
            this.textBoxDenumire.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Denumire";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Limita persoane";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Numar paturi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Tip pat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Dimensiuni m²";
            // 
            // cbTipPat
            // 
            this.cbTipPat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipPat.FormattingEnabled = true;
            this.cbTipPat.Items.AddRange(new object[] {
            "Double",
            "Single"});
            this.cbTipPat.Location = new System.Drawing.Point(134, 142);
            this.cbTipPat.Name = "cbTipPat";
            this.cbTipPat.Size = new System.Drawing.Size(116, 28);
            this.cbTipPat.Sorted = true;
            this.cbTipPat.TabIndex = 12;
            // 
            // numericNrPers
            // 
            this.numericNrPers.Location = new System.Drawing.Point(10, 91);
            this.numericNrPers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNrPers.Name = "numericNrPers";
            this.numericNrPers.Size = new System.Drawing.Size(116, 26);
            this.numericNrPers.TabIndex = 13;
            this.numericNrPers.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericNrPaturi
            // 
            this.numericNrPaturi.Location = new System.Drawing.Point(134, 91);
            this.numericNrPaturi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNrPaturi.Name = "numericNrPaturi";
            this.numericNrPaturi.Size = new System.Drawing.Size(116, 26);
            this.numericNrPaturi.TabIndex = 14;
            this.numericNrPaturi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericDimensiuni
            // 
            this.numericDimensiuni.Location = new System.Drawing.Point(10, 143);
            this.numericDimensiuni.Name = "numericDimensiuni";
            this.numericDimensiuni.Size = new System.Drawing.Size(116, 26);
            this.numericDimensiuni.TabIndex = 15;
            // 
            // btnEditCamera
            // 
            this.btnEditCamera.Location = new System.Drawing.Point(10, 181);
            this.btnEditCamera.Name = "btnEditCamera";
            this.btnEditCamera.Size = new System.Drawing.Size(116, 34);
            this.btnEditCamera.TabIndex = 16;
            this.btnEditCamera.Text = "Actualizeaza";
            this.btnEditCamera.UseVisualStyleBackColor = true;
            this.btnEditCamera.Click += new System.EventHandler(this.btnEditCamera_Click);
            // 
            // listBoxUtilitatiCamera
            // 
            this.listBoxUtilitatiCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxUtilitatiCamera.FormattingEnabled = true;
            this.listBoxUtilitatiCamera.ItemHeight = 20;
            this.listBoxUtilitatiCamera.Location = new System.Drawing.Point(278, 23);
            this.listBoxUtilitatiCamera.Name = "listBoxUtilitatiCamera";
            this.listBoxUtilitatiCamera.Size = new System.Drawing.Size(155, 104);
            this.listBoxUtilitatiCamera.Sorted = true;
            this.listBoxUtilitatiCamera.TabIndex = 17;
            this.listBoxUtilitatiCamera.SelectedValueChanged += new System.EventHandler(this.listBoxUtilitatiCamera_SelectedValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.btnDeleteUtilitate);
            this.groupBox2.Controls.Add(this.btnDeleteCamera);
            this.groupBox2.Controls.Add(this.listBoxUtilitatiCamera);
            this.groupBox2.Controls.Add(this.listBoxTipCamere);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 401);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestiune tip camere";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAdaugaUtilitateCamera);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cbUtilitati);
            this.groupBox3.Location = new System.Drawing.Point(278, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(155, 117);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // btnAdaugaUtilitateCamera
            // 
            this.btnAdaugaUtilitateCamera.Location = new System.Drawing.Point(6, 73);
            this.btnAdaugaUtilitateCamera.Name = "btnAdaugaUtilitateCamera";
            this.btnAdaugaUtilitateCamera.Size = new System.Drawing.Size(143, 34);
            this.btnAdaugaUtilitateCamera.TabIndex = 24;
            this.btnAdaugaUtilitateCamera.Text = "Adauga";
            this.btnAdaugaUtilitateCamera.UseVisualStyleBackColor = true;
            this.btnAdaugaUtilitateCamera.Click += new System.EventHandler(this.btnAdaugaUtilitateCamera_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 20;
            this.label6.Text = "Utilitati disponibile";
            // 
            // cbUtilitati
            // 
            this.cbUtilitati.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUtilitati.FormattingEnabled = true;
            this.cbUtilitati.Location = new System.Drawing.Point(6, 39);
            this.cbUtilitati.Name = "cbUtilitati";
            this.cbUtilitati.Size = new System.Drawing.Size(143, 28);
            this.cbUtilitati.Sorted = true;
            this.cbUtilitati.TabIndex = 21;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxDenumire);
            this.groupBox1.Controls.Add(this.numericNrPaturi);
            this.groupBox1.Controls.Add(this.numericNrPers);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnAdaugaCamera);
            this.groupBox1.Controls.Add(this.numericDimensiuni);
            this.groupBox1.Controls.Add(this.cbTipPat);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnEditCamera);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(9, 167);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 225);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // btnAdaugaCamera
            // 
            this.btnAdaugaCamera.Location = new System.Drawing.Point(134, 181);
            this.btnAdaugaCamera.Name = "btnAdaugaCamera";
            this.btnAdaugaCamera.Size = new System.Drawing.Size(116, 34);
            this.btnAdaugaCamera.TabIndex = 18;
            this.btnAdaugaCamera.Text = "Adauga";
            this.btnAdaugaCamera.UseVisualStyleBackColor = true;
            this.btnAdaugaCamera.Click += new System.EventHandler(this.btnAdaugaCamera_Click);
            // 
            // btnDeleteUtilitate
            // 
            this.btnDeleteUtilitate.Enabled = false;
            this.btnDeleteUtilitate.Location = new System.Drawing.Point(278, 133);
            this.btnDeleteUtilitate.Name = "btnDeleteUtilitate";
            this.btnDeleteUtilitate.Size = new System.Drawing.Size(155, 32);
            this.btnDeleteUtilitate.TabIndex = 23;
            this.btnDeleteUtilitate.Text = "Sterge";
            this.btnDeleteUtilitate.UseVisualStyleBackColor = true;
            this.btnDeleteUtilitate.Click += new System.EventHandler(this.btnDeleteUtilitate_Click);
            // 
            // btnDeleteCamera
            // 
            this.btnDeleteCamera.Location = new System.Drawing.Point(9, 133);
            this.btnDeleteCamera.Name = "btnDeleteCamera";
            this.btnDeleteCamera.Size = new System.Drawing.Size(258, 32);
            this.btnDeleteCamera.TabIndex = 19;
            this.btnDeleteCamera.Text = "Sterge";
            this.btnDeleteCamera.UseVisualStyleBackColor = true;
            this.btnDeleteCamera.Click += new System.EventHandler(this.btnDeleteCamera_Click);
            // 
            // btnEditUtilitate
            // 
            this.btnEditUtilitate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditUtilitate.Location = new System.Drawing.Point(7, 278);
            this.btnEditUtilitate.Name = "btnEditUtilitate";
            this.btnEditUtilitate.Size = new System.Drawing.Size(141, 34);
            this.btnEditUtilitate.TabIndex = 23;
            this.btnEditUtilitate.Text = "Editeaza";
            this.btnEditUtilitate.UseVisualStyleBackColor = true;
            this.btnEditUtilitate.Click += new System.EventHandler(this.btnEditUtilitate_Click);
            // 
            // listBoxUtilitati
            // 
            this.listBoxUtilitati.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxUtilitati.FormattingEnabled = true;
            this.listBoxUtilitati.ItemHeight = 20;
            this.listBoxUtilitati.Location = new System.Drawing.Point(7, 23);
            this.listBoxUtilitati.Name = "listBoxUtilitati";
            this.listBoxUtilitati.Size = new System.Drawing.Size(141, 144);
            this.listBoxUtilitati.Sorted = true;
            this.listBoxUtilitati.TabIndex = 24;
            this.listBoxUtilitati.SelectedValueChanged += new System.EventHandler(this.listBoxUtilitati_SelectedValueChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.btnStergeUtilitate);
            this.groupBox4.Controls.Add(this.textBoxDenumireUtilitate);
            this.groupBox4.Controls.Add(this.btnAdaugaUtilitate);
            this.groupBox4.Controls.Add(this.listBoxUtilitati);
            this.groupBox4.Controls.Add(this.btnEditUtilitate);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(461, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(156, 401);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gestiune utilitati";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Denumire";
            // 
            // btnStergeUtilitate
            // 
            this.btnStergeUtilitate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStergeUtilitate.Location = new System.Drawing.Point(7, 318);
            this.btnStergeUtilitate.Name = "btnStergeUtilitate";
            this.btnStergeUtilitate.Size = new System.Drawing.Size(141, 34);
            this.btnStergeUtilitate.TabIndex = 27;
            this.btnStergeUtilitate.Text = "Sterge";
            this.btnStergeUtilitate.UseVisualStyleBackColor = true;
            this.btnStergeUtilitate.Click += new System.EventHandler(this.btnStergeUtilitate_Click);
            // 
            // textBoxDenumireUtilitate
            // 
            this.textBoxDenumireUtilitate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDenumireUtilitate.Location = new System.Drawing.Point(7, 206);
            this.textBoxDenumireUtilitate.Name = "textBoxDenumireUtilitate";
            this.textBoxDenumireUtilitate.Size = new System.Drawing.Size(141, 26);
            this.textBoxDenumireUtilitate.TabIndex = 26;
            // 
            // btnAdaugaUtilitate
            // 
            this.btnAdaugaUtilitate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdaugaUtilitate.Location = new System.Drawing.Point(7, 238);
            this.btnAdaugaUtilitate.Name = "btnAdaugaUtilitate";
            this.btnAdaugaUtilitate.Size = new System.Drawing.Size(142, 34);
            this.btnAdaugaUtilitate.TabIndex = 25;
            this.btnAdaugaUtilitate.Text = "Adauga";
            this.btnAdaugaUtilitate.UseVisualStyleBackColor = true;
            this.btnAdaugaUtilitate.Click += new System.EventHandler(this.btnAdaugaUtilitate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 428);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericNrPers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNrPaturi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericDimensiuni)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTipCamere;
        private System.Windows.Forms.TextBox textBoxDenumire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTipPat;
        private System.Windows.Forms.NumericUpDown numericNrPers;
        private System.Windows.Forms.NumericUpDown numericNrPaturi;
        private System.Windows.Forms.NumericUpDown numericDimensiuni;
        private System.Windows.Forms.Button btnEditCamera;
        private System.Windows.Forms.ListBox listBoxUtilitatiCamera;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteCamera;
        private System.Windows.Forms.Button btnAdaugaCamera;
        private System.Windows.Forms.ComboBox cbUtilitati;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDeleteUtilitate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEditUtilitate;
        private System.Windows.Forms.Button btnAdaugaUtilitateCamera;
        private System.Windows.Forms.ListBox listBoxUtilitati;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnStergeUtilitate;
        private System.Windows.Forms.TextBox textBoxDenumireUtilitate;
        private System.Windows.Forms.Button btnAdaugaUtilitate;
        private System.Windows.Forms.Label label7;

    }
}

