

namespace atm_otomasyonu
{
    partial class AtmEkranıForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button btnParaCek,btnParaYatir,btnBakiye,btnTransfer;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AtmEkranıForm));
            btnParaCek = new Button();
            btnParaYatir = new Button();
            btnBakiye = new Button();
            btnTransfer = new Button();
            btnhar = new Button();
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnParaCek
            // 
            btnParaCek.BackColor = Color.Turquoise;
            btnParaCek.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnParaCek.Image = (Image)resources.GetObject("btnParaCek.Image");
            btnParaCek.ImageAlign = ContentAlignment.MiddleLeft;
            btnParaCek.Location = new Point(127, 222);
            btnParaCek.Name = "btnParaCek";
            btnParaCek.Size = new Size(200, 82);
            btnParaCek.TabIndex = 6;
            btnParaCek.Text = "Para Çekme";
            btnParaCek.TextAlign = ContentAlignment.MiddleRight;
            btnParaCek.UseVisualStyleBackColor = false;
            btnParaCek.Click += btnParaCek_Click;
            // 
            // btnParaYatir
            // 
            btnParaYatir.BackColor = Color.Pink;
            btnParaYatir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnParaYatir.Image = (Image)resources.GetObject("btnParaYatir.Image");
            btnParaYatir.ImageAlign = ContentAlignment.MiddleLeft;
            btnParaYatir.Location = new Point(477, 222);
            btnParaYatir.Name = "btnParaYatir";
            btnParaYatir.Size = new Size(200, 82);
            btnParaYatir.TabIndex = 0;
            btnParaYatir.Text = "Para Yatırma";
            btnParaYatir.TextAlign = ContentAlignment.MiddleRight;
            btnParaYatir.UseVisualStyleBackColor = false;
            btnParaYatir.Click += btnParaYatir_Click;
            // 
            // btnBakiye
            // 
            btnBakiye.BackColor = Color.Gainsboro;
            btnBakiye.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnBakiye.Image = (Image)resources.GetObject("btnBakiye.Image");
            btnBakiye.ImageAlign = ContentAlignment.MiddleLeft;
            btnBakiye.Location = new Point(477, 99);
            btnBakiye.Name = "btnBakiye";
            btnBakiye.Size = new Size(200, 83);
            btnBakiye.TabIndex = 0;
            btnBakiye.Text = "Bakiye Öğrenme";
            btnBakiye.TextAlign = ContentAlignment.MiddleRight;
            btnBakiye.UseVisualStyleBackColor = false;
            btnBakiye.Click += btnBakiye_Click;
            // 
            // btnTransfer
            // 
            btnTransfer.BackColor = Color.LightBlue;
            btnTransfer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnTransfer.Image = (Image)resources.GetObject("btnTransfer.Image");
            btnTransfer.ImageAlign = ContentAlignment.MiddleLeft;
            btnTransfer.Location = new Point(127, 99);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(200, 83);
            btnTransfer.TabIndex = 0;
            btnTransfer.Text = "Transfer Etme";
            btnTransfer.TextAlign = ContentAlignment.MiddleRight;
            btnTransfer.UseVisualStyleBackColor = false;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnhar
            // 
            btnhar.BackColor = Color.OliveDrab;
            btnhar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnhar.Image = (Image)resources.GetObject("btnhar.Image");
            btnhar.ImageAlign = ContentAlignment.MiddleLeft;
            btnhar.Location = new Point(477, 350);
            btnhar.Name = "btnhar";
            btnhar.Size = new Size(200, 83);
            btnhar.TabIndex = 0;
            btnhar.Text = "Hesap Hareketleri";
            btnhar.TextAlign = ContentAlignment.MiddleRight;
            btnhar.UseVisualStyleBackColor = false;
            btnhar.Click += btnhar_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.MediumSeaGreen;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(127, 350);
            button1.Name = "button1";
            button1.Size = new Size(200, 83);
            button1.TabIndex = 7;
            button1.Text = "Şifre Değiştirme";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Footlight MT Light", 50.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.ImageAlign = ContentAlignment.MiddleRight;
            label1.Location = new Point(127, -6);
            label1.Name = "label1";
            label1.Size = new Size(522, 102);
            label1.TabIndex = 11;
            label1.Text = "BBK BANK";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AtmEkranıForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(864, 513);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(btnhar);
            Controls.Add(btnTransfer);
            Controls.Add(btnBakiye);
            Controls.Add(btnParaYatir);
            Controls.Add(btnParaCek);
            Name = "AtmEkranıForm";
            Text = "AtmEkranı";
            Load += AtmEkranıForm_Load;
            ResumeLayout(false);
        }

        private Button btnhar;
        private Button button1;
        private Label label1;
    }
    #endregion
}
