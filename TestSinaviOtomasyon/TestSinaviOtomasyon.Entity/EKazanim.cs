using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSinaviOtomasyon.Common.DataTransferObjects;

namespace TestSinaviOtomasyon.Entity
{
    public class EKazanim
    {
        public void KazanimDuzenle(DTOKazanim kazanim)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("update `kazanim` set kazanim_turu='" + kazanim.kazanim_turu + "', kazanim_turu_id='"+kazanim.kazanim_turu_id+"',kazanim_adi='"+kazanim.kazanim_adi+"' where kazanim_id='" + kazanim.kazanim_id + "'", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public void KazanimEkle(DTOKazanim kazanim)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into `kazanim`(`kazanim_turu`,`kazanim_turu_id`,`kazanim_adi`)values('" + kazanim.kazanim_turu + "','" + kazanim.kazanim_turu_id + "','" + kazanim.kazanim_adi + "')", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public List<DTOKazanim> KazanimListele()
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            List<DTOKazanim> KazanimListesi = new List<DTOKazanim>();
            MySqlCommand cmd = new MySqlCommand("call kazanim_sorgula", Globals.Globals.con);
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTOKazanim kazanim = new DTOKazanim();
                kazanim.kazanim_id = rd.GetString("kazanim_id");
                kazanim.kazanim_turu = rd.GetString("kazanim_turu");
                kazanim.kazanim_turu_id = rd.GetString("kazanim_turu_id");
                kazanim.kazanim_adi = rd.GetString("kazanim_adi");
                KazanimListesi.Add(kazanim);
            }
            Globals.Globals.con.Close();
            rd.Close();
            return KazanimListesi;
        }

        public void KazanimSil(int id)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from `kazanim` where kazanim_id='" + id + "'", Globals.Globals.con);
            cmd.ExecuteReader();
            Globals.Globals.con.Close();
        }
    }
}
