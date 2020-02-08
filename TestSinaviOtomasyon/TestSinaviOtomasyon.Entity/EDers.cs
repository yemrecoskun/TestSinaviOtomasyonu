using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSinaviOtomasyon.Common.DataTransferObjects;

namespace TestSinaviOtomasyon.Entity
{
    public class EDers
    {
        public void DersDuzenle(DTODers ders)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("update `ders` set ders_adi='"+ders.ders_adi+"' where ders_id='" + ders.ders_id+ "'", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public void DersEkle(DTODers ders)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into `ders`(`ders_adi`)values('" + ders.ders_adi + "')", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public List<DTODers> DersListele()
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            List<DTODers> DersListesi = new List<DTODers>();
            MySqlCommand cmd = new MySqlCommand("call ders_sorgula", Globals.Globals.con);
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTODers ders = new DTODers();
                ders.ders_id = rd.GetString("ders_id");
                ders.ders_adi = rd.GetString("ders_adi");
                DersListesi.Add(ders);
            }
            Globals.Globals.con.Close();
            rd.Close();
            return DersListesi;
        }

        public void DersSil(string id)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from `ders` where ders_id='" + id + "'", Globals.Globals.con);
            cmd.ExecuteReader();
            Globals.Globals.con.Close();
        }
    }
}
