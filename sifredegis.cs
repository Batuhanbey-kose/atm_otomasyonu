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
        public int MusteriID { get; set; }
        public long gnTC { get; set; }
        public sifredegis(int musteriID,long gntc)
        {
            InitializeComponent();
            MusteriID = musteriID;
            gnTC = gntc;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string essif = DatabaseHelper.Eskisifre(MusteriID);
            string essi= txtES.Text;
            string yesi = txtYE.Text;
            if (yesi.Length != 4 || !yesi.All(char.IsDigit))
            {
                MessageBox.Show("lütfen 4 haneli bir şifre seçiniz ve sadece numaradan oluşan parola seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (essi!=essif)
            {
                MessageBox.Show("lütfen eski şifrenizi doğru giriniz! ", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (essif==yesi)
            {
                MessageBox.Show("yeni şifreniz eski şifrenizle aynı olamaz! ","Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if  (string.IsNullOrWhiteSpace(essi) || string.IsNullOrWhiteSpace(yesi))
            {
                MessageBox.Show("Boş alan bırakma", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
               
                bool güncelleme = DatabaseHelper.Sifrede(MusteriID,yesi);
                if (güncelleme)
                {
                    MessageBox.Show("Şifre Değiştirme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    AtmEkranıForm atmEkrani = new AtmEkranıForm(MusteriID, gnTC);
                    atmEkrani.Show();
                }
                else
                {
                    MessageBox.Show("Şifre Değiştirme İşlemi Başarısız Olmuştur.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AtmEkranıForm atmEkrani2 = new AtmEkranıForm(MusteriID, gnTC);
            atmEkrani2.Show();
        }

        
    }
}
