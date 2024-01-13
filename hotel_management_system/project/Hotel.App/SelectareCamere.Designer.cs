namespace Hotel.App
{
    partial class SelectareCamere
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
            this.textBoxDescriere = new System.Windows.Forms.TextBox();
            this.labelCamereDisponibile = new System.Windows.Forms.Label();
            this.buttonAnuleaza = new System.Windows.Forms.Button();
            this.dgvCamereLibere = new System.Windows.Forms.DataGridView();
            this.buttonAdaugaCamere = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamereLibere)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDescriere
            // 
            this.textBoxDescriere.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescriere.Location = new System.Drawing.Point(32, 305);
            this.textBoxDescriere.Multiline = true;
            this.textBoxDescriere.Name = "textBoxDescriere";
            this.textBoxDescriere.ReadOnly = true;
            this.textBoxDescriere.Size = new System.Drawing.Size(807, 87);
            this.textBoxDescriere.TabIndex = 14;
            this.textBoxDescriere.Text = "Descriere camera selectata.";
            // 
            // labelCamereDisponibile
            // 
            this.labelCamereDisponibile.AutoSize = true;
            this.labelCamereDisponibile.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCamereDisponibile.Location = new System.Drawing.Point(27, 24);
            this.labelCamereDisponibile.Name = "labelCamereDisponibile";
            this.labelCamereDisponibile.Size = new System.Drawing.Size(205, 26);
            this.labelCamereDisponibile.TabIndex = 13;
            this.labelCamereDisponibile.Text = "Camere disponibile:";
            // 
            // buttonAnuleaza
            // 
            this.buttonAnuleaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnuleaza.Location = new System.Drawing.Point(712, 408);
            this.buttonAnuleaza.Name = "buttonAnuleaza";
            this.buttonAnuleaza.Size = new System.Drawing.Size(127, 46);
            this.buttonAnuleaza.TabIndex = 12;
            this.buttonAnuleaza.Text = "Anuleaza";
            this.buttonAnuleaza.UseVisualStyleBackColor = true;
            this.buttonAnuleaza.Click += new System.EventHandler(this.buttonAnuleaza_Click);
            // 
            // dgvCamereLibere
            // 
            this.dgvCamereLibere.AllowUserToAddRows = false;
            this.dgvCamereLibere.AllowUserToDeleteRows = false;
            this.dgvCamereLibere.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCamereLibere.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCamereLibere.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCamereLibere.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCamereLibere.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCamereLibere.Location = new System.Drawing.Point(32, 62);
            this.dgvCamereLibere.MultiSelect = false;
            this.dgvCamereLibere.Name = "dgvCamereLibere";
            this.dgvCamereLibere.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCamereLibere.Size = new System.Drawing.Size(807, 237);
            this.dgvCamereLibere.TabIndex = 11;
            this.dgvCamereLibere.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCamereLibere_CellClick);
            // 
            // buttonAdaugaCamere
            // 
            this.buttonAdaugaCamere.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdaugaCamere.Location = new System.Drawing.Point(442, 408);
            this.buttonAdaugaCamere.Name = "buttonAdaugaCamere";
            this.buttonAdaugaCamere.Size = new System.Drawing.Size(264, 46);
            this.buttonAdaugaCamere.TabIndex = 15;
            this.buttonAdaugaCamere.Text = "Adauga camere selectate";
            this.buttonAdaugaCamere.UseVisualStyleBackColor = true;
            this.buttonAdaugaCamere.Click += new System.EventHandler(this.buttonAdaugaCamere_Click);
            // 
            // SelectareCamere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 471);
            this.Controls.Add(this.buttonAdaugaCamere);
            this.Controls.Add(this.textBoxDescriere);
            this.Controls.Add(this.labelCamereDisponibile);
            this.Controls.Add(this.buttonAnuleaza);
            this.Controls.Add(this.dgvCamereLibere);
            this.Name = "SelectareCamere";
            this.Text = "SelectareCamere";
            this.Load += new System.EventHandler(this.SelectareCamere_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamereLibere)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDescriere;
        private System.Windows.Forms.Label labelCamereDisponibile;
        private System.Windows.Forms.Button buttonAnuleaza;
        private System.Windows.Forms.DataGridView dgvCamereLibere;
        private System.Windows.Forms.Button buttonAdaugaCamere;

    }
}