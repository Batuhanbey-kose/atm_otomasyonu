namespace atm_otomasyonu
{
    partial class Transfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transfer));
            label1 = new Label();
            label2 = new Label();
            txtKUL = new TextBox();
            txtMİK = new TextBox();
            button1 = new Button();
            btnGeri = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = Color.Navy;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.ImageAlign = ContentAlignment.MiddleLeft;
            label1.Location = new Point(206, 113);
            label1.Name = "label1";
            label1.Size = new Size(180, 59);
            label1.TabIndex = 0;
            label1.Text = "Alıcı TC :";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.BackColor = Color.Green;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.White;
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(206, 238);
            label2.Name = "label2";
            label2.Size = new Size(180, 49);
            label2.TabIndex = 1;
            label2.Text = "Gönderilecek \n Tutar :";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtKUL
            // 
            txtKUL.BackColor = Color.FromArgb(40, 40, 40);
            txtKUL.Font = new Font("Segoe UI", 14F);
            txtKUL.ForeColor = Color.White;
            txtKUL.Location = new Point(530, 124);
            txtKUL.Multiline = true;
            txtKUL.Name = "txtKUL";
            txtKUL.Size = new Size(133, 48);
            txtKUL.TabIndex = 2;
            txtKUL.TextChanged += txtKUL_TextChanged;
            // 
            // txtMİK
            // 
            txtMİK.BackColor = Color.FromArgb(40, 40, 40);
            txtMİK.Font = new Font("Segoe UI", 14F);
            txtMİK.ForeColor = Color.White;
            txtMİK.Location = new Point(530, 244);
            txtMİK.Multiline = true;
            txtMİK.Name = "txtMİK";
            txtMİK.Size = new Size(133, 48);
            txtMİK.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(139, 129, 76);
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(375, 336);
            button1.Name = "button1";
            button1.Size = new Size(128, 56);
            button1.TabIndex = 4;
            button1.Text = "GÖNDER";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
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
            btnGeri.Location = new Point(375, 420);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(128, 54);
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
            label3.Location = new Point(132, 8);
            label3.Name = "label3";
            label3.Size = new Size(522, 102);
            label3.TabIndex = 12;
            label3.Text = "BBK BANK";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Transfer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(864, 513);
            Controls.Add(label3);
            Controls.Add(btnGeri);
            Controls.Add(button1);
            Controls.Add(txtMİK);
            Controls.Add(txtKUL);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Transfer";
            Text = "W";
            Load += Transfer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtKUL;
        private TextBox txtMİK;
        private Button button1;
        private Button btnGeri;
        private Label label3;
    }
}