namespace atm_otomasyonu
{
    public partial class MusteriKayitForm : Form
    {
        // Müþteri verilerini yönetmek için kullanýlacak Manager sýnýfý
        private readonly MusteriManager musteriManager = new MusteriManager();

        public MusteriKayitForm()
        {
            InitializeComponent();
        }

        // Form yüklendiðinde çalýþacak olay (þimdilik boþ)
        private void MusteriKayitForm_Load(object sender, EventArgs e) { }

        // Ad, soyad ve þifre alanlarýnda deðiþiklik olduðunda tetiklenir (þu an kullanýlmýyor)
        private void txtAd_TextChanged(object sender, EventArgs e) { }
        private void txtSoyad_TextChanged(object sender, EventArgs e) { }
        private void txtSifre_TextChanged(object sender, EventArgs e) { }

        // Kayýt butonuna basýldýðýnda çalýþýr
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Form alanlarýndaki veriler alýnýr
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string sifre = txtSifre.Text;
            string tc = txtTC.Text;
            string tel = maskedTextBoxTel.Text;
            string posta = txtPOS.Text;

            // Gereksiz boþluklar temizlenir
            ad = ad.Trim();
            soyad = soyad.Trim();
            sifre = sifre.Trim();
            tc = tc.Trim();
            tel = tel.Trim();
            posta = posta.Trim();

            // Alanlardan biri boþsa kullanýcý uyarýlýr
            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad) ||
                string.IsNullOrWhiteSpace(sifre) || string.IsNullOrWhiteSpace(tc) ||
                string.IsNullOrWhiteSpace(tel) || string.IsNullOrWhiteSpace(posta))
            {
                MessageBox.Show("Boþ alan býrakma", "Hatalý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                // Yeni müþteri nesnesi oluþturuluyor
                Musteri yenimusteri = new()
                {
                    Ad = ad,
                    Soyad = soyad,
                    Sifre = sifre,
                    TC = tc,
                    Tel = tel,
                    mail = posta
                };

                // Manager üzerinden veri ekleme deneniyor
                bool sonuc = musteriManager.MusteriEkle(yenimusteri);

                if (sonuc)
                {
                    // Kayýt baþarýlýysa kullanýcý bilgilendirilir ve giriþ ekranýna yönlendirilir
                    MessageBox.Show("Kayýt Olma Ýþlemi Baþarýlý", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    MusteriLogin musteriLoginForm = new MusteriLogin();
                    musteriLoginForm.Show();
                }
                else
                {
                    // Hata durumunda kullanýcý uyarýlýr
                    MessageBox.Show("Kayýt Olma Ýþlemi Baþarýsýz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        // Geri butonuna týklanýnca giriþ formuna dönülür
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            MusteriLogin musterilog = new MusteriLogin();
            musterilog.Show();
        }

        // TC alanýna sadece rakam girilmesini saðlar
        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakamlar ve geri silme tuþu kabul edilir
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
