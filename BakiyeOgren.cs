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
    // Bu form, kullanıcının güncel bakiyesini görmesini sağlar
    public partial class BakiyeOgren : Form
    {
        public int MusteriID { get; set; }    // Müşteri veritabanı ID'si
        public long gnTC { get; set; }        // Müşterinin TC kimlik numarası

        // Yapıcı metot, müşteri ID ve TC değerlerini alır
        public BakiyeOgren(int musteriID, long gntc)
        {
            InitializeComponent();
            MusteriID = musteriID;
            gnTC = gntc;
        }

        // Form yüklendiğinde otomatik olarak bakiyeyi getir
        private void BakiyeLoad_Load(object sender, EventArgs e)
        {
            GuncelBakiyeyiGoster(); // Güncel bakiyeyi ekrana yazdır
        }

        // Veritabanından bakiyeyi alıp ekranda gösteren metot
        private void GuncelBakiyeyiGoster()
        {
            decimal? bakiye = DatabaseHelper.Bakögren(MusteriID); // Müşterinin bakiyesi alınır

            if (bakiye.HasValue)
            {
                bak.Text = $"{bakiye:C2}"; // Bakiye varsa ekranda para formatında gösterilir
            }
            else
            {
                bak.Text = "Bakiye bulunamadı."; // Hata durumunda kullanıcı bilgilendirilir
            }
        }

        // Bakiye label'ına tıklanırsa (şu anda işlevsiz)
        private void bak_Click(object sender, EventArgs e)
        {
            // Opsiyonel tıklama işlemi
        }

        // Geri butonuna basıldığında, ATM ana ekranına dönülür
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide(); // Mevcut form gizlenir
            AtmEkranıForm atmEkrani2 = new AtmEkranıForm(MusteriID, gnTC);
            atmEkrani2.Show(); // Ana menü yeniden gösterilir
        }
    }
}
