namespace atm_otomasyonu
{
    partial class ParaCekme
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParaCekme));
            label1 = new Label();
            txtTutar = new TextBox();
            btncek = new Button();
            btnGeri = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Green;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(159, 157);
            label1.Name = "label1";
            label1.Size = new Size(179, 55);
            label1.TabIndex = 0;
            label1.Text = "Çekmek istediğiniz \n tutarı giriniz : ";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTutar
            // 
            txtTutar.BackColor = Color.FromArgb(45, 45, 45);
            txtTutar.Font = new Font("Segoe UI", 15F);
            txtTutar.ForeColor = Color.White;
            txtTutar.Location = new Point(458, 157);
            txtTutar.Multiline = true;
            txtTutar.Name = "txtTutar";
            txtTutar.Size = new Size(151, 55);
            txtTutar.TabIndex = 1;
            // 
            // btncek
            // 
            btncek.BackColor = Color.DarkOrange;
            btncek.FlatStyle = FlatStyle.Flat;
            btncek.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btncek.ForeColor = Color.White;
            btncek.Image = (Image)resources.GetObject("btncek.Image");
            btncek.ImageAlign = ContentAlignment.MiddleLeft;
            btncek.Location = new Point(473, 272);
            btncek.Name = "btncek";
            btncek.Size = new Size(136, 61);
            btncek.TabIndex = 2;
            btncek.Text = "Para Çek";
            btncek.TextAlign = ContentAlignment.MiddleRight;
            btncek.UseVisualStyleBackColor = false;
            btncek.Click += btncek_Click;
            // 
            // btnGeri
            // 
            btnGeri.BackColor = Color.Maroon;
            btnGeri.FlatAppearance.BorderSize = 0;
            btnGeri.FlatStyle = FlatStyle.Flat;
            btnGeri.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGeri.ForeColor = Color.White;
            btnGeri.Image = (Image)resources.GetObject("btnGeri.Image");
            btnGeri.ImageAlign = ContentAlignment.MiddleLeft;
            btnGeri.Location = new Point(159, 272);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(136, 61);
            btnGeri.TabIndex = 3;
            btnGeri.Text = "   Geri";
            btnGeri.TextAlign = ContentAlignment.MiddleRight;
            btnGeri.UseVisualStyleBackColor = false;
            btnGeri.Click += Back_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Footlight MT Light", 50.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.ImageAlign = ContentAlignment.MiddleRight;
            label2.Location = new Point(122, 9);
            label2.Name = "label2";
            label2.Size = new Size(522, 102);
            label2.TabIndex = 12;
            label2.Text = "BBK BANK";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ParaCekme
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(864, 513);
            Controls.Add(label2);
            Controls.Add(btnGeri);
            Controls.Add(btncek);
            Controls.Add(txtTutar);
            Controls.Add(label1);
            Name = "ParaCekme";
            Text = "para cek";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTutar;
        private Button btncek;
        private Button btnGeri;
        private Label label2;
    }
}