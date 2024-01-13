namespace Hotel.App
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIdCont = new System.Windows.Forms.TextBox();
            this.btnConectare = new System.Windows.Forms.Button();
            this.textBoxParolaCont = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID cont:";
            // 
            // textBoxIdCont
            // 
            this.textBoxIdCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxIdCont.Location = new System.Drawing.Point(221, 80);
            this.textBoxIdCont.Name = "textBoxIdCont";
            this.textBoxIdCont.Size = new System.Drawing.Size(195, 32);
            this.textBoxIdCont.TabIndex = 1;
            // 
            // btnConectare
            // 
            this.btnConectare.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectare.Location = new System.Drawing.Point(221, 193);
            this.btnConectare.Name = "btnConectare";
            this.btnConectare.Size = new System.Drawing.Size(161, 50);
            this.btnConectare.TabIndex = 3;
            this.btnConectare.Text = "Conectare";
            this.btnConectare.UseVisualStyleBackColor = true;
            this.btnConectare.Click += new System.EventHandler(this.btnConectare_Click);
            // 
            // textBoxParolaCont
            // 
            this.textBoxParolaCont.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxParolaCont.Location = new System.Drawing.Point(221, 124);
            this.textBoxParolaCont.Name = "textBoxParolaCont";
            this.textBoxParolaCont.PasswordChar = '*';
            this.textBoxParolaCont.Size = new System.Drawing.Size(195, 32);
            this.textBoxParolaCont.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Parola:";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 331);
            this.Controls.Add(this.textBoxParolaCont);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConectare);
            this.Controls.Add(this.textBoxIdCont);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIdCont;
        private System.Windows.Forms.Button btnConectare;
        private System.Windows.Forms.TextBox textBoxParolaCont;
        private System.Windows.Forms.Label label2;
    }
}