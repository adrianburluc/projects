namespace Hotel.App
{
    partial class GestiuneCamere
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvCamere = new System.Windows.Forms.DataGridView();
            this.Numar = new System.Windows.Forms.Label();
            this.buttonUpdateCamera = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericNrCamere = new System.Windows.Forms.NumericUpDown();
            this.numericEtaj = new System.Windows.Forms.NumericUpDown();
            this.cbCategorieCamere = new System.Windows.Forms.ComboBox();
            this.buttonAdaugaCamera = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxNumarCamera = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxActiv = new System.Windows.Forms.CheckBox();
            this.textBoxNrCameraCautata = new System.Windows.Forms.TextBox();
            this.buttonCautareCamera = new System.Windows.Forms.Button();
            this.buttonResetareRezutlate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNrCamere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEtaj)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxNumarCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCamere
            // 
            this.dgvCamere.AllowUserToAddRows = false;
            this.dgvCamere.AllowUserToDeleteRows = false;
            this.dgvCamere.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCamere.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCamere.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCamere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCamere.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCamere.Location = new System.Drawing.Point(12, 70);
            this.dgvCamere.MultiSelect = false;
            this.dgvCamere.Name = "dgvCamere";
            this.dgvCamere.ReadOnly = true;
            this.dgvCamere.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCamere.Size = new System.Drawing.Size(1229, 539);
            this.dgvCamere.TabIndex = 0;
            this.dgvCamere.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCamere_CellClick);
            // 
            // Numar
            // 
            this.Numar.AutoSize = true;
            this.Numar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Numar.Location = new System.Drawing.Point(6, 28);
            this.Numar.Name = "Numar";
            this.Numar.Size = new System.Drawing.Size(200, 31);
            this.Numar.TabIndex = 1;
            this.Numar.Text = "Numar camera:";
            // 
            // buttonUpdateCamera
            // 
            this.buttonUpdateCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateCamera.Location = new System.Drawing.Point(218, 465);
            this.buttonUpdateCamera.Name = "buttonUpdateCamera";
            this.buttonUpdateCamera.Size = new System.Drawing.Size(192, 80);
            this.buttonUpdateCamera.TabIndex = 2;
            this.buttonUpdateCamera.Text = "Actualizeaza camera";
            this.buttonUpdateCamera.UseVisualStyleBackColor = true;
            this.buttonUpdateCamera.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Numar camere:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 31);
            this.label4.TabIndex = 6;
            this.label4.Text = "Etaj:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 31);
            this.label5.TabIndex = 7;
            this.label5.Text = "Categorie:";
            // 
            // numericNrCamere
            // 
            this.numericNrCamere.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericNrCamere.Location = new System.Drawing.Point(11, 360);
            this.numericNrCamere.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNrCamere.Name = "numericNrCamere";
            this.numericNrCamere.Size = new System.Drawing.Size(396, 35);
            this.numericNrCamere.TabIndex = 8;
            this.numericNrCamere.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericEtaj
            // 
            this.numericEtaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericEtaj.Location = new System.Drawing.Point(11, 277);
            this.numericEtaj.Name = "numericEtaj";
            this.numericEtaj.Size = new System.Drawing.Size(396, 35);
            this.numericEtaj.TabIndex = 10;
            // 
            // cbCategorieCamere
            // 
            this.cbCategorieCamere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategorieCamere.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategorieCamere.FormattingEnabled = true;
            this.cbCategorieCamere.Location = new System.Drawing.Point(11, 139);
            this.cbCategorieCamere.Name = "cbCategorieCamere";
            this.cbCategorieCamere.Size = new System.Drawing.Size(396, 37);
            this.cbCategorieCamere.TabIndex = 11;
            // 
            // buttonAdaugaCamera
            // 
            this.buttonAdaugaCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdaugaCamera.Location = new System.Drawing.Point(14, 465);
            this.buttonAdaugaCamera.Name = "buttonAdaugaCamera";
            this.buttonAdaugaCamera.Size = new System.Drawing.Size(192, 80);
            this.buttonAdaugaCamera.TabIndex = 12;
            this.buttonAdaugaCamera.Text = "Adauga camera";
            this.buttonAdaugaCamera.UseVisualStyleBackColor = true;
            this.buttonAdaugaCamera.Click += new System.EventHandler(this.buttonAdauga_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.textBoxNumarCamera);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.checkBoxActiv);
            this.groupBox1.Controls.Add(this.Numar);
            this.groupBox1.Controls.Add(this.buttonAdaugaCamera);
            this.groupBox1.Controls.Add(this.buttonUpdateCamera);
            this.groupBox1.Controls.Add(this.cbCategorieCamere);
            this.groupBox1.Controls.Add(this.numericEtaj);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericNrCamere);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1258, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 564);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalii camera";
            // 
            // textBoxNumarCamera
            // 
            this.textBoxNumarCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNumarCamera.Location = new System.Drawing.Point(12, 62);
            this.textBoxNumarCamera.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.textBoxNumarCamera.Name = "textBoxNumarCamera";
            this.textBoxNumarCamera.Size = new System.Drawing.Size(396, 35);
            this.textBoxNumarCamera.TabIndex = 17;
            this.textBoxNumarCamera.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(197, 31);
            this.label7.TabIndex = 16;
            this.label7.Text = "Status camera:";
            // 
            // checkBoxActiv
            // 
            this.checkBoxActiv.AutoSize = true;
            this.checkBoxActiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxActiv.Location = new System.Drawing.Point(209, 193);
            this.checkBoxActiv.Name = "checkBoxActiv";
            this.checkBoxActiv.Size = new System.Drawing.Size(111, 35);
            this.checkBoxActiv.TabIndex = 15;
            this.checkBoxActiv.Text = "inactiv";
            this.checkBoxActiv.UseVisualStyleBackColor = true;
            // 
            // textBoxNrCameraCautata
            // 
            this.textBoxNrCameraCautata.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNrCameraCautata.Location = new System.Drawing.Point(191, 19);
            this.textBoxNrCameraCautata.Name = "textBoxNrCameraCautata";
            this.textBoxNrCameraCautata.Size = new System.Drawing.Size(186, 32);
            this.textBoxNrCameraCautata.TabIndex = 14;
            // 
            // buttonCautareCamera
            // 
            this.buttonCautareCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCautareCamera.Location = new System.Drawing.Point(393, 11);
            this.buttonCautareCamera.Name = "buttonCautareCamera";
            this.buttonCautareCamera.Size = new System.Drawing.Size(105, 44);
            this.buttonCautareCamera.TabIndex = 15;
            this.buttonCautareCamera.Text = "Cauta";
            this.buttonCautareCamera.UseVisualStyleBackColor = true;
            this.buttonCautareCamera.Click += new System.EventHandler(this.buttonCautareCamera_Click);
            // 
            // buttonResetareRezutlate
            // 
            this.buttonResetareRezutlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetareRezutlate.Location = new System.Drawing.Point(504, 11);
            this.buttonResetareRezutlate.Name = "buttonResetareRezutlate";
            this.buttonResetareRezutlate.Size = new System.Drawing.Size(289, 44);
            this.buttonResetareRezutlate.TabIndex = 16;
            this.buttonResetareRezutlate.Text = "Reseteaza rezultate";
            this.buttonResetareRezutlate.UseVisualStyleBackColor = true;
            this.buttonResetareRezutlate.Click += new System.EventHandler(this.buttonResetareRezutlate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 29);
            this.label1.TabIndex = 17;
            this.label1.Text = "Numar camera:";
            // 
            // GestiuneCamere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1709, 622);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonResetareRezutlate);
            this.Controls.Add(this.buttonCautareCamera);
            this.Controls.Add(this.textBoxNrCameraCautata);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCamere);
            this.Name = "GestiuneCamere";
            this.Text = "Gestiune camere";
            this.Load += new System.EventHandler(this.GestiuneCamere_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNrCamere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericEtaj)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxNumarCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCamere;
        private System.Windows.Forms.Label Numar;
        private System.Windows.Forms.Button buttonUpdateCamera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericNrCamere;
        private System.Windows.Forms.NumericUpDown numericEtaj;
        private System.Windows.Forms.ComboBox cbCategorieCamere;
        private System.Windows.Forms.Button buttonAdaugaCamera;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxActiv;
        private System.Windows.Forms.TextBox textBoxNrCameraCautata;
        private System.Windows.Forms.Button buttonCautareCamera;
        private System.Windows.Forms.Button buttonResetareRezutlate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown textBoxNumarCamera;
    }
}