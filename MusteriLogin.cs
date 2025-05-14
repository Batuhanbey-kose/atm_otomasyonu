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
    public partial class MusteriLogin : Form
    {
        public MusteriLogin()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string ad = txtKullaniciAd.Text;
            string sifre = txtSifre.Text;

            var (musteriId, gnTC) = DatabaseHelper.KullaniciGiris(ad, sifre);

            if (musteriId != -1)
            {
                MessageBox.Show("Giriş Başarılı","Bilgi", MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Hide();
                AtmEkranıForm atmEkrani = new AtmEkranıForm(musteriId, gnTC);
                atmEkrani.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya şifre Hatalı","Hata",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void btnNewKayit_Click(object sender, EventArgs e)
        {
            this.Hide();
            MusteriKayitForm musteriKayit = new MusteriKayitForm();
            musteriKayit.Show();
        }
    }
}
