using System;
using System.Drawing;
using System.Windows.Forms;

namespace atm_otomasyonu
{
    partial class MusteriKayitForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtAd, txtSoyad, txtSifre, txtTC, txtPOS;
        private System.Windows.Forms.Label lblAd, lblSoyad, lblSifre, lblTC, lblTel, lblPOS;
        private System.Windows.Forms.Button btnKaydet, btnGeri;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTel;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusteriKayitForm));
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            txtSifre = new TextBox();
            txtTC = new TextBox();
            txtPOS = new TextBox();
            lblAd = new Label();
            lblSoyad = new Label();
            lblSifre = new Label();
            lblTC = new Label();
            lblTel = new Label();
            lblPOS = new Label();
            maskedTextBoxTel = new MaskedTextBox();
            btnKaydet = new Button();
            btnGeri = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtAd
            // 
            txtAd.BackColor = Color.FromArgb(40, 40, 40);
            txtAd.ForeColor = Color.White;
            txtAd.Location = new Point(478, 103);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(210, 25);
            txtAd.TabIndex = 0;
            // 
            // txtSoyad
            // 
            txtSoyad.BackColor = Color.FromArgb(40, 40, 40);
            txtSoyad.ForeColor = Color.White;
            txtSoyad.Location = new Point(478, 143);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(210, 25);
            txtSoyad.TabIndex = 1;
            // 
            // txtSifre
            // 
            txtSifre.BackColor = Color.FromArgb(40, 40, 40);
            txtSifre.ForeColor = Color.White;
            txtSifre.Location = new Point(478, 183);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(210, 25);
            txtSifre.TabIndex = 2;
            // 
            // txtTC
            // 
            txtTC.BackColor = Color.FromArgb(40, 40, 40);
            txtTC.ForeColor = Color.White;
            txtTC.Location = new Point(478, 223);
            txtTC.MaxLength = 11;
            txtTC.Name = "txtTC";
            txtTC.Size = new Size(210, 25);
            txtTC.TabIndex = 3;
            // 
            // txtPOS
            // 
            txtPOS.BackColor = Color.FromArgb(40, 40, 40);
            txtPOS.ForeColor = Color.White;
            txtPOS.Location = new Point(478, 303);
            txtPOS.Name = "txtPOS";
            txtPOS.Size = new Size(210, 25);
            txtPOS.TabIndex = 5;
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAd.ForeColor = Color.FromArgb(0, 204, 255);
            lblAd.Location = new Point(190, 106);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(55, 19);
            lblAd.TabIndex = 5;
            lblAd.Text = "Adınız:";
            // 
            // lblSoyad
            // 
            lblSoyad.AutoSize = true;
            lblSoyad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSoyad.ForeColor = Color.FromArgb(0, 204, 255);
            lblSoyad.Location = new Point(190, 146);
            lblSoyad.Name = "lblSoyad";
            lblSoyad.Size = new Size(78, 19);
            lblSoyad.TabIndex = 6;
            lblSoyad.Text = "Soyadınız:";
            // 
            // lblSifre
            // 
            lblSifre.AutoSize = true;
            lblSifre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSifre.ForeColor = Color.FromArgb(0, 204, 255);
            lblSifre.Location = new Point(190, 186);
            lblSifre.Name = "lblSifre";
            lblSifre.Size = new Size(63, 19);
            lblSifre.TabIndex = 7;
            lblSifre.Text = "Şifreniz:";
            // 
            // lblTC
            // 
            lblTC.AutoSize = true;
            lblTC.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTC.ForeColor = Color.FromArgb(0, 204, 255);
            lblTC.Location = new Point(190, 226);
            lblTC.Name = "lblTC";
            lblTC.Size = new Size(100, 19);
            lblTC.TabIndex = 8;
            lblTC.Text = "TC Kimlik No:";
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTel.ForeColor = Color.FromArgb(0, 204, 255);
            lblTel.Location = new Point(190, 266);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(86, 19);
            lblTel.TabIndex = 9;
            lblTel.Text = "Telefon No:";
            // 
            // lblPOS
            // 
            lblPOS.AutoSize = true;
            lblPOS.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPOS.ForeColor = Color.FromArgb(0, 204, 255);
            lblPOS.Location = new Point(190, 306);
            lblPOS.Name = "lblPOS";
            lblPOS.Size = new Size(63, 19);
            lblPOS.TabIndex = 10;
            lblPOS.Text = "E-Posta:";
            // 
            // maskedTextBoxTel
            // 
            maskedTextBoxTel.BackColor = Color.FromArgb(40, 40, 40);
            maskedTextBoxTel.ForeColor = Color.White;
            maskedTextBoxTel.Location = new Point(478, 263);
            maskedTextBoxTel.Mask = "(000) 000-0000";
            maskedTextBoxTel.Name = "maskedTextBoxTel";
            maskedTextBoxTel.Size = new Size(210, 25);
            maskedTextBoxTel.TabIndex = 4;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.ForestGreen;
            btnKaydet.FlatAppearance.BorderColor = Color.DarkGreen;
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnKaydet.ForeColor = Color.White;
            btnKaydet.Image = (Image)resources.GetObject("btnKaydet.Image");
            btnKaydet.ImageAlign = ContentAlignment.MiddleLeft;
            btnKaydet.Location = new Point(568, 361);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(120, 49);
            btnKaydet.TabIndex = 6;
            btnKaydet.Text = "  Kaydet";
            btnKaydet.TextAlign = ContentAlignment.MiddleRight;
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnGeri
            // 
            btnGeri.BackColor = Color.FromArgb(128, 0, 0);
            btnGeri.FlatAppearance.BorderColor = Color.Maroon;
            btnGeri.FlatAppearance.BorderSize = 0;
            btnGeri.FlatStyle = FlatStyle.Popup;
            btnGeri.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGeri.ForeColor = Color.White;
            btnGeri.Image = (Image)resources.GetObject("btnGeri.Image");
            btnGeri.ImageAlign = ContentAlignment.MiddleLeft;
            btnGeri.Location = new Point(204, 361);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(120, 49);
            btnGeri.TabIndex = 7;
            btnGeri.Text = "  Geri";
            btnGeri.TextAlign = ContentAlignment.MiddleRight;
            btnGeri.UseVisualStyleBackColor = false;
            btnGeri.Click += Back_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Footlight MT Light", 50.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(127, -13);
            label1.Name = "label1";
            label1.Size = new Size(522, 102);
            label1.TabIndex = 12;
            label1.Text = "BBK BANK";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MusteriKayitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(864, 513);
            Controls.Add(label1);
            Controls.Add(txtAd);
            Controls.Add(txtSoyad);
            Controls.Add(txtSifre);
            Controls.Add(txtTC);
            Controls.Add(txtPOS);
            Controls.Add(lblAd);
            Controls.Add(lblSoyad);
            Controls.Add(lblSifre);
            Controls.Add(lblTC);
            Controls.Add(lblTel);
            Controls.Add(lblPOS);
            Controls.Add(maskedTextBoxTel);
            Controls.Add(btnKaydet);
            Controls.Add(btnGeri);
            Font = new Font("Segoe UI", 10F);
            ForeColor = Color.White;
            Name = "MusteriKayitForm";
            Text = "BBK Bank - Müşteri Kayıt";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}