﻿using System;
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
        // Giriş ekranı formunun yapıcı metodu
        public MusteriLogin()
        {
            InitializeComponent();
        }

        // Giriş butonuna tıklanınca çalışır
        private void btnGiris_Click(object sender, EventArgs e)
        {
            // Kullanıcıdan alınan ad ve şifre okunur
            string ad = txtKullaniciAd.Text;
            string sifre = txtSifre.Text;

            // Veritabanından kullanıcı bilgileri sorgulanır
            var (musteriId, gnTC) = DatabaseHelper.KullaniciGiris(ad, sifre);

            // Eğer kullanıcı doğrulandıysa
            if (musteriId != -1)
            {
                MessageBox.Show("Giriş Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Giriş başarılıysa ATM ana ekranı açılır
                this.Hide();
                AtmEkranıForm atmEkrani = new AtmEkranıForm(musteriId, gnTC);
                atmEkrani.Show();
            }
            else
            {
                // Giriş başarısızsa uyarı verilir
                MessageBox.Show("Kullanıcı Adı veya şifre Hatalı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // Yeni kayıt butonuna tıklanırsa, kayıt formuna yönlendirilir
        private void btnNewKayit_Click(object sender, EventArgs e)
        {
            this.Hide();
            MusteriKayitForm musteriKayit = new MusteriKayitForm();
            musteriKayit.Show();
        }
    }
}
