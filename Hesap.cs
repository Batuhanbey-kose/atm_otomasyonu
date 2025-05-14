using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atm_otomasyonu
{
    public class Hesap
    {

        public int ID { get; set; }
        public int MusteriTC { get; set; }

        public decimal Miktar { get; set; }

        public int AlıcıID { get; set; }

    }
}
