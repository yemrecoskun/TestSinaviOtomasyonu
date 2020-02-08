using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSinaviOtomasyon.Common.DataTransferObjects;

namespace TestSinaviOtomasyon.Entity
{
    public class EBolum
    {
        public void BolumDuzenle(DTOBolum bolum)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("update `bolum` set `bolum_ad`='" + bolum.bolum_ad+ "',`fakulte_adi`='"+bolum.fakulte_adi+"' where bolum_id='" + bolum.bolum_id+ "'", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public void BolumEkle(DTOBolum bolum)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into `bolum`(`bolum_ad`,`fakulte_adi`)values('" + bolum.bolum_ad + "','" + bolum.fakulte_adi + "')", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public List<DTOBolum> BolumListele()
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            List<DTOBolum> BolumListesi = new List<DTOBolum>();
            MySqlCommand cmd = new MySqlCommand("call bolum_sorgula", Globals.Globals.con);
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTOBolum bolum = new DTOBolum();
                bolum.bolum_id = rd.GetString("bolum_id");
                bolum.bolum_ad = rd.GetString("bolum_ad");
                bolum.fakulte_adi = rd.GetString("fakulte_adi");
                BolumListesi.Add(bolum);
            }
            Globals.Globals.con.Close();
            rd.Close();
            return BolumListesi;
        }

        public void BolumSil(int id)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from `bolum` where bolum_id='" + id + "'", Globals.Globals.con);
            cmd.ExecuteReader();
            Globals.Globals.con.Close();
        }
    }
}
