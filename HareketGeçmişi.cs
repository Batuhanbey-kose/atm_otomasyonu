using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace atm_otomasyonu
{
    // Bu form, kullanıcının işlem geçmişini görüntülemesini sağlar
    public partial class HareketGeçmişi : Form
    {
        public int MusteriID { get; set; }  // Müşteri veritabanı ID'si
        public long gnTC { get; set; }      // Müşterinin TC kimlik numarası

        private DataTable tumVeriler;       // Tüm işlemleri tutan geçici tablo

        // Yapıcı metot: kullanıcı ID ve TC alınır
        public HareketGeçmişi(int musteriID, long gnTc)
        {
            InitializeComponent();
            MusteriID = musteriID;
            gnTC = gnTc;
        }

        // Form yüklendiğinde filtre seçenekleri eklenir ve varsayılan veri getirilir
        private void HareketGeçmişi_Load(object sender, EventArgs e)
        {
            // Filtreleme için combobox'a seçenekler ekleniyor
            comboBox1.Items.Add("Hepsi");
            comboBox1.Items.Add("Hesap Hareketleri");
            comboBox1.Items.Add("Transfer İşlemleri");
            comboBox1.SelectedIndex = 0; // Varsayılan olarak "Hepsi" seçilir

            // Seçilen filtreye göre veriler getirilir ve tabloya bağlanır
            tumVeriler = DatabaseHelper.Hargec(gnTC, comboBox1.SelectedItem.ToString());
            dgvhar.DataSource = tumVeriler;
        }

        // Geri butonuna basıldığında ana menüye dönülür
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AtmEkranıForm musterilog = new AtmEkranıForm(MusteriID, gnTC);
            musterilog.Show();
        }

        // Veri tablosuna tıklanırsa (şu an için işlevsiz ama gelecekte kullanılabilir)
        private void dgvhar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Hücre içeriği tıklanma işlemi (opsiyonel)
        }

        // Filtre combobox'ı değiştirildiğinde tablo yenilenir
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string secim = comboBox1.SelectedItem.ToString(); // Seçilen filtre
            dgvhar.DataSource = DatabaseHelper.Hargec(gnTC, secim); // Yeni veri tablosu yüklenir
        }
    }
}
