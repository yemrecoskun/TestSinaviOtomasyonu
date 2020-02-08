using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSinaviOtomasyon.Common.DataTransferObjects;

namespace TestSinaviOtomasyon.Entity
{
    public class EDonem
    {
        public void DonemDuzenle(DTODonem donem)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("update `donem` set donem_adi='" + donem.donem_adi + "',donem_durum='"+donem.donem_durum+"' where donem_id='" + donem.donem_id + "'", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public void DonemPasiflestirme(DTODonem donem)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("update `donem` set donem_durum='Pasif' where donem_id !='" + donem.donem_id + "'",Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }
        public void DonemEkle(DTODonem donem)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("insert into `donem`(`donem_adi`,`donem_durum`)values('" + donem.donem_adi + "','"+donem.donem_durum+"')", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
        }

        public List<DTODonem> DonemListele()
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            List<DTODonem> DonemListesi = new List<DTODonem>();
            MySqlCommand cmd = new MySqlCommand("call donem_sorgula", Globals.Globals.con);
            MySqlDataReader rd;
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                DTODonem donem = new DTODonem();
                donem.donem_id = rd.GetString("donem_id");
                donem.donem_adi = rd.GetString("donem_adi");
                donem.donem_durum = rd.GetString("donem_durum");
                DonemListesi.Add(donem);
            }
            Globals.Globals.con.Close();
            rd.Close();
            return DonemListesi;
        }

        public void DonemSil(string id)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("delete from `donem` where donem_id='" + id + "'", Globals.Globals.con);
            cmd.ExecuteReader();
            Globals.Globals.con.Close();
        }
    }
}
