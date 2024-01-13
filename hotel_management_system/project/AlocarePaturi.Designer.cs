namespace Hotel.App
{
    partial class AlocarePaturi
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
            this.listBoxTipPaturi = new System.Windows.Forms.ListBox();
            this.buttonStergePat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericNrPaturi = new System.Windows.Forms.NumericUpDown();
            this.cbTipPat = new System.Windows.Forms.ComboBox();
            this.buttonAdaugaPat = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonModificaPat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericNrPaturi)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxTipCamere
            // 
            this.listBoxTipCamere.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTipCamere.FormattingEnabled = true;
            this.listBoxTipCamere.ItemHeight = 24;
            this.listBoxTipCamere.Location = new System.Drawing.Point(12, 45);
            this.listBoxTipCamere.Name = "listBoxTipCamere";
            this.listBoxTipCamere.Size = new System.Drawing.Size(200, 172);
            this.listBoxTipCamere.TabIndex = 0;
            this.listBoxTipCamere.SelectedIndexChanged += new System.EventHandler(this.listBoxTipCamere_SelectedIndexChanged);
            // 
            // listBoxTipPaturi
            // 
            this.listBoxTipPaturi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxTipPaturi.FormattingEnabled = true;
            this.listBoxTipPaturi.ItemHeight = 24;
            this.listBoxTipPaturi.Location = new System.Drawing.Point(233, 45);
            this.listBoxTipPaturi.Name = "listBoxTipPaturi";
            this.listBoxTipPaturi.Size = new System.Drawing.Size(200, 172);
            this.listBoxTipPaturi.Sorted = true;
            this.listBoxTipPaturi.TabIndex = 1;
            this.listBoxTipPaturi.SelectedIndexChanged += new System.EventHandler(this.listBoxTipPaturi_SelectedIndexChanged);
            // 
            // buttonStergePat
            // 
            this.buttonStergePat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStergePat.Location = new System.Drawing.Point(304, 380);
            this.buttonStergePat.Name = "buttonStergePat";
            this.buttonStergePat.Size = new System.Drawing.Size(140, 40);
            this.buttonStergePat.TabIndex = 2;
            this.buttonStergePat.Text = "Sterge";
            this.buttonStergePat.UseVisualStyleBackColor = true;
            this.buttonStergePat.Click += new System.EventHandler(this.buttonStergePat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Numar paturi:";
            // 
            // numericNrPaturi
            // 
            this.numericNrPaturi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericNrPaturi.Location = new System.Drawing.Point(12, 325);
            this.numericNrPaturi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericNrPaturi.Name = "numericNrPaturi";
            this.numericNrPaturi.Size = new System.Drawing.Size(200, 27);
            this.numericNrPaturi.TabIndex = 5;
            this.numericNrPaturi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbTipPat
            // 
            this.cbTipPat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipPat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipPat.FormattingEnabled = true;
            this.cbTipPat.Location = new System.Drawing.Point(12, 262);
            this.cbTipPat.Name = "cbTipPat";
            this.cbTipPat.Size = new System.Drawing.Size(200, 28);
            this.cbTipPat.TabIndex = 6;
            // 
            // buttonAdaugaPat
            // 
            this.buttonAdaugaPat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdaugaPat.Location = new System.Drawing.Point(12, 380);
            this.buttonAdaugaPat.Name = "buttonAdaugaPat";
            this.buttonAdaugaPat.Size = new System.Drawing.Size(140, 40);
            this.buttonAdaugaPat.TabIndex = 7;
            this.buttonAdaugaPat.Text = "Adauga";
            this.buttonAdaugaPat.UseVisualStyleBackColor = true;
            this.buttonAdaugaPat.Click += new System.EventHandler(this.buttonAdaugaPat_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Selectati camera:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(229, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Paturile camerei:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 235);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Selecteaza pat:";
            // 
            // buttonModificaPat
            // 
            this.buttonModificaPat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModificaPat.Location = new System.Drawing.Point(158, 380);
            this.buttonModificaPat.Name = "buttonModificaPat";
            this.buttonModificaPat.Size = new System.Drawing.Size(140, 40);
            this.buttonModificaPat.TabIndex = 11;
            this.buttonModificaPat.Text = "Modifica";
            this.buttonModificaPat.UseVisualStyleBackColor = true;
            this.buttonModificaPat.Click += new System.EventHandler(this.buttonModificaPat_Click);
            // 
            // AlocarePaturi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 434);
            this.Controls.Add(this.buttonModificaPat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericNrPaturi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbTipPat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonStergePat);
            this.Controls.Add(this.buttonAdaugaPat);
            this.Controls.Add(this.listBoxTipPaturi);
            this.Controls.Add(this.listBoxTipCamere);
            this.Name = "AlocarePaturi";
            this.Text = "AlocarePaturi";
            this.Load += new System.EventHandler(this.AlocarePaturi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericNrPaturi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTipCamere;
        private System.Windows.Forms.ListBox listBoxTipPaturi;
        private System.Windows.Forms.Button buttonStergePat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericNrPaturi;
        private System.Windows.Forms.ComboBox cbTipPat;
        private System.Windows.Forms.Button buttonAdaugaPat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonModificaPat;
    }
}