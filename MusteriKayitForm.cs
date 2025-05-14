namespace atm_otomasyonu
{
    public partial class MusteriKayitForm : Form
    {

        private readonly MusteriManager musteriManager = new MusteriManager();
        public MusteriKayitForm()
        {
            InitializeComponent();
        }

        private void MusteriKayitForm_Load(object sender, EventArgs e)
        {

        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtSifre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string sifre = txtSifre.Text;
            string tc = txtTC.Text;
            string tel = maskedTextBoxTel.Text;
            string posta = txtPOS.Text;


           
            ad = ad.Trim();
            soyad = soyad.Trim();
            sifre = sifre.Trim();
            tc = tc.Trim();
            tel = tel.Trim();
            posta = posta.Trim();

  
            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad) || string.IsNullOrWhiteSpace(sifre) || 
                string.IsNullOrWhiteSpace(tc) || string.IsNullOrWhiteSpace(tel) || string.IsNullOrWhiteSpace(posta))
            {
                MessageBox.Show("Boþ alan býrakma", "Hatalý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
               
                Musteri yenimusteri = new()
                {
                    Ad = ad,
                    Soyad = soyad,
                    Sifre = sifre,
                    TC =tc,
                    Tel = tel,
                    mail = posta
                };

                bool sonuc = musteriManager.MusteriEkle(yenimusteri);
                if (sonuc)
                {
                    MessageBox.Show("Baþarýlý", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    MusteriLogin musteriLoginForm = new MusteriLogin();
                    musteriLoginForm.Show();
                }
                else
                {
                    MessageBox.Show("Baþarýsýz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            MusteriLogin musterilog = new MusteriLogin();
            musterilog.Show();
        }
        private void txtTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

    }

}

