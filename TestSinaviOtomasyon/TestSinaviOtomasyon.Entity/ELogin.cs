using MySql.Data.MySqlClient;
using TestSinaviOtomasyon.Common.DataTransferObjects;

namespace TestSinaviOtomasyon.Entity
{
        public class ELogin
        {
            public string Login(DTOKullanici Login)
            {
                if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
                Globals.Globals.con.Open();
                MySqlCommand cmd = new MySqlCommand("call kullanici_sorgula", Globals.Globals.con);
                MySqlDataReader rd;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (Login.kullanici_tipi == rd.GetString("kullanici_tipi") && Login.kullanici_sicilno == rd.GetString("kullanici_sicilno") && Login.kullanici_sifre == rd.GetString("kullanici_sifre"))
                    {
                        Globals.Globals.ogretim_id = rd.GetString("kullanici_id");
                        Globals.Globals.con.Close();
                        rd.Close();
                        return "basarili";
                    }
                }
                Globals.Globals.con.Close();
                rd.Close();
                return "basarisiz";
            }

        }
        }
