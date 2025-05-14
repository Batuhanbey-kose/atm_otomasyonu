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
    public partial class BakiyeOgren : Form
    {
        public int MusteriID { get; set; }
        public long gnTC { get; set; }
        
        public BakiyeOgren(int musteriID,long gntc)
        {
            InitializeComponent();
            MusteriID = musteriID;
            gnTC = gntc;
        }

        private void BakiyeLoad_Load(object sender, EventArgs e)
        {
            GuncelBakiyeyiGoster();
        }
        private void GuncelBakiyeyiGoster()
        {
            decimal? bakiye = DatabaseHelper.Bakögren(MusteriID);

            if (bakiye.HasValue)
            {
                bak.Text = $"{bakiye:C2}";
            }
            else
            {
                bak.Text = "Bakiye bulunamadı.";
            }
        }

        private void bak_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            AtmEkranıForm atmEkrani2 = new AtmEkranıForm(MusteriID,gnTC);
            atmEkrani2.Show();
        }
    }
}