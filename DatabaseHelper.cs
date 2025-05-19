using atm_otomasyonu;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Transactions;

namespace atm_otomasyonu
{
    public class DatabaseHelper
    {
        // Veritabanı bağlantı dizesi - SQL Server'a bağlanmak için gerekli bilgiler içerir
        private static readonly string connectionString = "Server=BATUHANBEY;Database=DBATM;Trusted_Connection=True;TrustServerCertificate=True";

        // SQL bağlantısını döndürür
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Sorgu çalıştırmak ve veri döndürmek için kullanılan metot
        public DataTable ExecuteQuery(string query)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SqlCommand(query, conn);
            using var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            return dt;
        }

        // Parametreli sorgu çalıştırmak için kullanılan metot (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }

        // Kullanıcı girişini kontrol eder, doğruysa kullanıcı ID ve TC'sini döner
        public static (int id, long tc) KullaniciGiris(string ad, string sifre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Giriş yapan kişinin bilgilerini sorgulayan SQL komutu
                string query = "SELECT ID, TC FROM Musteriler WHERE Ad = @ad AND Sifre = @sifre";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ad", ad);
                command.Parameters.AddWithValue("@sifre", sifre);

                connection.Open();

                // Sonuçları okuma işlemi
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = reader.GetInt32(0); // Kullanıcı ID'si
                        long tc = Convert.ToInt64(reader["TC"]); // Kullanıcı TC'si
                        return (id, tc); // Giriş başarılıysa ID ve TC döner
                    }
                }

                return (-1, 0); // Giriş başarısızsa -1 ve 0 döner
            }
        }





        // Müşterinin hesabına para yatırma işlemi yapan metod
        public static bool ParaYatir(int musteriId, string miktar)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Müşterinin TC'sini almak için sorgu
                string yatıranTc = "";
                string gönderenQuery2 = "SELECT TC FROM Musteriler WHERE ID = @yatıranID";
                using (SqlCommand gönderenCMD = new SqlCommand(gönderenQuery2, connection))
                {
                    gönderenCMD.Parameters.AddWithValue("@yatıranID", musteriId);
                    object result = gönderenCMD.ExecuteScalar();
                    if (result != null)
                    {
                        yatıranTc = result.ToString();
                    }
                }

                // Hesaplar tablosunda bu TC'ye ait hesap var mı kontrolü
                string checkQuery = "SELECT COUNT(*) FROM hesaplar WHERE MusteriTC = @yatıranTC";
                SqlCommand checkbatu = new SqlCommand(checkQuery, connection);
                checkbatu.Parameters.AddWithValue("@yatıranTC", yatıranTc);
                int count = (int)checkbatu.ExecuteScalar();

                SqlCommand cmd;
                SqlCommand cmda;

                if (count > 0)
                {
                    // Hesap varsa bakiye güncelleme sorgusu
                    string updateQuery = "UPDATE hesaplar SET Bakiye = Bakiye + @miktar WHERE MusteriTC = @yatıranTC";
                    cmd = new SqlCommand(updateQuery, connection);

                    // Hareketler tablosuna para yatırma işlemi kaydı ekleme sorgusu
                    cmda = new SqlCommand("INSERT INTO hareketler (musteriTC, islem, tutar, tarih) VALUES (@p0, @p1, @p2, @p3)", connection);
                }
                else
                {
                    // Hesap yoksa yeni hesap oluşturma sorgusu
                    string insertQuery = "INSERT INTO hesaplar (MusteriTC, Bakiye) VALUES (@yatıranTC, @miktar)";
                    cmd = new SqlCommand(insertQuery, connection);

                    // Hareketler tablosuna para yatırma işlemi kaydı ekleme sorgusu
                    cmda = new SqlCommand("INSERT INTO hareketler (musteriTC, islem, tutar, tarih) VALUES (@p0, @p1, @p2, @p3)", connection);
                }

                // Hareketler tablosu parametreleri
                string durum = "Para Yatırma";
                cmda.Parameters.AddWithValue("@p0", yatıranTc);
                cmda.Parameters.AddWithValue("@p1", durum);
                cmda.Parameters.AddWithValue("@p2", miktar);
                cmda.Parameters.AddWithValue("@p3", DateTime.Now);

                // Hesap bakiyesi güncelleme/ekleme parametreleri
                cmd.Parameters.AddWithValue("@miktar", miktar);
                cmd.Parameters.AddWithValue("@yatıranTC", yatıranTc);

                // Sorguları çalıştır ve etkilenen satır sayısını al
                int rowsAffected = cmd.ExecuteNonQuery();
                cmda.ExecuteNonQuery();

                // Eğer bakiye güncelleme/ekleme başarılıysa true döndür
                return rowsAffected > 0;
            }
        }

        // Müşterinin hesabından para çekme işlemi yapan metod
        public static bool ParaCek(int musteriId, string miktar)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Müşterinin TC'sini almak için sorgu
                string cekenTC = "";
                string gönderenQuery2 = "SELECT TC FROM Musteriler WHERE ID = @yatıranID";

                using (SqlCommand gönderenCMD = new SqlCommand(gönderenQuery2, connection))
                {
                    gönderenCMD.Parameters.AddWithValue("@yatıranID", musteriId);
                    object result = gönderenCMD.ExecuteScalar();
                    if (result != null)
                    {
                        cekenTC = result.ToString();
                    }
                }

                // Hesaptaki mevcut bakiyeyi sorgula
                string bakiyeQuery = "SELECT Bakiye FROM Hesaplar WHERE MusteriTC = @cekenTC";
                SqlCommand bakiyeCMD = new SqlCommand(bakiyeQuery, connection);
                bakiyeCMD.Parameters.AddWithValue("@cekenTC", cekenTC);
                object bakiyeResult = bakiyeCMD.ExecuteScalar();

                // Yeterli bakiye yoksa işlemi iptal et
                if (bakiyeResult == null || Convert.ToDecimal(bakiyeResult) < Convert.ToDecimal(miktar))
                {
                    return false;
                }

                // Bakiyeden para çekme sorgusu (bakiye yeterliyse)
                string query = "UPDATE Hesaplar SET Bakiye = Bakiye - @miktar WHERE MusteriTC = @cekenTC AND Bakiye >= @miktar";
                SqlCommand cmda = new SqlCommand(query, connection);
                cmda.Parameters.AddWithValue("@miktar", miktar);
                cmda.Parameters.AddWithValue("@cekenTC", cekenTC);

                // Hareketler tablosuna para çekme işlemi kaydı ekleme sorgusu
                string insert2 = "INSERT INTO hareketler (musteriTC, islem, tutar, tarih) VALUES (@p0, @p1, @p2, @p3)";
                SqlCommand cmdaB = new SqlCommand(insert2, connection);
                string durum = "Para Çekme";
                cmdaB.Parameters.AddWithValue("@p0", cekenTC);
                cmdaB.Parameters.AddWithValue("@p1", durum);
                cmdaB.Parameters.AddWithValue("@p2", miktar);
                cmdaB.Parameters.AddWithValue("@p3", DateTime.Now);

                // Para çekme sorgusunu çalıştır
                int rowsAffected = cmda.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    // Para çekme başarılıysa hareket kaydını ekle
                    cmdaB.ExecuteNonQuery();
                    return true;
                }

                // İşlem başarısızsa false döndür
                return false;
            }
        }

        // Belirli bir müşterinin şifresini güncelleyen metod
        public static bool Sifrede(int musteriId, string yenisifre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Müşterinin şifresini güncelleyen SQL sorgusu
                SqlCommand komut = new SqlCommand("update musteriler set sifre = @p1 where ID =@p2", connection);
                komut.Parameters.AddWithValue("@p1", yenisifre);
                komut.Parameters.AddWithValue("@p2", musteriId);

                // Eski şifreyi kontrol etmek için (gerekmese de önceki değeri alma gibi kullanılabilir)
                string sifrecheck = "select sifre from Musteriler where ID = @p3";
                string essi = "";
                using (SqlCommand gönderenCMD = new SqlCommand(sifrecheck, connection))
                {
                    gönderenCMD.Parameters.AddWithValue("@p3", musteriId);
                    object result = gönderenCMD.ExecuteScalar();
                    if (result != null)
                    {
                        essi = result.ToString();
                    }
                }

                // Müşterinin TC bilgisini almak için sorgu
                string logTC = "";
                string gönderenQuery2 = "SELECT TC FROM Musteriler WHERE ID = @logID";
                using (SqlCommand gönderenCMD = new SqlCommand(gönderenQuery2, connection))
                {
                    gönderenCMD.Parameters.AddWithValue("@logID", musteriId);
                    object result = gönderenCMD.ExecuteScalar();
                    if (result != null)
                    {
                        logTC = result.ToString();
                    }
                }

                // Hareketler tablosuna "Şifre Güncelleme" işlemi olarak log ekleniyor
                string sifhar = "insert into hareketler (musteriTC, islem, tutar, tarih) values (@p0, @p1, @p2, @p3)";
                SqlCommand harsif = new SqlCommand(sifhar, connection);
                string durum = "Şifre Güncelleme";
                harsif.Parameters.AddWithValue("@p0", logTC);
                harsif.Parameters.AddWithValue("@p1", durum);
                harsif.Parameters.AddWithValue("@p2", DBNull.Value); // Şifre işlemlerinde tutar girilmiyor
                harsif.Parameters.AddWithValue("@p3", DateTime.Now);

                // Şifre güncelleme sorgusunu çalıştır ve ardından hareket kaydını işle
                int rowsAffected = komut.ExecuteNonQuery();
                harsif.ExecuteNonQuery();

                // Güncelleme başarılıysa true döndür
                return rowsAffected > 0;
            }
        }

        // Belirli bir müşterinin geçmiş işlemlerini (hareketler ve transferler) getiren metod
        public static DataTable Hargec(long musteriTC, string filtre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable sonuc = new DataTable(); // Tüm veriler burada toplanacak
                connection.Open();

                // Eğer filtre "Hesap Hareketleri" ya da "Hepsi" ise hareketleri çek
                if (filtre == "Hesap Hareketleri" || filtre == "Hepsi")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM hareketler WHERE musteriTC = @p1", connection);
                    cmd.Parameters.AddWithValue("@p1", musteriTC);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    da1.Fill(sonuc); // Veriyi sonuca ekle
                }

                // Eğer filtre "Transfer İşlemleri" ya da "Hepsi" ise transfer geçmişini çek
                if (filtre == "Transfer İşlemleri" || filtre == "Hepsi")
                {
                    SqlCommand cmda = new SqlCommand("SELECT * FROM transfera WHERE alıcıTC = @p2 OR gönderenTC = @p2", connection);
                    cmda.Parameters.AddWithValue("@p2", musteriTC);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmda);
                    DataTable transferVeri = new DataTable();
                    da2.Fill(transferVeri);
                    sonuc.Merge(transferVeri); // Hareket verisiyle birleştir
                }

                // Eğer gelen veriler transfer içeriyorsa, işlem türünü belirten bir sütun ekle
                if (sonuc.Columns.Contains("alıcıTC") && sonuc.Columns.Contains("gönderenTC"))
                {
                    // Eğer daha önce eklenmemişse "islem" adında bir sütun oluştur
                    if (!sonuc.Columns.Contains("islem"))
                        sonuc.Columns.Add("islem", typeof(string));

                    // Her satır için işlem yönünü belirle: Para Geldi mi Gitti mi?
                    foreach (DataRow row in sonuc.Rows)
                    {
                        if (row["alıcıTC"].ToString() == musteriTC.ToString())
                            row["islem"] = "Para Geldi";
                        else if (row["gönderenTC"].ToString() == musteriTC.ToString())
                            row["islem"] = "Para Gitti";
                    }
                }

                return sonuc;
            }
        }


        public static bool Transfera(long gnTC, int gönderenID, string aliciTC, string miktar)
        {
            // Yeni bir SQL bağlantısı başlat
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tüm işlemleri tek seferde kontrol etmek için transaction başlat
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Gönderenin TC'sini ID üzerinden alıyoruz
                        string gönderenTc = "";
                        string gönderenQuery2 = "SELECT TC FROM Musteriler WHERE ID = @gönderenID";
                        using (SqlCommand gönderenCMD = new SqlCommand(gönderenQuery2, connection, transaction))
                        {
                            gönderenCMD.Parameters.AddWithValue("@gönderenID", gönderenID);
                            object result = gönderenCMD.ExecuteScalar();
                            if (result != null)
                            {
                                gönderenTc = result.ToString();
                            }
                        }

                        // Gönderenin bir hesabı var mı kontrol et
                        string gönderenQuery = "SELECT COUNT(*) FROM Hesaplar WHERE MusteriTC = @gönderenTC";
                        using (SqlCommand gönderenCMD = new SqlCommand(gönderenQuery, connection, transaction))
                        {
                            gönderenCMD.Parameters.AddWithValue("@gönderenTC", gönderenTc);
                            int gönderenSayisi = (int)gönderenCMD.ExecuteScalar();
                            if (gönderenSayisi == 0)
                            {
                                transaction.Rollback(); // Hesap yoksa işlem iptal
                                return false;
                            }
                        }

                        int count = 0;

                        // Alıcı müşteri kayıtlı mı kontrol et
                        string aliciKontrolQuery = "SELECT COUNT(*) FROM Musteriler WHERE TC = @aliciTC";
                        using (SqlCommand aliciKontrolCmd = new SqlCommand(aliciKontrolQuery, connection, transaction))
                        {
                            aliciKontrolCmd.Parameters.AddWithValue("@aliciTC", aliciTC);
                            int aliciSayisi = (int)aliciKontrolCmd.ExecuteScalar();
                            if (aliciSayisi == 0)
                            {
                                transaction.Rollback(); // Kayıtlı değilse işlem iptal
                                return false;
                            }
                            count = aliciSayisi;
                        }

                        // Alıcının hesabı var mı kontrol et
                        string aliciKontrolQuery2 = "SELECT COUNT(*) FROM Hesaplar WHERE MusteriTC = @aliciTC";
                        using (SqlCommand aliciKontrolCmd = new SqlCommand(aliciKontrolQuery2, connection, transaction))
                        {
                            aliciKontrolCmd.Parameters.AddWithValue("@aliciTC", aliciTC);
                            int aliciSayisi = (int)aliciKontrolCmd.ExecuteScalar();

                            if (aliciSayisi == 0 && count > 0)
                            {
                                // Alıcının hesabı yok ama müşteri olarak kayıtlıysa yeni hesap aç
                                string cekmeQuery2 = "INSERT INTO Hesaplar  (MusteriTC, Bakiye) VALUES (@aliciTC, @miktar)";
                                using (SqlCommand ekleme = new SqlCommand(cekmeQuery2, connection, transaction))
                                {
                                    ekleme.Parameters.AddWithValue("@miktar", miktar);
                                    ekleme.Parameters.AddWithValue("@aliciTC", aliciTC);
                                    int eklemesonuc = ekleme.ExecuteNonQuery();
                                    if (eklemesonuc <= 0)
                                    {
                                        transaction.Rollback();
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                // Alıcının hesabı varsa bakiyeye ekleme yap
                                string yatirmaQuery = "UPDATE Hesaplar SET Bakiye = Bakiye + @miktar WHERE MusteriTC = @aliciTC";
                                using (SqlCommand yatirmaCmd = new SqlCommand(yatirmaQuery, connection, transaction))
                                {
                                    yatirmaCmd.Parameters.AddWithValue("@miktar", miktar);
                                    yatirmaCmd.Parameters.AddWithValue("@aliciTC", aliciTC);
                                    int yatirmaSonuc = yatirmaCmd.ExecuteNonQuery();
                                    if (yatirmaSonuc <= 0)
                                    {
                                        transaction.Rollback();
                                        return false;
                                    }
                                }
                            }
                        }

                        // Gönderenin hesabından para düş (bakiye yeterliyse)
                        string cekmeQuery = "UPDATE Hesaplar SET Bakiye = Bakiye - @miktar WHERE MusteriTC = @gönderenTc AND Bakiye >= @miktar";
                        using (SqlCommand cekmeCmd = new SqlCommand(cekmeQuery, connection, transaction))
                        {
                            cekmeCmd.Parameters.AddWithValue("@miktar", miktar);
                            cekmeCmd.Parameters.AddWithValue("@gönderenTc", gönderenTc);
                            int cekmeSonuc = cekmeCmd.ExecuteNonQuery();
                            if (cekmeSonuc <= 0)
                            {
                                transaction.Rollback(); // Bakiye yetersizse işlem iptal
                                return false;
                            }
                        }

                        // Transfer işlemini kayıt altına al
                        string transferQuery = "INSERT INTO transfera (alıcıTC, gönderenTC, tutar, tarih) VALUES (@aliciTC, @gönderenTc, @miktar, @time)";
                        using (SqlCommand transferCmd = new SqlCommand(transferQuery, connection, transaction))
                        {
                            transferCmd.Parameters.AddWithValue("@aliciTC", aliciTC);
                            transferCmd.Parameters.AddWithValue("@gönderenTc", gönderenTc);
                            transferCmd.Parameters.AddWithValue("@miktar", miktar);
                            transferCmd.Parameters.AddWithValue("@time", DateTime.Now);
                            transferCmd.ExecuteNonQuery();
                        }

                        // Tüm işlemler sorunsuzsa commit et
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        // Hata durumunda işlemi geri al
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }


        // Müşterinin mevcut (eski) şifresini döndüren metot
        public static string Eskisifre(int musteriId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // İlgili müşterinin şifresini almak için sorgu hazırlanıyor
                string sifrecheck = "SELECT sifre FROM Musteriler WHERE ID = @p1";
                using (SqlCommand komut = new SqlCommand(sifrecheck, connection))
                {
                    komut.Parameters.AddWithValue("@p1", musteriId);

                    // Şifre veritabanından çekiliyor
                    object result = komut.ExecuteScalar();

                    // Eğer şifre varsa döndür, yoksa null dön
                    if (result != null)
                    {
                        return result.ToString();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        // Müşterinin mevcut bakiyesini öğrenen ve işlem kaydı oluşturan metot
        public static decimal? Bakögren(int musteriID)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string gönderenTc = "";

                    // Müşteri ID’sine göre TC numarası çekiliyor
                    string gönderenQuery2 = "SELECT TC FROM Musteriler WHERE ID = @musteriID";
                    using (SqlCommand gönderenCMD = new SqlCommand(gönderenQuery2, conn))
                    {
                        gönderenCMD.Parameters.AddWithValue("@musteriID", musteriID);
                        object result = gönderenCMD.ExecuteScalar();
                        if (result != null)
                        {
                            gönderenTc = result.ToString();
                        }
                    }

                    // Hareket tablosuna "Bakiye Öğrenme" işlemi olarak log kaydı ekleniyor
                    string gecbak = "INSERT INTO hareketler (musteriTC, islem, tutar, tarih) VALUES (@p0, @p1, @p2, @p3)";
                    SqlCommand bakgec = new SqlCommand(gecbak, conn);
                    string durum = "Bakiye Öğrenme";
                    bakgec.Parameters.AddWithValue("@p0", gönderenTc);
                    bakgec.Parameters.AddWithValue("@p1", durum);
                    bakgec.Parameters.AddWithValue("@p2", DBNull.Value); // Bakiye bilgisi yazılmıyor
                    bakgec.Parameters.AddWithValue("@p3", DateTime.Now);
                    bakgec.ExecuteNonQuery();

                    // Hesaplar tablosundan müşterinin bakiyesi çekiliyor
                    string query = "SELECT Bakiye FROM Hesaplar WHERE MusteriTC = @gönderenTc";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@gönderenTc", gönderenTc);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToDecimal(result); // Bakiye döndürülüyor
                        }

                        return null; // Kayıt yoksa null dön
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata varsa debug’a yaz, kullanıcıya göstermeden null dön
                System.Diagnostics.Debug.WriteLine($"Veritabanı Hatası (BakOgren): {ex.Message}");
                return null;
            }
        }
    }
}