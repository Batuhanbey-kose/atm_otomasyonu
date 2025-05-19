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
    // Ana ATM ekranını temsil eden form
    public partial class AtmEkranıForm : Form
    {
        private int musteriId;     // Giriş yapan müşterinin ID'si
        private long gnTC;         // Giriş yapan müşterinin TC numarası

        // Form yapıcı metodu - müşteri bilgilerini alır
        public AtmEkranıForm(int musteriId, long gnTC)
        {
            InitializeComponent();
            this.musteriId = musteriId;
            this.gnTC = gnTC;
        }

        // Form yüklendiğinde çalışacak metot (şu anda boş)
        private void AtmEkranıForm_Load(object sender, EventArgs e)
        {
            // Gerekirse başlangıçta yapılacak işlemler buraya yazılır
        }

        // Para çekme butonuna tıklandığında
        private void btnParaCek_Click(object sender, EventArgs e)
        {
            this.Hide(); // Bu formu gizle
            ParaCekme atmParaCek = new ParaCekme(musteriId, gnTC); // Yeni formu aç
            atmParaCek.Show();
        }

        // Para yatırma butonuna tıklandığında
        private void btnParaYatir_Click(object sender, EventArgs e)
        {
            this.Hide();
            ParaYatirma atmParaYatir = new ParaYatirma(musteriId, gnTC);
            atmParaYatir.Show();
        }

        // Bakiye öğrenme butonuna tıklandığında
        private void btnBakiye_Click(object sender, EventArgs e)
        {
            this.Hide();
            BakiyeOgren bkögren = new BakiyeOgren(musteriId, gnTC);
            bkögren.Show();
        }

        // Transfer butonuna tıklandığında
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transfer transferForm = new Transfer(musteriId, gnTC);
            transferForm.Show();
        }

        // Hareket geçmişi butonuna tıklandığında
        private void btnhar_Click(object sender, EventArgs e)
        {
            this.Hide();
            HareketGeçmişi transferForm = new HareketGeçmişi(musteriId, gnTC);
            transferForm.Show();
        }

        // Şifre değiştirme butonuna tıklandığında
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            sifredegis sif = new sifredegis(musteriId, gnTC);
            sif.Show();
        }
    }
}
