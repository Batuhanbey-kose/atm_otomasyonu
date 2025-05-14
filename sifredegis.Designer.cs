using atm_otomasyonu.Properties;

namespace atm_otomasyonu
{
    partial class sifredegis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sifredegis));
            button1 = new Button();
            txtES = new TextBox();
            txtYE = new TextBox();
            btnGeri = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.MediumSlateBlue;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(476, 296);
            button1.Name = "button1";
            button1.Size = new Size(119, 50);
            button1.TabIndex = 0;
            button1.Text = "Değiştir";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // txtES
            // 
            txtES.BackColor = Color.FromArgb(45, 45, 45);
            txtES.Font = new Font("Segoe UI", 12F);
            txtES.ForeColor = Color.White;
            txtES.Location = new Point(476, 72);
            txtES.Multiline = true;
            txtES.Name = "txtES";
            txtES.Size = new Size(100, 37);
            txtES.TabIndex = 1;
            // 
            // txtYE
            // 
            txtYE.BackColor = Color.FromArgb(45, 45, 45);
            txtYE.Font = new Font("Segoe UI", 12F);
            txtYE.ForeColor = Color.White;
            txtYE.Location = new Point(476, 168);
            txtYE.Multiline = true;
            txtYE.Name = "txtYE";
            txtYE.Size = new Size(100, 37);
            txtYE.TabIndex = 2;
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
            btnGeri.Location = new Point(234, 296);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(140, 50);
            btnGeri.TabIndex = 3;
            btnGeri.Text = "   Geri";
            btnGeri.TextAlign = ContentAlignment.MiddleRight;
            btnGeri.UseVisualStyleBackColor = false;
            btnGeri.Click += Back_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 204, 255);
            label1.Location = new Point(234, 73);
            label1.Name = "label1";
            label1.Size = new Size(81, 19);
            label1.TabIndex = 4;
            label1.Text = "Eski Şifre : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(0, 204, 255);
            label2.Location = new Point(234, 186);
            label2.Name = "label2";
            label2.Size = new Size(84, 19);
            label2.TabIndex = 5;
            label2.Text = "Yeni Şifre : ";
            // 
            // sifredegis
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(864, 513);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGeri);
            Controls.Add(txtYE);
            Controls.Add(txtES);
            Controls.Add(button1);
            Name = "sifredegis";
            Text = "sifredegis";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtES;
        private TextBox txtYE;
        private Button btnGeri;
        private Label label1;
        private Label label2;
    }
}