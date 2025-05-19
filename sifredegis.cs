using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atm_otomasyonu
{
    public partial class sifredegis : Form
    {
        // Kullanıcının ID ve TC bilgileri tutulur
        public int MusteriID { get; set; }
        public long gnTC { get; set; }

        // Form yapıcı metodu: müşteri bilgileri parametre olarak alınır
        public sifredegis(int musteriID, long gntc)
        {
            InitializeComponent();
            MusteriID = musteriID;
            gnTC = gntc;
        }

        // Şifre değiştirme butonuna basıldığında çalışır
        private void button1_Click(object sender, EventArgs e)
        {
            // Veritabanından mevcut (eski) şifre alınır
            string essif = DatabaseHelper.Eskisifre(MusteriID);

            // Kullanıcının girdiği eski ve yeni şifreler alınır
            string essi = txtES.Text;
            string yesi = txtYE.Text;

            // Yeni şifre 4 haneli değilse veya rakamlardan oluşmuyorsa uyarılır
            if (yesi.Length != 4 || !yesi.All(char.IsDigit))
            {
                MessageBox.Show("Lütfen 4 haneli ve sadece rakamlardan oluşan bir şifre seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // Girilen eski şifre veritabanındakiyle uyuşmuyorsa uyarılır
            else if (essi != essif)
            {
                MessageBox.Show("Lütfen eski şifrenizi doğru giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // Yeni şifre, eski şifreyle aynı olamaz
            else if (essif == yesi)
            {
                MessageBox.Show("Yeni şifreniz eski şifrenizle aynı olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // Alanlardan biri boş bırakılmışsa uyarılır
            else if (string.IsNullOrWhiteSpace(essi) || string.IsNullOrWhiteSpace(yesi))
            {
                MessageBox.Show("Boş alan bırakmayınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                // Tüm kontroller geçildiyse şifre veritabanında güncellenir
                bool güncelleme = DatabaseHelper.Sifrede(MusteriID, yesi);

                if (güncelleme)
                {
                    MessageBox.Show("Şifre değiştirme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    AtmEkranıForm atmEkrani = new AtmEkranıForm(MusteriID, gnTC);
                    atmEkrani.Show();
                }
                else
                {
                    MessageBox.Show("Şifre değiştirme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Geri butonuna basıldığında ana ATM ekranına dönülür
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AtmEkranıForm atmEkrani2 = new AtmEkranıForm(MusteriID, gnTC);
            atmEkrani2.Show();
        }
    }
}
