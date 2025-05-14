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
    public partial class ParaYatirma : Form
    {
        public int MusteriID { get; set; }
        public long gnTC { get; set; }
        
        public ParaYatirma(int musteriID,long gntc)
        {
            InitializeComponent();
            MusteriID = musteriID;
            gnTC = gntc;

        }

        private void btnYatir_Click(object sender, EventArgs e)
        {
            string miktar = txtTutar.Text;

            miktar = miktar.Trim();

            if (string.IsNullOrWhiteSpace(miktar))
            {
                MessageBox.Show("Boş alan bırakmayın.", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {

                bool sonuc = DatabaseHelper.ParaYatir(MusteriID, miktar);
                if (sonuc)
                {
                    MessageBox.Show("Para Yatırma İşlemi Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    AtmEkranıForm atmEkrani = new AtmEkranıForm(MusteriID,gnTC);
                    atmEkrani.Show();
                }
                else
                {
                    MessageBox.Show("Para Yatırma İşlemi Başarısız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AtmEkranıForm atmEkrani2 = new AtmEkranıForm(MusteriID,gnTC);
            atmEkrani2.Show();
        }
        private void ParaYatirma_Load(object sender, EventArgs e)
        {

        }

        private void txtTutar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
