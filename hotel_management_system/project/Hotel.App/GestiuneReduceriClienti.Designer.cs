namespace Hotel.App
{
    partial class GestiuneReduceriClienti
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
            this.label8 = new System.Windows.Forms.Label();
            this.listBoxCategoriiClienti = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelValabilPanaPe = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNrZile = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataDiscountSfarsit = new System.Windows.Forms.DateTimePicker();
            this.dataDiscountInceput = new System.Windows.Forms.DateTimePicker();
            this.buttonSeteazaReducere = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numericDiscount = new System.Windows.Forms.NumericUpDown();
            this.labelReducere = new System.Windows.Forms.Label();
            this.labelCategorieClient = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonAnuleazaDiscount = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateFiltruDataSfarsit = new System.Windows.Forms.DateTimePicker();
            this.dateFiltruDataInceput = new System.Windows.Forms.DateTimePicker();
            this.buttonResetFiltru = new System.Windows.Forms.Button();
            this.buttonAplicaFiltru = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvReduceriProgramate = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.cbTipClient = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiscount)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReduceriProgramate)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(244, 29);
            this.label8.TabIndex = 22;
            this.label8.Text = "Selecteaza categoria:";
            // 
            // listBoxCategoriiClienti
            // 
            this.listBoxCategoriiClienti.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.listBoxCategoriiClienti.FormattingEnabled = true;
            this.listBoxCategoriiClienti.ItemHeight = 29;
            this.listBoxCategoriiClienti.Location = new System.Drawing.Point(11, 145);
            this.listBoxCategoriiClienti.Name = "listBoxCategoriiClienti";
            this.listBoxCategoriiClienti.Size = new System.Drawing.Size(329, 410);
            this.listBoxCategoriiClienti.TabIndex = 20;
            this.listBoxCategoriiClienti.SelectedIndexChanged += new System.EventHandler(this.listBoxCategoriiClienti_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(370, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1126, 511);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelValabilPanaPe);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.labelReducere);
            this.tabPage1.Controls.Add(this.labelCategorieClient);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1118, 469);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reducere actuala";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelValabilPanaPe
            // 
            this.labelValabilPanaPe.AutoSize = true;
            this.labelValabilPanaPe.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValabilPanaPe.Location = new System.Drawing.Point(62, 246);
            this.labelValabilPanaPe.Name = "labelValabilPanaPe";
            this.labelValabilPanaPe.Size = new System.Drawing.Size(207, 31);
            this.labelValabilPanaPe.TabIndex = 19;
            this.labelValabilPanaPe.Text = "Valabil pana pe:";
            this.labelValabilPanaPe.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(62, 205);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 31);
            this.label7.TabIndex = 17;
            this.label7.Text = "Reducere:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNrZile);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dataDiscountSfarsit);
            this.groupBox1.Controls.Add(this.dataDiscountInceput);
            this.groupBox1.Controls.Add(this.buttonSeteazaReducere);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericDiscount);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(482, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 399);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seteaza reducere";
            // 
            // labelNrZile
            // 
            this.labelNrZile.AutoSize = true;
            this.labelNrZile.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNrZile.Location = new System.Drawing.Point(257, 232);
            this.labelNrZile.Name = "labelNrZile";
            this.labelNrZile.Size = new System.Drawing.Size(77, 31);
            this.labelNrZile.TabIndex = 31;
            this.labelNrZile.Text = "1 zile";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(27, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 31);
            this.label6.TabIndex = 30;
            this.label6.Text = "Durata:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 31);
            this.label2.TabIndex = 29;
            this.label2.Text = "Data sfarsit:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 31);
            this.label1.TabIndex = 28;
            this.label1.Text = "Data inceput:";
            // 
            // dataDiscountSfarsit
            // 
            this.dataDiscountSfarsit.Checked = false;
            this.dataDiscountSfarsit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataDiscountSfarsit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataDiscountSfarsit.Location = new System.Drawing.Point(263, 170);
            this.dataDiscountSfarsit.Name = "dataDiscountSfarsit";
            this.dataDiscountSfarsit.Size = new System.Drawing.Size(194, 38);
            this.dataDiscountSfarsit.TabIndex = 27;
            this.dataDiscountSfarsit.ValueChanged += new System.EventHandler(this.dataDiscountSfarsit_ValueChanged);
            // 
            // dataDiscountInceput
            // 
            this.dataDiscountInceput.Checked = false;
            this.dataDiscountInceput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataDiscountInceput.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataDiscountInceput.Location = new System.Drawing.Point(263, 108);
            this.dataDiscountInceput.Name = "dataDiscountInceput";
            this.dataDiscountInceput.Size = new System.Drawing.Size(194, 38);
            this.dataDiscountInceput.TabIndex = 26;
            this.dataDiscountInceput.ValueChanged += new System.EventHandler(this.dataDiscountInceput_ValueChanged);
            // 
            // buttonSeteazaReducere
            // 
            this.buttonSeteazaReducere.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSeteazaReducere.Location = new System.Drawing.Point(109, 302);
            this.buttonSeteazaReducere.Name = "buttonSeteazaReducere";
            this.buttonSeteazaReducere.Size = new System.Drawing.Size(269, 76);
            this.buttonSeteazaReducere.TabIndex = 15;
            this.buttonSeteazaReducere.Text = "Seteaza reducere";
            this.buttonSeteazaReducere.UseVisualStyleBackColor = true;
            this.buttonSeteazaReducere.Click += new System.EventHandler(this.buttonSeteazaReducere_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 31);
            this.label4.TabIndex = 9;
            this.label4.Text = "Discount nou (%):";
            // 
            // numericDiscount
            // 
            this.numericDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.numericDiscount.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericDiscount.Location = new System.Drawing.Point(263, 53);
            this.numericDiscount.Name = "numericDiscount";
            this.numericDiscount.Size = new System.Drawing.Size(194, 35);
            this.numericDiscount.TabIndex = 7;
            // 
            // labelReducere
            // 
            this.labelReducere.AutoSize = true;
            this.labelReducere.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReducere.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelReducere.Location = new System.Drawing.Point(196, 208);
            this.labelReducere.Name = "labelReducere";
            this.labelReducere.Size = new System.Drawing.Size(48, 29);
            this.labelReducere.TabIndex = 15;
            this.labelReducere.Tag = "";
            this.labelReducere.Text = "0%";
            // 
            // labelCategorieClient
            // 
            this.labelCategorieClient.AutoSize = true;
            this.labelCategorieClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategorieClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelCategorieClient.Location = new System.Drawing.Point(62, 162);
            this.labelCategorieClient.Name = "labelCategorieClient";
            this.labelCategorieClient.Size = new System.Drawing.Size(203, 31);
            this.labelCategorieClient.TabIndex = 11;
            this.labelCategorieClient.Text = "Categorie client";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonAnuleazaDiscount);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.dgvReduceriProgramate);
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1118, 469);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reduceri";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonAnuleazaDiscount
            // 
            this.buttonAnuleazaDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnuleazaDiscount.Location = new System.Drawing.Point(369, 396);
            this.buttonAnuleazaDiscount.Name = "buttonAnuleazaDiscount";
            this.buttonAnuleazaDiscount.Size = new System.Drawing.Size(387, 58);
            this.buttonAnuleazaDiscount.TabIndex = 27;
            this.buttonAnuleazaDiscount.Text = "Anuleaza discount selectat";
            this.buttonAnuleazaDiscount.UseVisualStyleBackColor = true;
            this.buttonAnuleazaDiscount.Click += new System.EventHandler(this.buttonAnuleazaDiscount_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateFiltruDataSfarsit);
            this.groupBox3.Controls.Add(this.dateFiltruDataInceput);
            this.groupBox3.Controls.Add(this.buttonResetFiltru);
            this.groupBox3.Controls.Add(this.buttonAplicaFiltru);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(786, 18);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 384);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtreaza dupa:";
            // 
            // dateFiltruDataSfarsit
            // 
            this.dateFiltruDataSfarsit.Checked = false;
            this.dateFiltruDataSfarsit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFiltruDataSfarsit.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFiltruDataSfarsit.Location = new System.Drawing.Point(11, 158);
            this.dateFiltruDataSfarsit.Name = "dateFiltruDataSfarsit";
            this.dateFiltruDataSfarsit.ShowCheckBox = true;
            this.dateFiltruDataSfarsit.Size = new System.Drawing.Size(276, 38);
            this.dateFiltruDataSfarsit.TabIndex = 26;
            // 
            // dateFiltruDataInceput
            // 
            this.dateFiltruDataInceput.Checked = false;
            this.dateFiltruDataInceput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFiltruDataInceput.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFiltruDataInceput.Location = new System.Drawing.Point(9, 73);
            this.dateFiltruDataInceput.Name = "dateFiltruDataInceput";
            this.dateFiltruDataInceput.Size = new System.Drawing.Size(276, 38);
            this.dateFiltruDataInceput.TabIndex = 25;
            this.dateFiltruDataInceput.ValueChanged += new System.EventHandler(this.dateFiltruDataInceput_ValueChanged);
            // 
            // buttonResetFiltru
            // 
            this.buttonResetFiltru.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonResetFiltru.Location = new System.Drawing.Point(11, 308);
            this.buttonResetFiltru.Name = "buttonResetFiltru";
            this.buttonResetFiltru.Size = new System.Drawing.Size(276, 58);
            this.buttonResetFiltru.TabIndex = 24;
            this.buttonResetFiltru.Text = "Reseteaza";
            this.buttonResetFiltru.UseVisualStyleBackColor = true;
            this.buttonResetFiltru.Click += new System.EventHandler(this.buttonResetFiltru_Click);
            // 
            // buttonAplicaFiltru
            // 
            this.buttonAplicaFiltru.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAplicaFiltru.Location = new System.Drawing.Point(11, 236);
            this.buttonAplicaFiltru.Name = "buttonAplicaFiltru";
            this.buttonAplicaFiltru.Size = new System.Drawing.Size(276, 58);
            this.buttonAplicaFiltru.TabIndex = 20;
            this.buttonAplicaFiltru.Text = "Aplica filtru";
            this.buttonAplicaFiltru.UseVisualStyleBackColor = true;
            this.buttonAplicaFiltru.Click += new System.EventHandler(this.buttonAplicaFiltru_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 29);
            this.label5.TabIndex = 22;
            this.label5.Text = "Data sfarsit:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 29);
            this.label3.TabIndex = 20;
            this.label3.Text = "Data inceput:";
            // 
            // dgvReduceriProgramate
            // 
            this.dgvReduceriProgramate.AllowUserToAddRows = false;
            this.dgvReduceriProgramate.AllowUserToDeleteRows = false;
            this.dgvReduceriProgramate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReduceriProgramate.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvReduceriProgramate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReduceriProgramate.Location = new System.Drawing.Point(17, 29);
            this.dgvReduceriProgramate.MultiSelect = false;
            this.dgvReduceriProgramate.Name = "dgvReduceriProgramate";
            this.dgvReduceriProgramate.ReadOnly = true;
            this.dgvReduceriProgramate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReduceriProgramate.Size = new System.Drawing.Size(739, 355);
            this.dgvReduceriProgramate.TabIndex = 13;
            this.dgvReduceriProgramate.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReduceriProgramate_CellClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(177, 29);
            this.label9.TabIndex = 23;
            this.label9.Text = "Alege tip client:";
            // 
            // cbTipClient
            // 
            this.cbTipClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipClient.FormattingEnabled = true;
            this.cbTipClient.Items.AddRange(new object[] {
            "Persoana fizica",
            "Persoana juridica"});
            this.cbTipClient.Location = new System.Drawing.Point(11, 63);
            this.cbTipClient.Name = "cbTipClient";
            this.cbTipClient.Size = new System.Drawing.Size(323, 37);
            this.cbTipClient.TabIndex = 24;
            this.cbTipClient.SelectedValueChanged += new System.EventHandler(this.cbTipClient_SelectedValueChanged);
            // 
            // GestiuneReduceriClienti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1519, 582);
            this.Controls.Add(this.cbTipClient);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBoxCategoriiClienti);
            this.Controls.Add(this.tabControl1);
            this.Name = "GestiuneReduceriClienti";
            this.Text = "GestiuneReduceriClienti";
            this.Load += new System.EventHandler(this.GestiuneReduceriClienti_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericDiscount)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReduceriProgramate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox listBoxCategoriiClienti;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelValabilPanaPe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelNrZile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dataDiscountSfarsit;
        private System.Windows.Forms.DateTimePicker dataDiscountInceput;
        private System.Windows.Forms.Button buttonSeteazaReducere;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericDiscount;
        private System.Windows.Forms.Label labelReducere;
        private System.Windows.Forms.Label labelCategorieClient;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonAnuleazaDiscount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateFiltruDataSfarsit;
        private System.Windows.Forms.DateTimePicker dateFiltruDataInceput;
        private System.Windows.Forms.Button buttonResetFiltru;
        private System.Windows.Forms.Button buttonAplicaFiltru;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvReduceriProgramate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbTipClient;

    }
}