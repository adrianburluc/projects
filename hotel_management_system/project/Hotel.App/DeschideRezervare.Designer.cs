namespace Hotel.App
{
    partial class DeschideRezervare
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
            this.dataInceputSejur = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataSfarsitSejur = new System.Windows.Forms.DateTimePicker();
            this.btnContinua = new System.Windows.Forms.Button();
            this.nrOaspeti = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nrOaspeti)).BeginInit();
            this.SuspendLayout();
            // 
            // dataInceputSejur
            // 
            this.dataInceputSejur.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataInceputSejur.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataInceputSejur.Location = new System.Drawing.Point(229, 90);
            this.dataInceputSejur.Name = "dataInceputSejur";
            this.dataInceputSejur.Size = new System.Drawing.Size(200, 38);
            this.dataInceputSejur.TabIndex = 0;
            this.dataInceputSejur.ValueChanged += new System.EventHandler(this.dataInceputSejur_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Data inceput:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data sfarsit:";
            // 
            // dataSfarsitSejur
            // 
            this.dataSfarsitSejur.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSfarsitSejur.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataSfarsitSejur.Location = new System.Drawing.Point(229, 152);
            this.dataSfarsitSejur.Name = "dataSfarsitSejur";
            this.dataSfarsitSejur.Size = new System.Drawing.Size(200, 38);
            this.dataSfarsitSejur.TabIndex = 2;
            // 
            // btnContinua
            // 
            this.btnContinua.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinua.Location = new System.Drawing.Point(147, 307);
            this.btnContinua.Name = "btnContinua";
            this.btnContinua.Size = new System.Drawing.Size(183, 66);
            this.btnContinua.TabIndex = 4;
            this.btnContinua.Text = "Continua";
            this.btnContinua.UseVisualStyleBackColor = true;
            this.btnContinua.Click += new System.EventHandler(this.btnContinua_Click);
            // 
            // nrOaspeti
            // 
            this.nrOaspeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nrOaspeti.Location = new System.Drawing.Point(229, 213);
            this.nrOaspeti.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nrOaspeti.Name = "nrOaspeti";
            this.nrOaspeti.Size = new System.Drawing.Size(200, 38);
            this.nrOaspeti.TabIndex = 7;
            this.nrOaspeti.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "Numar oaspeti:";
            // 
            // DeschideRezervare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 412);
            this.Controls.Add(this.nrOaspeti);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnContinua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataSfarsitSejur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataInceputSejur);
            this.Name = "DeschideRezervare";
            this.Text = "DeschideRezervare";
            this.Load += new System.EventHandler(this.DeschideRezervare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nrOaspeti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dataInceputSejur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dataSfarsitSejur;
        private System.Windows.Forms.Button btnContinua;
        private System.Windows.Forms.NumericUpDown nrOaspeti;
        private System.Windows.Forms.Label label3;
    }
}