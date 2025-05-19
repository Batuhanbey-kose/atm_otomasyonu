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
        // Giriş yapan müşterinin ID'si ve TC'si
        public int MusteriID { get; set; }
        public long gnTC { get; set; }

        // Form başlatılırken müşteri bilgileri alınır
        public ParaCekme(int musteriID, long gntc)
        {
            InitializeComponent();
            MusteriID = musteriID;
            gnTC = gntc;
        }

        // Para çekme butonuna tıklanınca çalışan olay
        private void btncek_Click(object sender, EventArgs e)
        {
            string miktar = txtTutar.Text;
            miktar = miktar.Trim(); // Gereksiz boşluklar temizlenir

            // Tutar boş bırakılmışsa uyarı ver
            if (string.IsNullOrWhiteSpace(miktar))
            {
                MessageBox.Show("Boş alan bırakma", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                // Veritabanından para çekme işlemi gerçekleştirilir
                bool sonuc = DatabaseHelper.ParaCek(MusteriID, miktar);

                if (sonuc)
                {
                    // Başarılı işlem sonrası ana ekrana dönülür
                    MessageBox.Show("Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    AtmEkranıForm atmEkrani = new AtmEkranıForm(MusteriID, gnTC);
                    atmEkrani.Show();
                }
                else
                {
                    // Yetersiz bakiye varsa uyarı verilir
                    MessageBox.Show("Başarısız Bakiyeniz Yetersiz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Geri butonuna basıldığında ana ekrana dönülür
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AtmEkranıForm atmEkrani2 = new AtmEkranıForm(MusteriID, gnTC);
            atmEkrani2.Show();
        }
    }
}
