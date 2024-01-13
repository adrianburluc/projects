namespace Hotel.App
{
    partial class Rapoarte
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grafic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cbTipRaport = new System.Windows.Forms.ComboBox();
            this.dataInceputRaport = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataSfarsitRaport = new System.Windows.Forms.DateTimePicker();
            this.btnGenereazaGrafic = new System.Windows.Forms.Button();
            this.btnSavePdf = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grafic)).BeginInit();
            this.SuspendLayout();
            // 
            // grafic
            // 
            chartArea3.Name = "ChartArea1";
            this.grafic.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.grafic.Legends.Add(legend3);
            this.grafic.Location = new System.Drawing.Point(59, 336);
            this.grafic.Name = "grafic";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.grafic.Series.Add(series3);
            this.grafic.Size = new System.Drawing.Size(968, 381);
            this.grafic.TabIndex = 0;
            this.grafic.Text = "chart1";
            // 
            // cbTipRaport
            // 
            this.cbTipRaport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipRaport.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipRaport.FormattingEnabled = true;
            this.cbTipRaport.Items.AddRange(new object[] {
            "Evolutia cazarilor pe luna",
            "Evolutia rezervarilor pe luna",
            ""});
            this.cbTipRaport.Location = new System.Drawing.Point(234, 31);
            this.cbTipRaport.Name = "cbTipRaport";
            this.cbTipRaport.Size = new System.Drawing.Size(393, 39);
            this.cbTipRaport.TabIndex = 1;
            // 
            // dataInceputRaport
            // 
            this.dataInceputRaport.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataInceputRaport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataInceputRaport.Location = new System.Drawing.Point(234, 103);
            this.dataInceputRaport.Name = "dataInceputRaport";
            this.dataInceputRaport.Size = new System.Drawing.Size(220, 38);
            this.dataInceputRaport.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tipul de raport:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 31);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data inceput:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 31);
            this.label3.TabIndex = 6;
            this.label3.Text = "Data sfarsit:";
            // 
            // dataSfarsitRaport
            // 
            this.dataSfarsitRaport.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataSfarsitRaport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataSfarsitRaport.Location = new System.Drawing.Point(234, 167);
            this.dataSfarsitRaport.Name = "dataSfarsitRaport";
            this.dataSfarsitRaport.Size = new System.Drawing.Size(220, 38);
            this.dataSfarsitRaport.TabIndex = 5;
            // 
            // btnGenereazaGrafic
            // 
            this.btnGenereazaGrafic.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenereazaGrafic.Location = new System.Drawing.Point(234, 238);
            this.btnGenereazaGrafic.Name = "btnGenereazaGrafic";
            this.btnGenereazaGrafic.Size = new System.Drawing.Size(309, 61);
            this.btnGenereazaGrafic.TabIndex = 7;
            this.btnGenereazaGrafic.Text = "Genereaza grafic raport";
            this.btnGenereazaGrafic.UseVisualStyleBackColor = true;
            this.btnGenereazaGrafic.Click += new System.EventHandler(this.btnGenereazaGrafic_Click);
            // 
            // btnSavePdf
            // 
            this.btnSavePdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePdf.Location = new System.Drawing.Point(784, 735);
            this.btnSavePdf.Name = "btnSavePdf";
            this.btnSavePdf.Size = new System.Drawing.Size(243, 61);
            this.btnSavePdf.TabIndex = 8;
            this.btnSavePdf.Text = "Salveaza imaginea";
            this.btnSavePdf.UseVisualStyleBackColor = true;
            this.btnSavePdf.Click += new System.EventHandler(this.btnSavePdf_Click);
            // 
            // Rapoarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 825);
            this.Controls.Add(this.btnSavePdf);
            this.Controls.Add(this.btnGenereazaGrafic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataSfarsitRaport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataInceputRaport);
            this.Controls.Add(this.cbTipRaport);
            this.Controls.Add(this.grafic);
            this.Name = "Rapoarte";
            this.Text = "Rapoarte";
            this.Load += new System.EventHandler(this.Rapoarte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grafic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart grafic;
        private System.Windows.Forms.ComboBox cbTipRaport;
        private System.Windows.Forms.DateTimePicker dataInceputRaport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dataSfarsitRaport;
        private System.Windows.Forms.Button btnGenereazaGrafic;
        private System.Windows.Forms.Button btnSavePdf;
    }
}