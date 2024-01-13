namespace Hotel.App
{
    partial class Receptioner
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
            this.btnCazare = new System.Windows.Forms.Button();
            this.btnRezervare = new System.Windows.Forms.Button();
            this.btnIstoricCazari = new System.Windows.Forms.Button();
            this.btnIstoricRezervari = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCazare
            // 
            this.btnCazare.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCazare.Location = new System.Drawing.Point(122, 51);
            this.btnCazare.Name = "btnCazare";
            this.btnCazare.Size = new System.Drawing.Size(336, 91);
            this.btnCazare.TabIndex = 6;
            this.btnCazare.Text = "Cazare";
            this.btnCazare.UseVisualStyleBackColor = true;
            this.btnCazare.Click += new System.EventHandler(this.btnCazare_Click);
            // 
            // btnRezervare
            // 
            this.btnRezervare.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRezervare.Location = new System.Drawing.Point(122, 166);
            this.btnRezervare.Name = "btnRezervare";
            this.btnRezervare.Size = new System.Drawing.Size(336, 91);
            this.btnRezervare.TabIndex = 8;
            this.btnRezervare.Text = "Rezervare";
            this.btnRezervare.UseVisualStyleBackColor = true;
            this.btnRezervare.Click += new System.EventHandler(this.btnRezervare_Click);
            // 
            // btnIstoricCazari
            // 
            this.btnIstoricCazari.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIstoricCazari.Location = new System.Drawing.Point(122, 280);
            this.btnIstoricCazari.Name = "btnIstoricCazari";
            this.btnIstoricCazari.Size = new System.Drawing.Size(336, 91);
            this.btnIstoricCazari.TabIndex = 9;
            this.btnIstoricCazari.Text = "Istoric cazari";
            this.btnIstoricCazari.UseVisualStyleBackColor = true;
            this.btnIstoricCazari.Click += new System.EventHandler(this.btnIstoricCazari_Click);
            // 
            // btnIstoricRezervari
            // 
            this.btnIstoricRezervari.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIstoricRezervari.Location = new System.Drawing.Point(122, 391);
            this.btnIstoricRezervari.Name = "btnIstoricRezervari";
            this.btnIstoricRezervari.Size = new System.Drawing.Size(336, 91);
            this.btnIstoricRezervari.TabIndex = 10;
            this.btnIstoricRezervari.Text = "Istoric rezervari";
            this.btnIstoricRezervari.UseVisualStyleBackColor = true;
            this.btnIstoricRezervari.Click += new System.EventHandler(this.btnIstoricRezervari_Click);
            // 
            // Receptioner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 534);
            this.Controls.Add(this.btnIstoricRezervari);
            this.Controls.Add(this.btnIstoricCazari);
            this.Controls.Add(this.btnRezervare);
            this.Controls.Add(this.btnCazare);
            this.Name = "Receptioner";
            this.Text = "Receptioner";
            this.Load += new System.EventHandler(this.Receptioner_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCazare;
        private System.Windows.Forms.Button btnRezervare;
        private System.Windows.Forms.Button btnIstoricCazari;
        private System.Windows.Forms.Button btnIstoricRezervari;




    }
}