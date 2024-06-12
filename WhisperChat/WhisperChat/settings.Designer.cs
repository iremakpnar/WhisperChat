namespace WhisperChat
{
    partial class settings
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
            this.btnResimDegistir = new System.Windows.Forms.Button();
            this.btnSifreDegistir = new System.Windows.Forms.Button();
            this.btnHesapSil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnResimDegistir
            // 
            this.btnResimDegistir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnResimDegistir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnResimDegistir.Location = new System.Drawing.Point(96, 190);
            this.btnResimDegistir.Name = "btnResimDegistir";
            this.btnResimDegistir.Size = new System.Drawing.Size(391, 54);
            this.btnResimDegistir.TabIndex = 18;
            this.btnResimDegistir.Text = "Resim Değiştir    ";
            this.btnResimDegistir.UseVisualStyleBackColor = true;
            this.btnResimDegistir.Click += new System.EventHandler(this.btnResimDegistir_Click);
            // 
            // btnSifreDegistir
            // 
            this.btnSifreDegistir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSifreDegistir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSifreDegistir.Location = new System.Drawing.Point(96, 269);
            this.btnSifreDegistir.Name = "btnSifreDegistir";
            this.btnSifreDegistir.Size = new System.Drawing.Size(391, 54);
            this.btnSifreDegistir.TabIndex = 19;
            this.btnSifreDegistir.Text = "Şifre Değiştir  ";
            this.btnSifreDegistir.UseVisualStyleBackColor = true;
            // 
            // btnHesapSil
            // 
            this.btnHesapSil.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnHesapSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHesapSil.Location = new System.Drawing.Point(96, 349);
            this.btnHesapSil.Name = "btnHesapSil";
            this.btnHesapSil.Size = new System.Drawing.Size(391, 54);
            this.btnHesapSil.TabIndex = 20;
            this.btnHesapSil.Text = "Hesabımı Sil  ";
            this.btnHesapSil.UseVisualStyleBackColor = true;
            // 
            // settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(61)))), ((int)(((byte)(98)))));
            this.ClientSize = new System.Drawing.Size(586, 556);
            this.Controls.Add(this.btnHesapSil);
            this.Controls.Add(this.btnSifreDegistir);
            this.Controls.Add(this.btnResimDegistir);
            this.Name = "settings";
            this.Text = "settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnResimDegistir;
        private System.Windows.Forms.Button btnSifreDegistir;
        private System.Windows.Forms.Button btnHesapSil;
    }
}