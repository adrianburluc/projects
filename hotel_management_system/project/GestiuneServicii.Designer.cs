namespace Hotel.App
{
    partial class GestiuneServicii
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestiuneServicii));
            this.dgvServicii = new System.Windows.Forms.DataGridView();
            this.pictureBoxImagine = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSeteazaImagine = new System.Windows.Forms.Button();
            this.tabControlDescriere = new System.Windows.Forms.TabControl();
            this.tabDescriere = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTipServiciu = new System.Windows.Forms.ComboBox();
            this.textBoxDenumire = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxActiv = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdaugaServiciu = new System.Windows.Forms.Button();
            this.btnUpdateServiciu = new System.Windows.Forms.Button();
            this.textBoxDescriere = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabImagine = new System.Windows.Forms.TabPage();
            this.buttonResetareImagine = new System.Windows.Forms.Button();
            this.buttonUpdateImagine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicii)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagine)).BeginInit();
            this.tabControlDescriere.SuspendLayout();
            this.tabDescriere.SuspendLayout();
            this.tabImagine.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvServicii
            // 
            this.dgvServicii.AllowUserToAddRows = false;
            this.dgvServicii.AllowUserToDeleteRows = false;
            this.dgvServicii.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvServicii.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvServicii.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvServicii.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvServicii.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvServicii.Location = new System.Drawing.Point(12, 45);
            this.dgvServicii.MultiSelect = false;
            this.dgvServicii.Name = "dgvServicii";
            this.dgvServicii.ReadOnly = true;
            this.dgvServicii.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvServicii.Size = new System.Drawing.Size(1070, 584);
            this.dgvServicii.TabIndex = 0;
            this.dgvServicii.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServicii_CellClick);
            this.dgvServicii.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvServicii_ColumnHeaderMouseClick);
            // 
            // pictureBoxImagine
            // 
            this.pictureBoxImagine.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxImagine.Image")));
            this.pictureBoxImagine.Location = new System.Drawing.Point(13, 64);
            this.pictureBoxImagine.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBoxImagine.Name = "pictureBoxImagine";
            this.pictureBoxImagine.Size = new System.Drawing.Size(413, 260);
            this.pictureBoxImagine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxImagine.TabIndex = 4;
            this.pictureBoxImagine.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "Imagine reprezentativa";
            // 
            // buttonSeteazaImagine
            // 
            this.buttonSeteazaImagine.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSeteazaImagine.Location = new System.Drawing.Point(13, 340);
            this.buttonSeteazaImagine.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSeteazaImagine.Name = "buttonSeteazaImagine";
            this.buttonSeteazaImagine.Size = new System.Drawing.Size(413, 62);
            this.buttonSeteazaImagine.TabIndex = 8;
            this.buttonSeteazaImagine.Text = "Schimba imaginea";
            this.buttonSeteazaImagine.UseVisualStyleBackColor = true;
            this.buttonSeteazaImagine.Click += new System.EventHandler(this.buttonSeteazaImagine_Click);
            // 
            // tabControlDescriere
            // 
            this.tabControlDescriere.Controls.Add(this.tabDescriere);
            this.tabControlDescriere.Controls.Add(this.tabImagine);
            this.tabControlDescriere.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlDescriere.Location = new System.Drawing.Point(1087, 12);
            this.tabControlDescriere.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlDescriere.Name = "tabControlDescriere";
            this.tabControlDescriere.SelectedIndex = 0;
            this.tabControlDescriere.Size = new System.Drawing.Size(450, 621);
            this.tabControlDescriere.TabIndex = 14;
            // 
            // tabDescriere
            // 
            this.tabDescriere.Controls.Add(this.label1);
            this.tabDescriere.Controls.Add(this.cbTipServiciu);
            this.tabDescriere.Controls.Add(this.textBoxDenumire);
            this.tabDescriere.Controls.Add(this.label8);
            this.tabDescriere.Controls.Add(this.checkBoxActiv);
            this.tabDescriere.Controls.Add(this.label3);
            this.tabDescriere.Controls.Add(this.btnAdaugaServiciu);
            this.tabDescriere.Controls.Add(this.btnUpdateServiciu);
            this.tabDescriere.Controls.Add(this.textBoxDescriere);
            this.tabDescriere.Controls.Add(this.label5);
            this.tabDescriere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDescriere.Location = new System.Drawing.Point(4, 38);
            this.tabDescriere.Margin = new System.Windows.Forms.Padding(2);
            this.tabDescriere.Name = "tabDescriere";
            this.tabDescriere.Padding = new System.Windows.Forms.Padding(2);
            this.tabDescriere.Size = new System.Drawing.Size(442, 579);
            this.tabDescriere.TabIndex = 0;
            this.tabDescriere.Text = "Descriere";
            this.tabDescriere.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 125);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 31);
            this.label1.TabIndex = 19;
            this.label1.Text = "Tip:";
            // 
            // cbTipServiciu
            // 
            this.cbTipServiciu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipServiciu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipServiciu.FormattingEnabled = true;
            this.cbTipServiciu.Items.AddRange(new object[] {
            "zilnic",
            "ocazional"});
            this.cbTipServiciu.Location = new System.Drawing.Point(13, 162);
            this.cbTipServiciu.Name = "cbTipServiciu";
            this.cbTipServiciu.Size = new System.Drawing.Size(404, 37);
            this.cbTipServiciu.TabIndex = 18;
            // 
            // textBoxDenumire
            // 
            this.textBoxDenumire.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDenumire.Location = new System.Drawing.Point(13, 39);
            this.textBoxDenumire.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDenumire.Name = "textBoxDenumire";
            this.textBoxDenumire.Size = new System.Drawing.Size(404, 35);
            this.textBoxDenumire.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 87);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(200, 31);
            this.label8.TabIndex = 16;
            this.label8.Text = "Status serviciu:";
            // 
            // checkBoxActiv
            // 
            this.checkBoxActiv.AutoSize = true;
            this.checkBoxActiv.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxActiv.Location = new System.Drawing.Point(212, 86);
            this.checkBoxActiv.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxActiv.Name = "checkBoxActiv";
            this.checkBoxActiv.Size = new System.Drawing.Size(111, 35);
            this.checkBoxActiv.TabIndex = 15;
            this.checkBoxActiv.Text = "inactiv";
            this.checkBoxActiv.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Denumire:";
            // 
            // btnAdaugaServiciu
            // 
            this.btnAdaugaServiciu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdaugaServiciu.Location = new System.Drawing.Point(13, 409);
            this.btnAdaugaServiciu.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdaugaServiciu.Name = "btnAdaugaServiciu";
            this.btnAdaugaServiciu.Size = new System.Drawing.Size(195, 88);
            this.btnAdaugaServiciu.TabIndex = 8;
            this.btnAdaugaServiciu.Text = "Adauga serviciu";
            this.btnAdaugaServiciu.UseVisualStyleBackColor = true;
            this.btnAdaugaServiciu.Click += new System.EventHandler(this.btnAdaugaServiciu_Click);
            // 
            // btnUpdateServiciu
            // 
            this.btnUpdateServiciu.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateServiciu.Location = new System.Drawing.Point(222, 409);
            this.btnUpdateServiciu.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateServiciu.Name = "btnUpdateServiciu";
            this.btnUpdateServiciu.Size = new System.Drawing.Size(195, 88);
            this.btnUpdateServiciu.TabIndex = 7;
            this.btnUpdateServiciu.Text = "Actualizeaza";
            this.btnUpdateServiciu.UseVisualStyleBackColor = true;
            this.btnUpdateServiciu.Click += new System.EventHandler(this.btnUpdateServiciu_Click);
            // 
            // textBoxDescriere
            // 
            this.textBoxDescriere.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescriere.Location = new System.Drawing.Point(13, 255);
            this.textBoxDescriere.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDescriere.Multiline = true;
            this.textBoxDescriere.Name = "textBoxDescriere";
            this.textBoxDescriere.Size = new System.Drawing.Size(404, 129);
            this.textBoxDescriere.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 218);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 31);
            this.label5.TabIndex = 2;
            this.label5.Text = "Descriere:";
            // 
            // tabImagine
            // 
            this.tabImagine.Controls.Add(this.buttonResetareImagine);
            this.tabImagine.Controls.Add(this.buttonSeteazaImagine);
            this.tabImagine.Controls.Add(this.buttonUpdateImagine);
            this.tabImagine.Controls.Add(this.label2);
            this.tabImagine.Controls.Add(this.pictureBoxImagine);
            this.tabImagine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabImagine.Location = new System.Drawing.Point(4, 38);
            this.tabImagine.Margin = new System.Windows.Forms.Padding(2);
            this.tabImagine.Name = "tabImagine";
            this.tabImagine.Size = new System.Drawing.Size(442, 579);
            this.tabImagine.TabIndex = 2;
            this.tabImagine.Text = "Imagine";
            this.tabImagine.UseVisualStyleBackColor = true;
            // 
            // buttonResetareImagine
            // 
            this.buttonResetareImagine.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetareImagine.Location = new System.Drawing.Point(13, 406);
            this.buttonResetareImagine.Margin = new System.Windows.Forms.Padding(2);
            this.buttonResetareImagine.Name = "buttonResetareImagine";
            this.buttonResetareImagine.Size = new System.Drawing.Size(413, 56);
            this.buttonResetareImagine.TabIndex = 11;
            this.buttonResetareImagine.Text = "Reseteaza";
            this.buttonResetareImagine.UseVisualStyleBackColor = true;
            this.buttonResetareImagine.Click += new System.EventHandler(this.buttonResetareImagine_Click);
            // 
            // buttonUpdateImagine
            // 
            this.buttonUpdateImagine.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUpdateImagine.Location = new System.Drawing.Point(13, 485);
            this.buttonUpdateImagine.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUpdateImagine.Name = "buttonUpdateImagine";
            this.buttonUpdateImagine.Size = new System.Drawing.Size(413, 70);
            this.buttonUpdateImagine.TabIndex = 10;
            this.buttonUpdateImagine.Text = "Salveaza";
            this.buttonUpdateImagine.UseVisualStyleBackColor = true;
            this.buttonUpdateImagine.Click += new System.EventHandler(this.buttonUpdateImagine_Click);
            // 
            // GestiuneServicii
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1562, 644);
            this.Controls.Add(this.tabControlDescriere);
            this.Controls.Add(this.dgvServicii);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "GestiuneServicii";
            this.Text = "GestiuneServicii";
            this.Load += new System.EventHandler(this.GestiuneServicii_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServicii)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImagine)).EndInit();
            this.tabControlDescriere.ResumeLayout(false);
            this.tabDescriere.ResumeLayout(false);
            this.tabDescriere.PerformLayout();
            this.tabImagine.ResumeLayout(false);
            this.tabImagine.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvServicii;
        private System.Windows.Forms.PictureBox pictureBoxImagine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSeteazaImagine;
        private System.Windows.Forms.TabControl tabControlDescriere;
        private System.Windows.Forms.TabPage tabDescriere;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdaugaServiciu;
        private System.Windows.Forms.Button btnUpdateServiciu;
        private System.Windows.Forms.TextBox textBoxDescriere;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabImagine;
        private System.Windows.Forms.Button buttonUpdateImagine;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxActiv;
        private System.Windows.Forms.TextBox textBoxDenumire;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTipServiciu;
        private System.Windows.Forms.Button buttonResetareImagine;
    }
}