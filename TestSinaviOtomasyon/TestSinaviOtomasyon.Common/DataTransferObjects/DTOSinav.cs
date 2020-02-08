using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSinaviOtomasyon.Common.DataTransferObjects
{
    public class DTOSinav
    {
        //ÖğrenciListesi
        public string ad { get; set; }
        public string soyad { get; set; }
        public string numara { get; set; }
        public string kitapcikturu { get; set; }
        public string cevap { get; set; }
        public string sonuc { get; set; }
        //Sınav
        public string sinav_id { get; set; }
        public string dersatama_id { get; set; }
        public string sinav_turu { get; set; }
        public string cevapanahtari { get; set; }
        public string sinavsonuclari { get; set; }
        public string excelxlsx { get; set; }
    }
}
