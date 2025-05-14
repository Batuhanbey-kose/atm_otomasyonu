
namespace atm_otomasyonu
{
    partial class ParaYatirma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblKullanici;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Button btnParaYatir;
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

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParaYatirma));
            btnParaYatir = new Button();
            txtTutar = new TextBox();
            lblMiktar = new Label();
            btnGeri = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnParaYatir
            // 
            btnParaYatir.BackColor = Color.Salmon;
            btnParaYatir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnParaYatir.ForeColor = Color.White;
            btnParaYatir.Image = (Image)resources.GetObject("btnParaYatir.Image");
            btnParaYatir.ImageAlign = ContentAlignment.MiddleLeft;
            btnParaYatir.Location = new Point(598, 256);
            btnParaYatir.Name = "btnParaYatir";
            btnParaYatir.Size = new Size(134, 64);
            btnParaYatir.TabIndex = 4;
            btnParaYatir.Text = "              Para yatır";
            btnParaYatir.UseVisualStyleBackColor = false;
            btnParaYatir.Click += btnYatir_Click;
            // 
            // txtTutar
            // 
            txtTutar.BackColor = Color.FromArgb(45, 45, 45);
            txtTutar.Font = new Font("Segoe UI", 15F);
            txtTutar.ForeColor = Color.White;
            txtTutar.Location = new Point(532, 132);
            txtTutar.MaxLength = 10;
            txtTutar.Multiline = true;
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(200, 52);
            txtTutar.TabIndex = 5;
            txtTutar.TextChanged += txtTutar_TextChanged;
            // 
            // lblMiktar
            // 
            lblMiktar.BackColor = Color.Orange;
            lblMiktar.BorderStyle = BorderStyle.FixedSingle;
            lblMiktar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblMiktar.ForeColor = Color.White;
            lblMiktar.Image = (Image)resources.GetObject("lblMiktar.Image");
            lblMiktar.ImageAlign = ContentAlignment.MiddleLeft;
            lblMiktar.Location = new Point(149, 132);
            lblMiktar.Name = "lblMiktar";
            lblMiktar.Size = new Size(187, 52);
            lblMiktar.TabIndex = 6;
            lblMiktar.Text = "Miktar Giriniz:";
            lblMiktar.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnGeri
            // 
            btnGeri.BackColor = Color.Maroon;
            btnGeri.FlatAppearance.BorderSize = 0;
            btnGeri.FlatStyle = FlatStyle.Flat;
            btnGeri.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGeri.ForeColor = Color.White;
            btnGeri.Image = (Image)resources.GetObject("btnGeri.Image");
            btnGeri.ImageAlign = ContentAlignment.MiddleLeft;
            btnGeri.Location = new Point(149, 261);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(134, 59);
            btnGeri.TabIndex = 3;
            btnGeri.Text = "   Geri";
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
            label1.Location = new Point(135, 5);
            label1.Name = "label1";
            label1.Size = new Size(522, 102);
            label1.TabIndex = 12;
            label1.Text = "BBK BANK";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ParaYatirma
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(864, 513);
            Controls.Add(label1);
            Controls.Add(btnGeri);
            Controls.Add(lblMiktar);
            Controls.Add(txtTutar);
            Controls.Add(btnParaYatir);
            Name = "ParaYatirma";
            Text = "               para yatır";
            Load += ParaYatirma_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private TextBox txtTutar;
        private Label lblMiktar;
        private Button btnGeri;
        private Label label1;
    }
}
//using System;
//using System.Drawing;
//using System.Windows.Forms;

//namespace atm_otomasyonu
//{
//    public partial class MusteriKayitForm : Form
//    {
//        private System.ComponentModel.IContainer components = null;
//        private TextBox txtAd, txtSoyad, txtSifre, txtTC, txtPOS;
//        private MaskedTextBox maskedTextBoxTel;
//        private Label lblAd, lblSoyad, lblSifre, lblTC, lblTel, lblPOS;
//        private Button btnKaydet, btnGeri;

//        public MusteriKayitForm()
//        {
//            this.InitializeComponent();
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (this.components != null))
//            {
//                this.components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        private void InitializeComponent()
//        {
//            this.txtAd = new TextBox();
//            this.txtSoyad = new TextBox();
//            this.txtSifre = new TextBox();
//            this.txtTC = new TextBox();
//            this.txtPOS = new TextBox();
//            this.maskedTextBoxTel = new MaskedTextBox();
//            this.lblAd = new Label();
//            this.lblSoyad = new Label();
//            this.lblSifre = new Label();
//            this.lblTC = new Label();
//            this.lblTel = new Label();
//            this.lblPOS = new Label();
//            this.btnKaydet = new Button();
//            this.btnGeri = new Button();
//            this.SuspendLayout();

//            // Form Ayarları
//            this.BackColor = Color.FromArgb(45, 45, 48);
//            this.ClientSize = new Size(500, 450);
//            this.Font = new Font("Segoe UI", 10F);
//            this.Text = "BBK Bank - Müşteri Kayıt";
//            this.FormBorderStyle = FormBorderStyle.FixedDialog;
//            this.MaximizeBox = false;

//            // txtAd
//            this.txtAd.Location = new Point(200, 40);
//            this.txtAd.Size = new Size(240, 27);
//            this.txtAd.BackColor = Color.FromArgb(60, 60, 65);
//            this.txtAd.ForeColor = Color.White;

//            // lblAd
//            this.lblAd.Location = new Point(30, 40);
//            this.lblAd.Text = "Adınız:";
//            this.lblAd.ForeColor = Color.FromArgb(0, 204, 255);
//            this.lblAd.AutoSize = true;

//            // txtSoyad
//            this.txtSoyad.Location = new Point(200, 80);
//            this.txtSoyad.Size = new Size(240, 27);
//            this.txtSoyad.BackColor = Color.FromArgb(60, 60, 65);
//            this.txtSoyad.ForeColor = Color.White;

//            // lblSoyad
//            this.lblSoyad.Location = new Point(30, 80);
//            this.lblSoyad.Text = "Soyadınız:";
//            this.lblSoyad.ForeColor = Color.FromArgb(0, 204, 255);
//            this.lblSoyad.AutoSize = true;

//            // txtSifre
//            this.txtSifre.Location = new Point(200, 120);
//            this.txtSifre.PasswordChar = '*';
//            this.txtSifre.Size = new Size(240, 27);
//            this.txtSifre.BackColor = Color.FromArgb(60, 60, 65);
//            this.txtSifre.ForeColor = Color.White;

//            // lblSifre
//            this.lblSifre.Location = new Point(30, 120);
//            this.lblSifre.Text = "Şifreniz:";
//            this.lblSifre.ForeColor = Color.FromArgb(0, 204, 255);
//            this.lblSifre.AutoSize = true;

//            // txtTC
//            this.txtTC.Location = new Point(200, 160);
//            this.txtTC.MaxLength = 11;
//            this.txtTC.Size = new Size(240, 27);
//            this.txtTC.BackColor = Color.FromArgb(60, 60, 65);
//            this.txtTC.ForeColor = Color.White;

//            // lblTC
//            this.lblTC.Location = new Point(30, 160);
//            this.lblTC.Text = "TC Kimlik No:";
//            this.lblTC.ForeColor = Color.FromArgb(0, 204, 255);
//            this.lblTC.AutoSize = true;

//            // maskedTextBoxTel
//            this.maskedTextBoxTel.Location = new Point(200, 200);
//            this.maskedTextBoxTel.Mask = "(000) 000-0000";
//            this.maskedTextBoxTel.Size = new Size(240, 27);
//            this.maskedTextBoxTel.BackColor = Color.FromArgb(60, 60, 65);
//            this.maskedTextBoxTel.ForeColor = Color.White;

//            // lblTel
//            this.lblTel.Location = new Point(30, 200);
//            this.lblTel.Text = "Telefon No:";
//            this.lblTel.ForeColor = Color.FromArgb(0, 204, 255);
//            this.lblTel.AutoSize = true;

//            // txtPOS
//            this.txtPOS.Location = new Point(200, 240);
//            this.txtPOS.Size = new Size(240, 27);
//            this.txtPOS.BackColor = Color.FromArgb(60, 60, 65);
//            this.txtPOS.ForeColor = Color.White;

//            // lblPOS
//            this.lblPOS.Location = new Point(30, 240);
//            this.lblPOS.Text = "E-Posta:";
//            this.lblPOS.ForeColor = Color.FromArgb(0, 204, 255);
//            this.lblPOS.AutoSize = true;

//            // btnKaydet
//            this.btnKaydet.Location = new Point(330, 300);
//            this.btnKaydet.Size = new Size(110, 40);
//            this.btnKaydet.Text = "Kaydet";
//            this.btnKaydet.BackColor = Color.FromArgb(0, 128, 0);
//            this.btnKaydet.FlatStyle = FlatStyle.Flat;
//            this.btnKaydet.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 0);
//            this.btnKaydet.ForeColor = Color.White;
//            this.btnKaydet.Click += btnKaydet_Click;

//            // btnGeri
//            this.btnGeri.Location = new Point(30, 300);
//            this.btnGeri.Size = new Size(110, 40);
//            this.btnGeri.Text = "Geri";
//            this.btnGeri.BackColor = Color.FromArgb(128, 0, 0);
//            this.btnGeri.FlatStyle = FlatStyle.Flat;
//            this.btnGeri.FlatAppearance.BorderColor = Color.FromArgb(255, 0, 0);
//            this.btnGeri.ForeColor = Color.White;
//            this.btnGeri.Click += Back_Click;

//            this.Controls.Add(this.txtAd);
//            this.Controls.Add(this.txtSoyad);
//            this.Controls.Add(this.txtSifre);
//            this.Controls.Add(this.txtTC);
//            this.Controls.Add(this.txtPOS);
//            this.Controls.Add(this.lblAd);
//            this.Controls.Add(this.lblSoyad);
//            this.Controls.Add(this.lblSifre);
//            this.Controls.Add(this.lblTC);
//            this.Controls.Add(this.lblTel);
//            this.Controls.Add(this.lblPOS);
//            this.Controls.Add(this.maskedTextBoxTel);
//            this.Controls.Add(this.btnKaydet);
//            this.Controls.Add(this.btnGeri);
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        #endregion
//    }
//}