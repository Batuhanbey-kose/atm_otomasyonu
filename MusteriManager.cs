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
        // Veritabanı işlemlerini kolaylaştırmak için yardımcı sınıf
        private readonly DatabaseHelper dbHelper = new DatabaseHelper();

        // Yeni bir müşteri eklemek için kullanılan metot
        public bool MusteriEkle(Musteri musteri)
        {
            // Eğer isim boşsa kayıt yapılmaz
            if (string.IsNullOrEmpty(musteri.Ad))
            {
                return false;
            }

            // SQL sorgusu: Musteriler tablosuna yeni kayıt ekleniyor
            string query = "INSERT INTO Musteriler (Ad,Soyad,Sifre,TC,Tel,mail) Values (@Ad,@Soyad,@Sifre,@TC,@Tel,@Mail)";

            // SQL sorgusuna eklenecek parametreler hazırlanıyor
            SqlParameter[] parameters =
            {
                new ("@Ad", musteri.Ad),
                new ("@Soyad", musteri.Soyad),
                new ("@Sifre", musteri.Sifre),
                new ("@TC", musteri.TC),
                new ("@Tel", musteri.Tel),
                new ("@Mail", musteri.mail)
            };

            // Sorgu veritabanında çalıştırılıyor ve etkilenen satır sayısı alınıyor
            int result = dbHelper.ExecuteNonQuery(query, parameters);

            // Eğer bir satırdan fazlası etkilendiyse işlem başarılı sayılır
            return result > 0;
        }
    }
}
