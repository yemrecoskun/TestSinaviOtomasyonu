using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSinaviOtomasyon.Common.DataTransferObjects;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
namespace TestSinaviOtomasyon.Entity
{
 public class ETestSinaviOku
    {
        _Application excel = new _Excel.Application();
        Workbook wb;
        public void SinavOku(DTOSinav sinav)
        {
            Globals.Globals.excelxlsx = sinav.excelxlsx;
            string dosya = sinav.sinavsonuclari;
            string dosya1 = sinav.cevapanahtari;
            string[] fs = File.ReadAllLines(dosya);
            int boyut = fs.Length;
            List<DTOSinav> Liste = new List<DTOSinav>();
            for (int i = 0; i < boyut; i++)
            {
                DTOSinav ogrenci = new DTOSinav();
                char[] liste = fs[i].ToCharArray();
                ogrenci.ad = (new string(liste, 0, 12));
                ogrenci.soyad = (new string(liste, 12, 12));
                ogrenci.numara = (new string(liste, 24, 9));
                ogrenci.kitapcikturu = (new string(liste, 33, 1));
                ogrenci.cevap = (new string(liste, 34, liste.Length-34)); 
                Liste.Add(ogrenci);
            }
            fs = File.ReadAllLines(dosya1);
            int boyutcevap = fs.Length;
            List<string> cevapanahtarikitapcikturu = new List<string>();
            List<string> cevapanahtari = new List<string>();
            for (int i = 0; i < boyutcevap; i++)
            {
                char[] liste = fs[i].ToCharArray();
                if (liste[0] != ' ') cevapanahtarikitapcikturu.Add(new string(liste, 0, 1));
                if (liste[1] != ' ') cevapanahtari.Add(new string(liste, 1, liste.Length-1));
            }
            int satir = 2;
            Worksheet ws;
            wb = excel.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            wb.Worksheets.Add();
            wb.Worksheets.Add();
            wb.Worksheets.Add();
            ws = wb.Worksheets[1];
            int soruboyutu = 0;
            foreach (var item in Liste)
            {
                soruboyutu = cevapanahtari[0].Length;
                Globals.Globals.soruboyutu = soruboyutu;
                boyutcevap = 0;
                foreach (var item1 in cevapanahtarikitapcikturu)
                {
                    if (item.kitapcikturu == item1)
                    {


                        char[] ogrencicevap = item.cevap.ToCharArray();
                        char[] cevap = cevapanahtari[boyutcevap].ToCharArray();
                        double puan = 100.00 / (cevapanahtari[0].Length) + .00;
                        double toplampuan = 0;
                        ws.Cells[1, 1] = "Öğrenci No";
                        ws.Cells[1, 2] = "Adı/Soyadı";
                        for (int i = 0; i < cevapanahtari[0].Length; i++)
                        {
                            ws.Cells[1, i + 3] = "Soru" + (i + 1);
                            if (i == cevapanahtari[0].Length - 1) ws.Cells[1, i + 4] = "Puan";
                        }
                        ws.Cells[satir, 1] = "'" + item.numara.ToString();
                        ws.Cells[satir, 2] = item.ad + item.soyad;
                        for (int i = 3; i < cevapanahtari[0].Length + 3; i++)
                        {
                            if (ogrencicevap[i - 3] == cevap[i - 3])
                            {
                                ws.Cells[satir, i] = Math.Round(puan, 2);
                                toplampuan = toplampuan + puan;
                            }
                            else ws.Cells[satir, i] = "0";
                            if (i == cevapanahtari[0].Length + 2) ws.Cells[satir, i + 1] = Math.Round(toplampuan, 2);
                        }

                    }
                    boyutcevap++;
                }
                satir++;
            }
            ws.Cells[boyut + 3, 1] = "ORTALAMA";
            string getirpuan;
            double soruortalama = 0.0;
            for (int i = 0; i < soruboyutu; i++)
            {
                for (int j = 0; j < boyut; j++)
                {
                    try
                    {
                        getirpuan = ws.Cells[j + 2, i + 3].Value.ToString();
                        soruortalama = (soruortalama + Convert.ToDouble(getirpuan)) / 2.0;
                        if (j == boyut - 1) ws.Cells[j + 4, i + 3] = Math.Round(soruortalama, 2);
                    }
                    catch
                    {
                    }
                }

            }
            Worksheet ws1 = wb.Worksheets[2];
            ws1.Cells[1, 1] = "Soru Numarası";
            ws1.Cells[1, 2] = "Ortalaması(puan)";
            ws1.Cells[1, 3] = "Başarımı(%){Ort P./Tam P.}x100";
            double sorunun_tampuani = (100.00 / soruboyutu);
            string getirortalamapuan;
            double basarim = 0.0;
            for (int i = 0; i < soruboyutu; i++)
            {
                getirortalamapuan = ws.Cells[boyut + 3, i + 3].Value.ToString();
                soruortalama = (Convert.ToDouble(getirortalamapuan));
                basarim = (soruortalama / sorunun_tampuani) * 100.0;
                ws1.Cells[i + 2, 1] = "Soru" + (i + 1).ToString();
                ws1.Cells[i + 2, 2] = Math.Round(soruortalama, 2);
                ws1.Cells[i + 2, 3] = "'" + "%" + Math.Round(basarim, 2);
            }
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            string excelxlsx = @"" + sinav.dersatama_id + "" + sinav.sinav_turu + ".xlsx";
            MySqlCommand cmd = new MySqlCommand(" insert into `sinav`(`sinav_xlsx`,`dersatama_id`,`sinav_turu`)values('"+excelxlsx+"','"+sinav.dersatama_id+"','"+sinav.sinav_turu+"')", Globals.Globals.con);
            cmd.ExecuteNonQuery();
            Globals.Globals.con.Close();
            ws1.Columns.AutoFit();
            ws.Rows[1].Font.Size = 14;
            ws.Columns.AutoFit();
            wb.SaveAs(sinav.excelxlsx);
            wb.Close();
            }
        public void KazanimBazliDegerlendirme(DTOKazanimDegerlendirme degerlendirme)
        {
            Globals.Globals.kazanim_boyutu = Globals.Globals.kazanim_boyutu + 1;
            wb = excel.Workbooks.Open(Globals.Globals.excelxlsx);
            Worksheet ws1 = wb.Worksheets[2];
            Worksheet ws2 = wb.Worksheets[3];
            Worksheet ws3 = wb.Worksheets[4];
            double ortalamakazanim = 0.0,tampuankazanim = 0.0,sorupuani=(100.00/(Globals.Globals.soruboyutu+.00)),basarimkazanim=0.0;
            ws2.Cells[1, Globals.Globals.kazanim_boyutu+1] = degerlendirme.kazanim_adi;
            ws3.Cells[Globals.Globals.kazanim_boyutu + 1, 1] = degerlendirme.kazanim_adi;
            for(int i = 1; i < Globals.Globals.soruboyutu+1; i++)
            {
                ws2.Cells[i + 1, 1] = "Soru" + (i);
            }
            foreach(var item in degerlendirme.sorular)
            {
                tampuankazanim = tampuankazanim + sorupuani;
                ortalamakazanim = ortalamakazanim + Convert.ToDouble(ws1.Cells[item + 1, 2].Value.ToString());
                ws2.Cells[item+1, Globals.Globals.kazanim_boyutu + 1] = "X";
            }
            basarimkazanim = (ortalamakazanim / tampuankazanim) * 100.00;
            ws3.Cells[1, 1] = "Kazanim";
            ws3.Cells[1, 2] = "Ortalaması{Puan}";
            ws3.Cells[1, 3] = "Başarımı(%) {Ort P. / Kazanım Tam P.)x100";
            ws3.Cells[Globals.Globals.kazanim_boyutu + 1, 1] = degerlendirme.kazanim_adi;
            ws3.Cells[Globals.Globals.kazanim_boyutu + 1, 2] = Math.Round(ortalamakazanim,2);
            ws3.Cells[Globals.Globals.kazanim_boyutu + 1, 3] = Math.Round(basarimkazanim,2);
            ws3.Columns.AutoFit();
            ws2.Columns.AutoFit();
            ws2.Rows[1].Font.Size = 14;
            ws3.Rows[1].Font.Size = 14;
            wb.Save();
            wb.Close();
        }
        }
    }
