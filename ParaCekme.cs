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
    public partial class ParaCekme : Form
    {
        public int MusteriID { get; set; }
        public long gnTC { get; set; }
        
        public ParaCekme(int musteriID,long gntc)
        {
            InitializeComponent();
            MusteriID = musteriID;
            gnTC = gntc;
        }
        private void btncek_Click(object sender, EventArgs e)
        {
            string miktar = txtTutar.Text;

            miktar = miktar.Trim();

            if (string.IsNullOrWhiteSpace(miktar))
            {
                MessageBox.Show("Boş alan bırakma", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                bool sonuc = DatabaseHelper.ParaCek(MusteriID, miktar);
                if (sonuc)
                {
                    MessageBox.Show("Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    AtmEkranıForm atmEkrani = new AtmEkranıForm(MusteriID,gnTC);
                    atmEkrani.Show();
                }
                else
                {
                    MessageBox.Show("Başarısız Bakiyeniz Yetersiz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AtmEkranıForm atmEkrani2 = new AtmEkranıForm(MusteriID, gnTC);
            atmEkrani2.Show();
        }
    }
}
