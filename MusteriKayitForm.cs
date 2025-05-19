namespace atm_otomasyonu
{
    public partial class MusteriKayitForm : Form
    {
        // M��teri verilerini y�netmek i�in kullan�lacak Manager s�n�f�
        private readonly MusteriManager musteriManager = new MusteriManager();

        public MusteriKayitForm()
        {
            InitializeComponent();
        }

        // Form y�klendi�inde �al��acak olay (�imdilik bo�)
        private void MusteriKayitForm_Load(object sender, EventArgs e) { }

        // Ad, soyad ve �ifre alanlar�nda de�i�iklik oldu�unda tetiklenir (�u an kullan�lm�yor)
        private void txtAd_TextChanged(object sender, EventArgs e) { }
        private void txtSoyad_TextChanged(object sender, EventArgs e) { }
        private void txtSifre_TextChanged(object sender, EventArgs e) { }

        // Kay�t butonuna bas�ld���nda �al���r
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Form alanlar�ndaki veriler al�n�r
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string sifre = txtSifre.Text;
            string tc = txtTC.Text;
            string tel = maskedTextBoxTel.Text;
            string posta = txtPOS.Text;

            // Gereksiz bo�luklar temizlenir
            ad = ad.Trim();
            soyad = soyad.Trim();
            sifre = sifre.Trim();
            tc = tc.Trim();
            tel = tel.Trim();
            posta = posta.Trim();

            // Alanlardan biri bo�sa kullan�c� uyar�l�r
            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad) ||
                string.IsNullOrWhiteSpace(sifre) || string.IsNullOrWhiteSpace(tc) ||
                string.IsNullOrWhiteSpace(tel) || string.IsNullOrWhiteSpace(posta))
            {
                MessageBox.Show("Bo� alan b�rakma", "Hatal�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                // Yeni m��teri nesnesi olu�turuluyor
                Musteri yenimusteri = new()
                {
                    Ad = ad,
                    Soyad = soyad,
                    Sifre = sifre,
                    TC = tc,
                    Tel = tel,
                    mail = posta
                };

                // Manager �zerinden veri ekleme deneniyor
                bool sonuc = musteriManager.MusteriEkle(yenimusteri);

                if (sonuc)
                {
                    // Kay�t ba�ar�l�ysa kullan�c� bilgilendirilir ve giri� ekran�na y�nlendirilir
                    MessageBox.Show("Kay�t Olma ��lemi Ba�ar�l�", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    MusteriLogin musteriLoginForm = new MusteriLogin();
                    musteriLoginForm.Show();
                }
                else
                {
                    // Hata durumunda kullan�c� uyar�l�r
                    MessageBox.Show("Kay�t Olma ��lemi Ba�ar�s�z", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        // Geri butonuna t�klan�nca giri� formuna d�n�l�r
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            MusteriLogin musterilog = new MusteriLogin();
            musterilog.Show();
        }

        // TC alan�na sadece rakam girilmesini sa�lar
        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece rakamlar ve geri silme tu�u kabul edilir
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
