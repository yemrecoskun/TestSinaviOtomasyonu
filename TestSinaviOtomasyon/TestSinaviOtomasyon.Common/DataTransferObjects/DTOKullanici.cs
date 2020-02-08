using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSinaviOtomasyon.Common.DataTransferObjects
{
    public class DTOKullanici
    {
        public string kullanici_id { get; set; }
        public string kullanici_ad { get; set; }
        public string kullanici_soyadi { get; set; }
        public string kullanici_sicilno { get; set; }
        public string kullanici_sifre { get; set; }
        public string kullanici_tipi { get; set; }
    }
}
