namespace Hotel.App
{
    partial class OptiuniTarife
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
            this.btnTarifeServicii = new System.Windows.Forms.Button();
            this.btnTarifeCamere = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTarifeServicii
            // 
            this.btnTarifeServicii.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarifeServicii.Location = new System.Drawing.Point(103, 99);
            this.btnTarifeServicii.Name = "btnTarifeServicii";
            this.btnTarifeServicii.Size = new System.Drawing.Size(300, 96);
            this.btnTarifeServicii.TabIndex = 0;
            this.btnTarifeServicii.Text = "Tarife servicii";
            this.btnTarifeServicii.UseVisualStyleBackColor = true;
            this.btnTarifeServicii.Click += new System.EventHandler(this.btnTarifeServicii_Click);
            // 
            // btnTarifeCamere
            // 
            this.btnTarifeCamere.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTarifeCamere.Location = new System.Drawing.Point(103, 230);
            this.btnTarifeCamere.Name = "btnTarifeCamere";
            this.btnTarifeCamere.Size = new System.Drawing.Size(300, 96);
            this.btnTarifeCamere.TabIndex = 1;
            this.btnTarifeCamere.Text = "Tarife camere";
            this.btnTarifeCamere.UseVisualStyleBackColor = true;
            this.btnTarifeCamere.Click += new System.EventHandler(this.btnTarifeCamere_Click);
            // 
            // OptiuniTarife
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 470);
            this.Controls.Add(this.btnTarifeCamere);
            this.Controls.Add(this.btnTarifeServicii);
            this.Name = "OptiuniTarife";
            this.Text = "OptiuniTarife";
            this.Load += new System.EventHandler(this.OptiuniTarife_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTarifeServicii;
        private System.Windows.Forms.Button btnTarifeCamere;
    }
}