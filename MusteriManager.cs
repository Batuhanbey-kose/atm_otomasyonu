using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
namespace atm_otomasyonu
{
    public class MusteriManager
    {

        private readonly DatabaseHelper dbHelper = new DatabaseHelper();

        public bool MusteriEkle(Musteri musteri)
        {

            if (string.IsNullOrEmpty(musteri.Ad))
            {

                return false;
            }
            string query = "INSERT INTO Musteriler (Ad,Soyad,Sifre,TC,Tel,mail) Values (@Ad,@Soyad,@Sifre,@TC,@Tel,@Mail)";

            SqlParameter[] parameters =
            {

                new ("@Ad",musteri.Ad),
                new ("@Soyad",musteri.Soyad),
                new ("@Sifre",musteri.Sifre),
                new ("@TC",musteri.TC),
                new ("@Tel",musteri.Tel),
                new ("@Mail",musteri.mail)

            };
            int result = dbHelper.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}