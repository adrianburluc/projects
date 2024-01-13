namespace Hotel.App
{
    partial class OptiuniReduceri
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
            this.btnGestiuneReduceriClienti = new System.Windows.Forms.Button();
            this.btnGestiuneReduceriCamere = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGestiuneReduceriClienti
            // 
            this.btnGestiuneReduceriClienti.Location = new System.Drawing.Point(122, 143);
            this.btnGestiuneReduceriClienti.Margin = new System.Windows.Forms.Padding(6);
            this.btnGestiuneReduceriClienti.Name = "btnGestiuneReduceriClienti";
            this.btnGestiuneReduceriClienti.Size = new System.Drawing.Size(300, 50);
            this.btnGestiuneReduceriClienti.TabIndex = 0;
            this.btnGestiuneReduceriClienti.Text = "Reduceri clienti";
            this.btnGestiuneReduceriClienti.UseVisualStyleBackColor = true;
            this.btnGestiuneReduceriClienti.Click += new System.EventHandler(this.btnGestiuneReduceriClienti_Click);
            // 
            // btnGestiuneReduceriCamere
            // 
            this.btnGestiuneReduceriCamere.Location = new System.Drawing.Point(122, 209);
            this.btnGestiuneReduceriCamere.Margin = new System.Windows.Forms.Padding(6);
            this.btnGestiuneReduceriCamere.Name = "btnGestiuneReduceriCamere";
            this.btnGestiuneReduceriCamere.Size = new System.Drawing.Size(300, 50);
            this.btnGestiuneReduceriCamere.TabIndex = 1;
            this.btnGestiuneReduceriCamere.Text = "Reduceri camere de sezon";
            this.btnGestiuneReduceriCamere.UseVisualStyleBackColor = true;
            this.btnGestiuneReduceriCamere.Click += new System.EventHandler(this.btnGestiuneReduceriCamere_Click);
            // 
            // OptiuniReduceri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 482);
            this.Controls.Add(this.btnGestiuneReduceriCamere);
            this.Controls.Add(this.btnGestiuneReduceriClienti);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "OptiuniReduceri";
            this.Text = "OptiuniReduceri";
            this.Load += new System.EventHandler(this.OptiuniReduceri_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGestiuneReduceriClienti;
        private System.Windows.Forms.Button btnGestiuneReduceriCamere;
    }
}