using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals
{
    public class Globals
    {
        //MySQL Veritabanı Bağlantı kurma.
        public static MySqlConnection con = new MySqlConnection("Server=localhost;Database=testsinaviotomasyonu;user=root;pwd='';");
        //Gizli Veriler
        public static string id { get; set; }
        public static string kazanim_turu_id { get; set; }
        public static int kazanim_boyutu = 0;
        public static int soruboyutu { get; set; }
        public static string excelxlsx { get; set; }
        public static string ogretim_id { get; set; }
        public static string aktif { get; set; }
    }
}
