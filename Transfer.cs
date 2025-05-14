using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atm_otomasyonu
{
    public partial class Transfer : Form
    {
        public int MusteriTC { get; set; } 
        public long gnTC { get; set; }

        public Transfer(int musteriTC, long gntc)
        {
            InitializeComponent();
            MusteriTC = musteriTC; 
            gnTC = gntc; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string aliciTC = txtKUL.Text.Trim(); 
            string miktar = txtMİK.Text.Trim();  

           
            if (string.IsNullOrWhiteSpace(aliciTC) || string.IsNullOrWhiteSpace(miktar))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

          
            if (aliciTC.Length != 11 || !long.TryParse(aliciTC, out _))
            {
                MessageBox.Show("Geçerli bir Müşteri TC giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

          
            if (aliciTC == gnTC.ToString())
            {
                MessageBox.Show("Kendi hesabınıza transfer yapamazsınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

          
            bool sonuc = DatabaseHelper.Transfera(gnTC, MusteriTC, aliciTC, miktar);
            if (sonuc)
            {
                MessageBox.Show("Transfer başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                AtmEkranıForm atmEkrani = new AtmEkranıForm(MusteriTC, gnTC); 
                atmEkrani.Show();
            }
            else
            {
                MessageBox.Show("Transfer başarısız! Bakiyenizi ve alıcı hesabını kontrol ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            this.Hide();
            AtmEkranıForm atmEkrani2 = new AtmEkranıForm(MusteriTC, gnTC);
            atmEkrani2.Show();
        }

        private void Transfer_Load(object sender, EventArgs e)
        {
           
        }

        private void txtKUL_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Back_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            AtmEkranıForm atmEkrani2 = new AtmEkranıForm(MusteriTC, gnTC);
            atmEkrani2.Show();
        }
    }
}
