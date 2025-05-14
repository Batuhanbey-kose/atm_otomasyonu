using atm_otomasyonu.Properties;

namespace atm_otomasyonu
{
    partial class HareketGeçmişi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HareketGeçmişi));
            dgvhar = new DataGridView();
            label1 = new Label();
            btnger = new Button();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvhar).BeginInit();
            SuspendLayout();
            // 
            // dgvhar
            // 
            dgvhar.AllowUserToAddRows = false;
            dgvhar.AllowUserToDeleteRows = false;
            dgvhar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvhar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvhar.Location = new Point(22, 127);
            dgvhar.Name = "dgvhar";
            dgvhar.ReadOnly = true;
            dgvhar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvhar.Size = new Size(776, 222);
            dgvhar.TabIndex = 0;
            dgvhar.CellContentClick += dgvhar_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(167, 94);
            label1.Name = "label1";
            label1.Size = new Size(516, 30);
            label1.TabIndex = 1;
            label1.Text = "HAREKET GEÇMİŞİ TABLOSU AŞAĞIDAKİ GİBİDİR";
            // 
            // btnger
            // 
            btnger.BackColor = Color.FromArgb(128, 0, 0);
            btnger.FlatAppearance.BorderColor = Color.Maroon;
            btnger.FlatAppearance.BorderSize = 0;
            btnger.FlatStyle = FlatStyle.Popup;
            btnger.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnger.ForeColor = Color.White;
            btnger.Image = (Image)resources.GetObject("btnger.Image");
            btnger.ImageAlign = ContentAlignment.MiddleLeft;
            btnger.Location = new Point(22, 370);
            btnger.Name = "btnger";
            btnger.Size = new Size(148, 56);
            btnger.TabIndex = 3;
            btnger.Text = "   Geri";
            btnger.TextAlign = ContentAlignment.MiddleRight;
            btnger.UseVisualStyleBackColor = true;
            btnger.Click += Back_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(532, 388);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(266, 23);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.ForeColor = Color.White;
            label2.Location = new Point(507, 352);
            label2.Name = "label2";
            label2.Size = new Size(347, 17);
            label2.TabIndex = 5;
            label2.Text = "Aşağıdaki listeleme ekranından görmek istediğinizi seçebilirsiniz.";
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Footlight MT Light", 50.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Image = (Image)resources.GetObject("label3.Image");
            label3.ImageAlign = ContentAlignment.MiddleRight;
            label3.Location = new Point(134, -7);
            label3.Name = "label3";
            label3.Size = new Size(522, 102);
            label3.TabIndex = 12;
            label3.Text = "BBK BANK";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // HareketGeçmişi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(45, 45, 48);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(864, 513);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(btnger);
            Controls.Add(label1);
            Controls.Add(dgvhar);
            Name = "HareketGeçmişi";
            Text = "HareketGeçmişi";
            Load += HareketGeçmişi_Load;
            ((System.ComponentModel.ISupportInitialize)dgvhar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvhar;
        private Label label1;
        private Button btnger;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
    }
}