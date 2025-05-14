using System;
using System.Drawing;
using System.Windows.Forms;

namespace atm_otomasyonu
{
    partial class MusteriLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtKullaniciAd, txtSifre;
        private System.Windows.Forms.Button btnGiris, btnNewKayit;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusteriLogin));
            txtKullaniciAd = new TextBox();
            txtSifre = new TextBox();
            btnGiris = new Button();
            btnNewKayit = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtKullaniciAd
            // 
            txtKullaniciAd.BackColor = Color.FromArgb(40, 40, 40);
            txtKullaniciAd.Font = new Font("Segoe UI", 14F);
            txtKullaniciAd.ForeColor = Color.White;
            txtKullaniciAd.Location = new Point(457, 98);
            txtKullaniciAd.Multiline = true;
            txtKullaniciAd.Name = "txtKullaniciAd";
            txtKullaniciAd.Size = new Size(200, 66);
            txtKullaniciAd.TabIndex = 0;
            // 
            // txtSifre
            // 
            txtSifre.BackColor = Color.FromArgb(40, 40, 40);
            txtSifre.Font = new Font("Segoe UI", 14F);
            txtSifre.ForeColor = Color.White;
            txtSifre.Location = new Point(457, 217);
            txtSifre.Multiline = true;
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(200, 66);
            txtSifre.TabIndex = 1;
            // 
            // btnGiris
            // 
            btnGiris.BackColor = Color.FromArgb(0, 128, 0);
            btnGiris.FlatAppearance.BorderColor = Color.DarkGreen;
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            btnGiris.ForeColor = Color.White;
            btnGiris.Image = (Image)resources.GetObject("btnGiris.Image");
            btnGiris.ImageAlign = ContentAlignment.MiddleLeft;
            btnGiris.Location = new Point(245, 333);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(137, 69);
            btnGiris.TabIndex = 4;
            btnGiris.Text = "Giriş Yap";
            btnGiris.TextAlign = ContentAlignment.MiddleRight;
            btnGiris.UseVisualStyleBackColor = false;
            btnGiris.Click += btnGiris_Click;
            // 
            // btnNewKayit
            // 
            btnNewKayit.BackColor = Color.FromArgb(128, 0, 0);
            btnNewKayit.FlatAppearance.BorderColor = Color.Maroon;
            btnNewKayit.FlatStyle = FlatStyle.Flat;
            btnNewKayit.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            btnNewKayit.ForeColor = Color.White;
            btnNewKayit.Image = (Image)resources.GetObject("btnNewKayit.Image");
            btnNewKayit.ImageAlign = ContentAlignment.MiddleLeft;
            btnNewKayit.Location = new Point(457, 333);
            btnNewKayit.Name = "btnNewKayit";
            btnNewKayit.Size = new Size(144, 69);
            btnNewKayit.TabIndex = 8;
            btnNewKayit.Text = "Kayıt Yap";
            btnNewKayit.TextAlign = ContentAlignment.MiddleRight;
            btnNewKayit.UseVisualStyleBackColor = false;
            btnNewKayit.Click += btnNewKayit_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(220, 98);
            label1.Name = "label1";
            label1.Size = new Size(145, 66);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Ad :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.White;
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(220, 217);
            label2.Name = "label2";
            label2.Size = new Size(145, 66);
            label2.TabIndex = 0;
            label2.Text = "Şifre :";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Footlight MT Light", 50.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.ImageAlign = ContentAlignment.MiddleRight;
            label3.Location = new Point(161, -7);
            label3.Name = "label3";
            label3.Size = new Size(522, 102);
            label3.TabIndex = 9;
            label3.Text = "BBK BANK";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MusteriLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(864, 483);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtKullaniciAd);
            Controls.Add(txtSifre);
            Controls.Add(btnGiris);
            Controls.Add(btnNewKayit);
            Name = "MusteriLogin";
            Text = "Giriş Yap";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
    }
}