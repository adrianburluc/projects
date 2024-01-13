namespace Hotel.App
{
    partial class DeschideIstoricCazari
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTipClient = new System.Windows.Forms.ComboBox();
            this.btnCautaCazari = new System.Windows.Forms.Button();
            this.tbCI = new System.Windows.Forms.TextBox();
            this.labelCI = new System.Windows.Forms.Label();
            this.dgvCazari = new System.Windows.Forms.DataGridView();
            this.btnDetaliiCazare = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCazari)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbTipClient);
            this.groupBox1.Controls.Add(this.btnCautaCazari);
            this.groupBox1.Controls.Add(this.tbCI);
            this.groupBox1.Controls.Add(this.labelCI);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(23, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 329);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cauta istoric cazari";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tip client:";
            // 
            // cbTipClient
            // 
            this.cbTipClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipClient.FormattingEnabled = true;
            this.cbTipClient.Items.AddRange(new object[] {
            "Persoana fizica",
            "Persoana juridica"});
            this.cbTipClient.Location = new System.Drawing.Point(26, 93);
            this.cbTipClient.Name = "cbTipClient";
            this.cbTipClient.Size = new System.Drawing.Size(322, 37);
            this.cbTipClient.TabIndex = 3;
            this.cbTipClient.TextChanged += new System.EventHandler(this.cbTipClient_TextChanged);
            // 
            // btnCautaCazari
            // 
            this.btnCautaCazari.Location = new System.Drawing.Point(26, 241);
            this.btnCautaCazari.Name = "btnCautaCazari";
            this.btnCautaCazari.Size = new System.Drawing.Size(322, 62);
            this.btnCautaCazari.TabIndex = 2;
            this.btnCautaCazari.Text = "Cauta cazari dupa CNP";
            this.btnCautaCazari.UseVisualStyleBackColor = true;
            this.btnCautaCazari.Click += new System.EventHandler(this.btnCautaCazari_Click);
            // 
            // tbCI
            // 
            this.tbCI.Location = new System.Drawing.Point(26, 176);
            this.tbCI.Name = "tbCI";
            this.tbCI.Size = new System.Drawing.Size(322, 35);
            this.tbCI.TabIndex = 1;
            // 
            // labelCI
            // 
            this.labelCI.AutoSize = true;
            this.labelCI.Location = new System.Drawing.Point(21, 140);
            this.labelCI.Name = "labelCI";
            this.labelCI.Size = new System.Drawing.Size(70, 29);
            this.labelCI.TabIndex = 0;
            this.labelCI.Text = "CNP:";
            // 
            // dgvCazari
            // 
            this.dgvCazari.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dgvCazari.AllowUserToAddRows = false;
            this.dgvCazari.AllowUserToDeleteRows = false;
            this.dgvCazari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCazari.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCazari.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCazari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCazari.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCazari.Location = new System.Drawing.Point(407, 60);
            this.dgvCazari.MultiSelect = false;
            this.dgvCazari.Name = "dgvCazari";
            this.dgvCazari.ReadOnly = true;
            this.dgvCazari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCazari.Size = new System.Drawing.Size(1232, 418);
            this.dgvCazari.TabIndex = 6;
            // 
            // btnDetaliiCazare
            // 
            this.btnDetaliiCazare.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetaliiCazare.Location = new System.Drawing.Point(1280, 494);
            this.btnDetaliiCazare.Name = "btnDetaliiCazare";
            this.btnDetaliiCazare.Size = new System.Drawing.Size(359, 55);
            this.btnDetaliiCazare.TabIndex = 7;
            this.btnDetaliiCazare.Text = "Vizualizeaza detalii cazare";
            this.btnDetaliiCazare.UseVisualStyleBackColor = true;
            this.btnDetaliiCazare.Click += new System.EventHandler(this.btnDetaliiCazare_Click);
            // 
            // DeschideIstoricCazari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1661, 570);
            this.Controls.Add(this.btnDetaliiCazare);
            this.Controls.Add(this.dgvCazari);
            this.Controls.Add(this.groupBox1);
            this.Name = "DeschideIstoricCazari";
            this.Text = "DeschideIstoricCazari";
            this.Load += new System.EventHandler(this.DeschideIstoricCazari_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCazari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCautaCazari;
        private System.Windows.Forms.TextBox tbCI;
        private System.Windows.Forms.Label labelCI;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTipClient;
        private System.Windows.Forms.DataGridView dgvCazari;
        private System.Windows.Forms.Button btnDetaliiCazare;
    }
}