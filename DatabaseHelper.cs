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

        private static readonly string connectionString = "Server=BATUHANBEY;Database=DBATM;Trusted_Connection=True;TrustServerCertificate=True";
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public DataTable ExecuteQuery(string query)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SqlCommand(query, conn);
            using var adapter = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            return dt;
        }
        public int ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using var conn = GetConnection();
            conn.Open();
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }


        public static (int id, long tc) KullaniciGiris(string ad, string sifre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT ID, TC FROM Musteriler WHERE Ad = @ad AND Sifre = @sifre";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ad", ad);
                command.Parameters.AddWithValue("@sifre", sifre);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        long tc = Convert.ToInt64(reader["TC"]); 
                        return (id, tc);
                    }
                }

                return (-1, 0);
            }
        }



        public static bool ParaYatir(int musteriId, string miktar)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))

            {

                connection.Open();

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
                string checkQuery = "Select Count (*) from hesaplar  where MusteriTC =@yatıranTC";
                SqlCommand checkbatu = new SqlCommand(checkQuery, connection);
                checkbatu.Parameters.AddWithValue("@yatıranTC", yatıranTc);
                int count = (int)checkbatu.ExecuteScalar();
                SqlCommand cmd;
                SqlCommand cmda;
                if (count > 0)
                {
                    string updateQuery = "update hesaplar set Bakiye = Bakiye + @miktar where MusteriTC =@yatıranTC";
                    cmd = new SqlCommand(updateQuery, connection);
                    cmda = new SqlCommand("insert into hareketler (musteriTC,islem,tutar,tarih) values (@p0,@p1,@p2,@p3)", connection);

                }
                else

                {
                    string insertQuery = "insert into hesaplar (MusteriTC,Bakiye) values (@yatıranTC,@miktar)";
                    string insert2 = "insert into hareketler (musteriTC,islem,tutar,tarih) values (@p0,@p1,@p2,@p3)";
                    cmd = new SqlCommand(insertQuery, connection);
                    cmda = new SqlCommand(insert2, connection);
                }

                string durum = "Para Yatırma";
                cmda.Parameters.AddWithValue("@p0", yatıranTc);
                cmda.Parameters.AddWithValue("@p1", durum);
                cmda.Parameters.AddWithValue("@p2", miktar);
                cmda.Parameters.AddWithValue("@p3", DateTime.Now);

                cmd.Parameters.AddWithValue("@miktar", miktar);
                cmd.Parameters.AddWithValue("@yatıranTC", yatıranTc);

              
                int rowsAffected = cmd.ExecuteNonQuery();
                cmda.ExecuteNonQuery(); 
                return rowsAffected > 0;

               

            }
        }

        public static bool ParaCek(int musteriId, string miktar)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

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

                string bakiyeQuery = "SELECT Bakiye FROM Hesaplar WHERE MusteriTC = @cekenTC";
                SqlCommand bakiyeCMD = new SqlCommand(bakiyeQuery, connection);
                bakiyeCMD.Parameters.AddWithValue("@cekenTC", cekenTC);
                object bakiyeResult = bakiyeCMD.ExecuteScalar();

                if (bakiyeResult == null || Convert.ToDecimal(bakiyeResult) < Convert.ToDecimal(miktar))
                {
                    return false;
                }

                string query = "UPDATE Hesaplar SET Bakiye = Bakiye - @miktar WHERE MusteriTC = @cekenTC AND Bakiye >= @miktar";
                SqlCommand cmda = new SqlCommand(query, connection);
                cmda.Parameters.AddWithValue("@miktar", miktar);
                cmda.Parameters.AddWithValue("@cekenTC", cekenTC);

                string insert2 = "INSERT INTO hareketler (musteriTC, islem, tutar, tarih) VALUES (@p0, @p1, @p2, @p3)";
                SqlCommand cmdaB = new SqlCommand(insert2, connection);
                string durum = "Para Çekme";
                cmdaB.Parameters.AddWithValue("@p0", cekenTC);
                cmdaB.Parameters.AddWithValue("@p1", durum);
                cmdaB.Parameters.AddWithValue("@p2", miktar);
                cmdaB.Parameters.AddWithValue("@p3", DateTime.Now);

                int rowsAffected = cmda.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    cmdaB.ExecuteNonQuery();
                    return true;
                }

                return false;
            }
        }

        public static bool Sifrede(int musteriId, string yenisifre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))

            {
                connection.Open();
                SqlCommand komut = new SqlCommand("update musteriler set sifre = @p1 where ID =@p2  ", connection);
                komut.Parameters.AddWithValue("@p1", yenisifre);
                komut.Parameters.AddWithValue("@p2", musteriId);


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
                string sifhar = "insert into hareketler (musteriTC,islem,tutar,tarih) values (@p0,@p1,@p2,@p3)";
                SqlCommand harsif=new SqlCommand(sifhar, connection);
                string durum = "Şifre Güncelleme";
                harsif.Parameters.AddWithValue("@p0", logTC);
                harsif.Parameters.AddWithValue("@p1", durum);
                harsif.Parameters.AddWithValue("@p2", DBNull.Value);
                harsif.Parameters.AddWithValue("@p3", DateTime.Now);






                int rowsAffected = komut.ExecuteNonQuery();
                harsif.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
        public static DataTable Hargec(long musteriTC, string filtre)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable sonuc = new DataTable();
                connection.Open();

             
                if (filtre == "Hesap Hareketleri" || filtre == "Hepsi")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM hareketler WHERE musteriTC = @p1", connection);
                    cmd.Parameters.AddWithValue("@p1", musteriTC);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                    da1.Fill(sonuc);
                }

                
                if (filtre == "Transfer İşlemleri" || filtre == "Hepsi")
                {
                    SqlCommand cmda = new SqlCommand("SELECT * FROM transfera WHERE alıcıTC = @p2 OR gönderenTC = @p2", connection);
                    cmda.Parameters.AddWithValue("@p2", musteriTC);
                    SqlDataAdapter da2 = new SqlDataAdapter(cmda);
                    DataTable transferVeri = new DataTable();
                    da2.Fill(transferVeri);
                    sonuc.Merge(transferVeri); 
                }

              
                if (sonuc.Columns.Contains("alıcıTC") && sonuc.Columns.Contains("gönderenTC"))
                {
                    if (!sonuc.Columns.Contains("islem"))
                        sonuc.Columns.Add("islem", typeof(string)); 

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
        
        public static bool Transfera(long gnTC,int gönderenID, string aliciTC, string miktar)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
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


                        
                        string gönderenQuery = "SELECT COUNT(*) FROM Hesaplar WHERE MusteriTC = @gönderenTC";
                        using (SqlCommand gönderenCMD = new SqlCommand(gönderenQuery, connection, transaction))
                        {
                            gönderenCMD.Parameters.AddWithValue("@gönderenTC", gönderenTc);
                            int gönderenSayisi = (int)gönderenCMD.ExecuteScalar();
                            if (gönderenSayisi == 0)
                            {
                                transaction.Rollback();
                                return false; 
                            }

                        }

                        int count = 0;
                        string aliciKontrolQuery = "SELECT COUNT(*) FROM Musteriler WHERE TC = @aliciTC";
                        using (SqlCommand aliciKontrolCmd = new SqlCommand(aliciKontrolQuery, connection, transaction))
                        {
                            aliciKontrolCmd.Parameters.AddWithValue("@aliciTC", aliciTC);
                            int aliciSayisi = (int)aliciKontrolCmd.ExecuteScalar();
                            if (aliciSayisi == 0)
                            {
                                transaction.Rollback();
                                return false; 
                            }
                            if (aliciSayisi > 0)
                            {
                                count = aliciSayisi;
                            }
                        }
                        string aliciKontrolQuery2 = "SELECT COUNT(*) FROM Hesaplar WHERE MusteriTC = @aliciTC";
                        using (SqlCommand aliciKontrolCmd = new SqlCommand(aliciKontrolQuery2, connection, transaction))
                        {
                            aliciKontrolCmd.Parameters.AddWithValue("@aliciTC", aliciTC);
                            int aliciSayisi = (int)aliciKontrolCmd.ExecuteScalar();
                            if (aliciSayisi == 0 && count > 0)
                            {
                               
                                string cekmeQuery2 = "INSERT INTO Hesaplar  (MusteriTC,Bakiye) Values (@aliciTC,@miktar)";
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
                      
                        string cekmeQuery = "UPDATE Hesaplar SET Bakiye = Bakiye - @miktar WHERE MusteriTC = @gönderenTc AND Bakiye >= @miktar";
                        using (SqlCommand cekmeCmd = new SqlCommand(cekmeQuery, connection, transaction))
                        {
                            cekmeCmd.Parameters.AddWithValue("@miktar", miktar);
                            cekmeCmd.Parameters.AddWithValue("@gönderenTc", gönderenTc);

                            int cekmeSonuc = cekmeCmd.ExecuteNonQuery();
                            if (cekmeSonuc <= 0)
                            {
                                transaction.Rollback();
                                return false; 
                            }
                        }
                      
                        string transferQuery = "INSERT INTO transfera (alıcıTC, gönderenTC, tutar,tarih) VALUES (@aliciTC, @gönderenTc, @miktar,@time)";
                        using (SqlCommand transferCmd = new SqlCommand(transferQuery, connection, transaction))
                        {
                            transferCmd.Parameters.AddWithValue("@aliciTC", aliciTC);
                            transferCmd.Parameters.AddWithValue("@gönderenTc", gönderenTc);
                            transferCmd.Parameters.AddWithValue("@miktar", miktar);
                            transferCmd.Parameters.AddWithValue("@time", DateTime.Now);

                            transferCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        
        public static string Eskisifre(int musteriId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                
                string sifrecheck = "SELECT sifre FROM Musteriler WHERE ID = @p1";
                using (SqlCommand komut = new SqlCommand(sifrecheck, connection))
                {
                   
                    komut.Parameters.AddWithValue("@p1", musteriId);

                  
                    object result = komut.ExecuteScalar();

                    
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

        public static decimal? Bakögren(int musteriID)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string gönderenTc = "";
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

                   
                    string gecbak = "INSERT INTO hareketler (musteriTC, islem, tutar, tarih) VALUES (@p0, @p1, @p2, @p3)";
                    SqlCommand bakgec = new SqlCommand(gecbak, conn);
                    string durum = "Bakiye Öğrenme";
                    bakgec.Parameters.AddWithValue("@p0", gönderenTc);
                    bakgec.Parameters.AddWithValue("@p1", durum);
                    bakgec.Parameters.AddWithValue("@p2", DBNull.Value);
                    bakgec.Parameters.AddWithValue("@p3", DateTime.Now);
                    bakgec.ExecuteNonQuery();
                    string query = "SELECT Bakiye FROM Hesaplar WHERE MusteriTC = @gönderenTc";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@gönderenTc", gönderenTc);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToDecimal(result);
                        }
                        return null; 
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Veritabanı Hatası (BakOgren): {ex.Message}");
                return null;
            }
        }





    }
}








