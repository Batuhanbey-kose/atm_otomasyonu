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
        // Müşteri bilgileri: ID ve TC
        public int MusteriID { get; set; }
        public long gnTC { get; set; }

        // Form oluşturulurken müşteri bilgileri alınır
        public ParaYatirma(int musteriID, long gntc)
        {
            InitializeComponent();
            MusteriID = musteriID;
            gnTC = gntc;
        }

        // Para yatırma butonuna basıldığında çalışır
        private void btnYatir_Click(object sender, EventArgs e)
        {
            string miktar = txtTutar.Text;
            miktar = miktar.Trim(); // Girilen miktardaki boşluklar temizlenir

            // Eğer miktar girilmemişse kullanıcı uyarılır
            if (string.IsNullOrWhiteSpace(miktar))
            {
                MessageBox.Show("Boş alan bırakmayın.", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                // Veritabanına para yatırma isteği gönderilir
                bool sonuc = DatabaseHelper.ParaYatir(MusteriID, miktar);

                if (sonuc)
                {
                    // İşlem başarılıysa kullanıcı bilgilendirilir ve ana ekrana dönülür
                    MessageBox.Show("Para Yatırma İşlemi Başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    AtmEkranıForm atmEkrani = new AtmEkranıForm(MusteriID, gnTC);
                    atmEkrani.Show();
                }
                else
                {
                    // İşlem başarısızsa hata mesajı gösterilir
                    MessageBox.Show("Para Yatırma İşlemi Başarısız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Geri tuşuna basıldığında ana ekrana dönülür
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AtmEkranıForm atmEkrani2 = new AtmEkranıForm(MusteriID, gnTC);
            atmEkrani2.Show();
        }

        // Form yüklendiğinde yapılacak işlemler (şu an boş)
        private void ParaYatirma_Load(object sender, EventArgs e)
        {
        }

        // Tutar kutusu değiştiğinde yapılacak işlemler (şu an boş)
        private void txtTutar_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
