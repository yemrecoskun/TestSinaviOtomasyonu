using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSinaviOtomasyon.Common.DataTransferObjects;

namespace TestSinaviOtomasyon.Entity
{
   public class EKullanici
    {
        public void KullaniciDuzenle(DTOKullanici kullanici)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("update `kullanici` set kullanici_ad='" + kullanici.kullanici_ad + "',kullanici_soyadi='" + kullanici.kullanici_soyadi + "',kullanici_sifre='" + kullanici.kullanici_sifre + "',kullanici_sicilno='" + kullanici.kullanici_sicilno + "' where kullanici_id='" + kullanici.kullanici_id + "'", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public void KullaniciEkle(DTOKullanici kulanici)
        {
            kulanici.kullanici_tipi = "2";
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into `kullanici`(`kullanici_ad`,`kullanici_soyadi`,`kullanici_sifre`,`kullanici_sicilno`,`kullanici_tipi`)values('" + kulanici.kullanici_ad + "', '" + kulanici.kullanici_soyadi + "', '" + kulanici.kullanici_sifre + "', '" + kulanici.kullanici_sicilno + "', '" + kulanici.kullanici_tipi + "')", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public List<DTOKullanici> KullaniciListele()
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            List<DTOKullanici> kullanicilistesi = new List<DTOKullanici>();
            MySqlCommand cmd = new MySqlCommand("call kullanici_sorgula", Globals.Globals.con);
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd.GetString("kullanici_tipi") == "2")
                {
                    DTOKullanici kullanici = new DTOKullanici();
                    kullanici.kullanici_ad = rd.GetString("kullanici_ad");
                    kullanici.kullanici_soyadi = rd.GetString("kullanici_soyadi");
                    kullanici.kullanici_id = rd.GetString("kullanici_id");
                    kullanici.kullanici_tipi = rd.GetString("kullanici_tipi");
                    kullanici.kullanici_sicilno = rd.GetString("kullanici_sicilno");
                    kullanici.kullanici_sifre = rd.GetString("kullanici_sifre");
                    kullanicilistesi.Add(kullanici);
                }
            }
            Globals.Globals.con.Close();
            rd.Close();
            return kullanicilistesi;
        }

        public void KullaniciSil(int id)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from `kullanici` where kullanici_id='" + id + "'", Globals.Globals.con);
            cmd.ExecuteReader();
            Globals.Globals.con.Close();
        }
    }
}
