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
        // Kullanıcının ID'si ve TC numarası
        public int MusteriTC { get; set; }
        public long gnTC { get; set; }

        // Formun yapıcı metodu - müşteri bilgilerini alır
        public Transfer(int musteriTC, long gntc)
        {
            InitializeComponent();
            MusteriTC = musteriTC;
            gnTC = gntc;
        }

        // "Gönder" butonuna tıklanıldığında transfer işlemi başlatılır
        private void button1_Click(object sender, EventArgs e)
        {
            // Alıcı TC ve gönderilecek miktar alınır
            string aliciTC = txtKUL.Text.Trim();
            string miktar = txtMİK.Text.Trim();

            // Alanlardan biri boşsa kullanıcı uyarılır
            if (string.IsNullOrWhiteSpace(aliciTC) || string.IsNullOrWhiteSpace(miktar))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Alıcı TC geçerli bir 11 haneli rakam değilse uyarı verilir
            if (aliciTC.Length != 11 || !long.TryParse(aliciTC, out _))
            {
                MessageBox.Show("Geçerli bir Müşteri TC giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Kendi hesabına para gönderilmeye çalışılırsa engellenir
            if (aliciTC == gnTC.ToString())
            {
                MessageBox.Show("Kendi hesabınıza transfer yapamazsınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Veritabanı işlemi çağrılır: transfer yapılır
            bool sonuc = DatabaseHelper.Transfera(gnTC, MusteriTC, aliciTC, miktar);
            if (sonuc)
            {
                // Başarılıysa kullanıcı bilgilendirilir
                MessageBox.Show("Transfer başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Hatalıysa sebebi belirtilir
                MessageBox.Show("Transfer başarısız! Bakiyenizi ve alıcı hesabını kontrol ediniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Her durumda ana ekrana dönülür
            this.Hide();
            AtmEkranıForm atmEkrani2 = new AtmEkranıForm(MusteriTC, gnTC);
            atmEkrani2.Show();
        }

        // Form yüklendiğinde çalışır
        private void Transfer_Load(object sender, EventArgs e)
        {
            // Şimdilik boş
        }

        // Alıcı TC değiştiğinde tetiklenir (şu anda kullanılmıyor)
        private void txtKUL_TextChanged(object sender, EventArgs e)
        {

        }

        // Geri butonuna basıldığında ana menüye dönülür
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AtmEkranıForm atmEkrani2 = new AtmEkranıForm(MusteriTC, gnTC);
            atmEkrani2.Show();
        }
    }
}
