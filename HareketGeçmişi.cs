using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace atm_otomasyonu
{
    public partial class HareketGeçmişi : Form
    {
        public int MusteriID { get; set; }
        public long gnTC { get; set; } 

       
        private DataTable tumVeriler;

        public HareketGeçmişi(int musteriID, long gnTc)
        {
            InitializeComponent();
            MusteriID = musteriID;
            gnTC = gnTc;
        }

        private void HareketGeçmişi_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Add("Hepsi");
            comboBox1.Items.Add("Hesap Hareketleri");
            comboBox1.Items.Add("Transfer İşlemleri");
            comboBox1.SelectedIndex = 0; 

            tumVeriler = DatabaseHelper.Hargec(gnTC, comboBox1.SelectedItem.ToString());
            dgvhar.DataSource = tumVeriler;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AtmEkranıForm musterilog = new AtmEkranıForm(MusteriID, gnTC);
            musterilog.Show();
        }

        private void dgvhar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string secim = comboBox1.SelectedItem.ToString();
            dgvhar.DataSource = DatabaseHelper.Hargec(gnTC, secim);
        }
    }
}
