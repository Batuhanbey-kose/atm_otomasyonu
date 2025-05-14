namespace atm_otomasyonu
{
    partial class BakiyeOgren
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BakiyeOgren));
            label1 = new Label();
            bak = new Label();
            label2 = new Label();
            btnGeri = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(0, 122, 204);
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(164, 185);
            label1.Name = "label1";
            label1.Size = new Size(200, 50);
            label1.TabIndex = 0;
            label1.Text = "  Güncel bakiyeniz:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // bak
            // 
            bak.BackColor = Color.Transparent;
            bak.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            bak.ForeColor = Color.White;
            bak.Location = new Point(462, 184);
            bak.Name = "bak";
            bak.Size = new Size(150, 50);
            bak.TabIndex = 1;
            bak.Text = "...";
            bak.TextAlign = ContentAlignment.MiddleCenter;
            bak.Click += bak_Click;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Italic);
            label2.ForeColor = Color.White;
            label2.Location = new Point(225, 117);
            label2.Name = "label2";
            label2.Size = new Size(422, 53);
            label2.TabIndex = 2;
            label2.Text = "Bakiyeniz aşağıda görüntülenmektedir.";
            label2.TextAlign = ContentAlignment.MiddleCenter;
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
            btnGeri.Location = new Point(354, 303);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(147, 56);
            btnGeri.TabIndex = 3;
            btnGeri.Text = "   Geri";
            btnGeri.TextAlign = ContentAlignment.MiddleRight;
            btnGeri.UseVisualStyleBackColor = false;
            btnGeri.Click += Back_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Footlight MT Light", 50.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.ImageAlign = ContentAlignment.MiddleRight;
            label3.Location = new Point(125, 9);
            label3.Name = "label3";
            label3.Size = new Size(522, 102);
            label3.TabIndex = 12;
            label3.Text = "BBK BANK";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BakiyeOgren
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(864, 513);
            Controls.Add(label3);
            Controls.Add(btnGeri);
            Controls.Add(label2);
            Controls.Add(bak);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "BakiyeOgren";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bakiye Öğren";
            Load += BakiyeLoad_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label bak;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGeri;
        private Label label3;
    }
}
