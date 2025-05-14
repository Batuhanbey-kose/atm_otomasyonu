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
    public partial class AtmEkranıForm : Form
    {
        private int musteriId;
        private long gnTC; 

        public AtmEkranıForm(int musteriId, long gnTC)
        {
            InitializeComponent();
            this.musteriId = musteriId;
            this.gnTC = gnTC; 
        }

        private void AtmEkranıForm_Load(object sender, EventArgs e)
        {
           
        }

        private void btnParaCek_Click(object sender, EventArgs e)
        {
            this.Hide();
            ParaCekme atmParaCek = new ParaCekme(musteriId,gnTC);
            atmParaCek.Show();
        }

        private void btnParaYatir_Click(object sender, EventArgs e)
        {
            this.Hide();
            ParaYatirma atmParaYatir = new ParaYatirma(musteriId,gnTC); 
            atmParaYatir.Show();
        }

        private void btnBakiye_Click(object sender, EventArgs e)
        {
            this.Hide();
            BakiyeOgren bkögren = new BakiyeOgren(musteriId,gnTC); 
            bkögren.Show();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Transfer transferForm = new Transfer(musteriId, gnTC); 
            transferForm.Show();
        }

        private void btnhar_Click(object sender, EventArgs e)
        {
            this.Hide();
            HareketGeçmişi transferForm = new HareketGeçmişi(musteriId, gnTC); 
            transferForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            sifredegis sif = new sifredegis(musteriId,gnTC); 
            sif.Show();
        }
    }
}
