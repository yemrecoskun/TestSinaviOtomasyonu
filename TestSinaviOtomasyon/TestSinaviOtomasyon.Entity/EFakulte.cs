using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSinaviOtomasyon.Common.DataTransferObjects;

namespace TestSinaviOtomasyon.Entity
{
    public class EFakulte
    {
        public void FakulteDuzenle(DTOFakulte fakulte)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("update `fakulte` set fakulte_ad='" + fakulte.fakulte_ad + "' where fakulte_id='" + fakulte.fakulte_id  + "'", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public void FakulteEkle(DTOFakulte fakulte)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into `fakulte`(`fakulte_ad`)values('" + fakulte.fakulte_ad + "')", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public List<DTOFakulte> FakulteListele()
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            List<DTOFakulte> FakulteListesi = new List<DTOFakulte>();
            MySqlCommand cmd = new MySqlCommand("call fakulte_sorgula", Globals.Globals.con);
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTOFakulte fakulte = new DTOFakulte();
                fakulte.fakulte_id = rd.GetString("fakulte_id");
                fakulte.fakulte_ad = rd.GetString("fakulte_ad");
                FakulteListesi.Add(fakulte);
            }
            Globals.Globals.con.Close();
            rd.Close();
            return FakulteListesi;
        }

        public void FakulteSil(int id)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from `fakulte` where fakulte_id='" + id + "'", Globals.Globals.con);
            cmd.ExecuteReader();
            Globals.Globals.con.Close();
        }
    }
}
