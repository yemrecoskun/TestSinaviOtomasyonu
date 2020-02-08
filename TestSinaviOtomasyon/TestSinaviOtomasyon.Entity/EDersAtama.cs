using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSinaviOtomasyon.Common.DataTransferObjects;

namespace TestSinaviOtomasyon.Entity
{
    public class EDersAtama
    {
        public void DersAtamaDuzenle(DTODersAtama ders)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("update `ders_atama` set ders_adi='" + ders.ders_adi + "', bolum_adi ='"+ders.bolum_adi + "',donem_adi='"+ders.donem_adi+"',kullanici_id='"+ders.kullanici_id+"' where ders_id='" + ders.dersatama_id + "'", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public void DersAtamaEkle(DTODersAtama ders)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into `ders_atama`(`ders_adi`,`bolum_adi`,`donem_adi`,`kullanici_id`)values('" + ders.ders_adi + "','" + ders.bolum_adi + "','" + ders.donem_adi + "','" + ders.kullanici_id + "')", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public List<DTODersAtama> DersAtamaListele()
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            List<DTODersAtama> DersAtamaListesi = new List<DTODersAtama>();
            MySqlCommand cmd = new MySqlCommand("call dersatama_sorgula", Globals.Globals.con);
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTODersAtama ders = new DTODersAtama();
                ders.dersatama_id = rd.GetString("dersatama_id");
                ders.kullanici_ad = rd.GetString("kullanici_ad");
                ders.kullanici_soyadi = rd.GetString("kullanici_soyadi");
                ders.ders_adi = rd.GetString("ders_adi");
                ders.bolum_adi = rd.GetString("bolum_adi");
                ders.donem_adi = rd.GetString("donem_adi");
                DersAtamaListesi.Add(ders);
            }
            Globals.Globals.con.Close();
            rd.Close();
            return DersAtamaListesi;
        }

        public void DersAtamaSil(string id)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from `ders_atama` where dersatama_id='" + id + "'", Globals.Globals.con);
            cmd.ExecuteReader();
            Globals.Globals.con.Close();
        }
        public List<DTODersAtama> AktifDonemDersler()
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("call aktifdonemdersler_sorgula", Globals.Globals.con);
            List<DTODersAtama> DersAtamaListesi = new List<DTODersAtama>();
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTODersAtama ders = new DTODersAtama();
                ders.dersatama_id = rd.GetString("dersatama_id");
                ders.kullanici_ad = rd.GetString("kullanici_ad");
                ders.kullanici_soyadi = rd.GetString("kullanici_soyadi");
                ders.ders_adi = rd.GetString("ders_adi");
                ders.bolum_adi = rd.GetString("bolum_adi");
                ders.donem_adi = rd.GetString("donem_adi");
                DersAtamaListesi.Add(ders);
            }
            Globals.Globals.con.Close();
            rd.Close();
            return DersAtamaListesi;
        }
    }
}
