using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using TestSinaviOtomasyon.Common.DataTransferObjects;
using TestSinaviOtomasyon.Service;
namespace TestSinaviOtomasyon.Controllers
{
    public class HomeController : Controller
    {
        //Servis Kodunu Çağırıyoruz.(Katmanlı mimari)
        ServiceCode servis = new ServiceCode();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public JsonResult AdminLogin(DTOKullanici login)
        {
            login.kullanici_tipi = "1";
            if (login.kullanici_sicilno == "" && login.kullanici_sifre == "") return Json("");
            else
            {
                return Json(servis.Login(login));
            }
        }
        public JsonResult OgretimUyesiLogin(DTOKullanici login)
        {
            login.kullanici_tipi = "2";
            if (login.kullanici_sicilno == "" && login.kullanici_sifre == "") return Json("");
            else
            {
                return Json(servis.Login(login));
            }
        }
        public ActionResult AnaSayfa()
        {
            return View();
        }
        public ActionResult OgretimUyesiSayfa()
        {
            return View();
        }
        public ActionResult OgretimDersListele()
        {
            return View();
        }
        public ActionResult OgretimUyesiSinav()
        {
            return View();
        }
        public ActionResult Kullanici()
        {
            return View();
        }
        public ActionResult Fakulte()
        {
            return View();
        }
        public ActionResult Bolum()
        {
            return View();
        }
        public ActionResult Kazanim()
        {
            return View();
        }
        public ActionResult Donem()
        {
            return View();
        }
        public ActionResult Ders()
        {
            return View();
        }
        public ActionResult DersAtama()
        {
            return View();
        }
        public ActionResult SinavListele()
        {
            return View();
        }
        public ActionResult Sinav()
        {
            return View();
        }
        public JsonResult AraDersListesi(DTODersAtama Liste)
        {
            ViewBag.DonemBolum = Liste.donem_adi + " - " + Liste.bolum_adi;
            List<string> DersGetir = new List<string>();
            foreach(var item in servis.DersAtamaListele())
            {
                if(Liste.donem_adi == item.donem_adi && Liste.bolum_adi == item.bolum_adi)
                {
                    DersGetir.Add(item.dersatama_id);
                }
            }
            return Json(DersGetir);
        }
        //Okunmuş Sınavları Çağırır
        public JsonResult SinavCagir(DTOSinav sinav)
        {
            try
            {

                string FileName = sinav.dersatama_id + sinav.sinav_turu + ".xlsx";
                var yol = Path.Combine(Server.MapPath("~/OkunmusSinavlar"), FileName);
                FileInfo file = new FileInfo(yol);
                System.Diagnostics.Process.Start(yol);
                return Json("");
            }
            catch
            {
                if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
                Globals.Globals.con.Open();
                MySqlCommand cmd = new MySqlCommand("delete from sinav where dersatama_id='"+sinav.dersatama_id+"' and sinav_turu='"+sinav.sinav_turu+"'",Globals.Globals.con);
                cmd.ExecuteReader();
                Globals.Globals.con.Close();
                return Json("Dosya Bulunamadı");

            }
        }
        //Test Sınavı Okuma
        [HttpPost]
        public ActionResult OgretimUyesiSinav(DTOSinav sinav, HttpPostedFileBase cevapanahtari, HttpPostedFileBase sinavsonuclari)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sinav", Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            string sinavdurumu = "";
            while (rd.Read()) if (sinav.sinav_turu == rd.GetString("sinav_turu") && sinav.dersatama_id == rd.GetString("dersatama_id")) sinavdurumu = "okundu";
            Globals.Globals.con.Close();
            if (sinavdurumu == "okundu")
            {

                ViewBag.Message = "Sınav Zaten Okutulmuş";
                return View();
            }
            else
            {
                var dersadi = "";
                foreach (var item in servis.DersAtamaListele())
                {
                    if (item.dersatama_id == sinav.dersatama_id) dersadi = item.ders_adi;
                }
                foreach (var item in servis.DersListele())
                {
                    if (item.ders_adi == dersadi) Globals.Globals.kazanim_turu_id = item.ders_id;
                }
                var FileName = Path.GetFileName(cevapanahtari.FileName);
                var path = Path.Combine(Server.MapPath("~/cevapanahtari"), FileName);
                cevapanahtari.SaveAs(path);
                FileName = Path.GetFileName(sinavsonuclari.FileName);
                var path1 = Path.Combine(Server.MapPath("~/sinavsonuclari"), FileName);
                string excelxlsx = @"" + sinav.dersatama_id + "" + sinav.sinav_turu + ".xlsx";
                var path2 = Path.Combine(Server.MapPath("~/OkunmusSinavlar"), excelxlsx);
                sinavsonuclari.SaveAs(path1);
                sinav.sinavsonuclari = path1;
                sinav.cevapanahtari = path;
                sinav.excelxlsx = path2;
                servis.TestSinaviOku(sinav);
                return RedirectToAction("KazanimBazliDegerlendirme");
            }
        }
        //Test Sınavı Okuma
        [HttpPost]
        public ActionResult Sinav(DTOSinav sinav, HttpPostedFileBase cevapanahtari, HttpPostedFileBase sinavsonuclari)
        {
            if (Globals.Globals.con.State == System.Data.ConnectionState.Open) { Globals.Globals.con.Close(); }
            Globals.Globals.con.Open();
            MySqlCommand cmd = new MySqlCommand("select * from sinav", Globals.Globals.con);
            var rd = cmd.ExecuteReader();
            string sinavdurumu = "";
            while (rd.Read()) if (sinav.sinav_turu == rd.GetString("sinav_turu") && sinav.dersatama_id == rd.GetString("dersatama_id")) sinavdurumu = "okundu";
            Globals.Globals.con.Close();
            if (sinavdurumu == "okundu")
            {
                
                ViewBag.Message = "Sınav Zaten Okutulmuş";
                return View();
            }
            else
            {
                var dersadi = "";
                foreach(var item in servis.DersAtamaListele())
                {
                    if (item.dersatama_id == sinav.dersatama_id) dersadi = item.ders_adi;
                }
                foreach(var item in servis.DersListele())
                {
                    if (item.ders_adi == dersadi) Globals.Globals.kazanim_turu_id = item.ders_id;
                }
                var FileName = Path.GetFileName(cevapanahtari.FileName);
                var path = Path.Combine(Server.MapPath("~/cevapanahtari"), FileName);
                cevapanahtari.SaveAs(path);
                FileName = Path.GetFileName(sinavsonuclari.FileName);
                var path1 = Path.Combine(Server.MapPath("~/sinavsonuclari"), FileName);
                string excelxlsx = @"" + sinav.dersatama_id + "" + sinav.sinav_turu + ".xlsx";
                var path2 = Path.Combine(Server.MapPath("~/OkunmusSinavlar"), excelxlsx);
                sinavsonuclari.SaveAs(path1);
                sinav.sinavsonuclari = path1;
                sinav.cevapanahtari = path;
                sinav.excelxlsx = path2;
                servis.TestSinaviOku(sinav);
                return RedirectToAction("KazanimBazliDegerlendirme");
            }
        }
        public ActionResult KazanimBazliDegerlendirme()
        {
            return View();
        }
        public JsonResult KazanimDegerlendirme(DTOKazanimDegerlendirme kazanimdegerlendirme)
        {
            servis.KazanimDegerlendirme(kazanimdegerlendirme);
            return Json(kazanimdegerlendirme.kazanim_adi);
        }
        public JsonResult KullaniciSil(int id)
        {
            servis.KullaniciSil(id);
            return Json(id);
        }
        public JsonResult FakulteSil(int id)
        {
            servis.FakulteSil(id);
            return Json(id);
        }
        public JsonResult BolumSil(int id)
        {
            servis.BolumSil(id);
            return Json(id);
        }
        public JsonResult KazanimSil(int id)
        {
            servis.KazanimSil(id);
            return Json(id);
        }
        public JsonResult DonemSil(string id)
        {
            servis.DonemSil(id);
            return Json(id);
        }
        public JsonResult DersSil(string id)
        {
            servis.DersSil(id);
            return Json(id);
        }
        public JsonResult DersAtamaSil(string id)
        {
            servis.DersAtamaSil(id);
            return Json(id);
        }
        public JsonResult KullaniciEkle(DTOKullanici kullanici)
        {
            servis.KullaniciEkle(kullanici);
            return Json(kullanici);
        }
        public JsonResult FakulteEkle(DTOFakulte fakulte)
        {
            servis.FakulteEkle(fakulte);
            return Json(fakulte);
        }
        public JsonResult BolumEkle(DTOBolum bolum)
        {
            servis.BolumEkle(bolum);
            return Json(bolum);
        }
        public JsonResult KazanimEkle(DTOKazanim kazanim)
        {
            servis.KazanimEkle(kazanim);
            return Json(kazanim);
        }
        public JsonResult DersEkle(DTODers ders)
        {
            servis.DersEkle(ders);
            return Json(ders);
        }
        public JsonResult DersAtamaEkle(DTODersAtama ders)
        {
            servis.DersAtamaEkle(ders);
            return Json(ders);
        }
        public JsonResult DonemEkle(DTODonem donem)
        {
            if (donem.donem_durum == "Aktif")
            {
                servis.DonemPasiflestirme(donem);
            }
            servis.DonemEkle(donem);
            return Json(donem);
        }
        public JsonResult DuzenlenecekKullaniciBilgileri(string id)
        {
            Globals.Globals.id = id;
            foreach (var item in servis.KullaniciListele())
            {
                if (item.kullanici_id == id) return Json(item);
            }
            return Json("");
        }
        public JsonResult DuzenlenecekFakulteBilgileri(string id)
        {
            Globals.Globals.id = id;
            foreach (var item in servis.FakulteListele())
            {
                if (item.fakulte_id == id) return Json(item);
            }
            return Json("");
        }
        public JsonResult DuzenlenecekBolumBilgileri(string id)
        {
            Globals.Globals.id = id;
            foreach (var item in servis.BolumListele())
            {
                if (item.bolum_id == id) return Json(item);
            }
            return Json("");
        }
        public JsonResult DuzenlenecekKazanimBilgileri(string id)
        {
            Globals.Globals.id = id;
            foreach (var item in servis.KazanimListele())
            {
                if (item.kazanim_id == id) return Json(item);
            }
            return Json("");
        }
        public JsonResult DuzenlenecekDonemBilgileri(string id)
        {
            Globals.Globals.id = id;
            foreach (var item in servis.DonemListele())
            {
                if (item.donem_id == id) return Json(item);
            }
            return Json("");
        }
        public JsonResult DuzenlenecekDersBilgileri(string id)
        {
            Globals.Globals.id = id;
            foreach (var item in servis.DersListele())
            {
                if (item.ders_id == id) return Json(item);
            }
            return Json("");
        }
        public JsonResult DuzenlenecekDersAtamaBilgileri(string id)
        {
            Globals.Globals.id = id;
            foreach (var item in servis.DersAtamaListele())
            {
                if (item.dersatama_id == id)
                {
                    foreach (var item1 in servis.KullaniciListele()) if (item.kullanici_ad == item1.kullanici_ad) item.kullanici_id = item1.kullanici_id;
                    return Json(item);
                }
            }
            return Json("");
        }
        public JsonResult KullaniciDuzenle(DTOKullanici kullanici)
        {
            kullanici.kullanici_id = Globals.Globals.id;
            servis.KullaniciDuzenle(kullanici);
            return Json(kullanici);
        }
        public JsonResult FakulteDuzenle(DTOFakulte fakulte)
        {
            fakulte.fakulte_id = Globals.Globals.id;
            servis.FakulteDuzenle(fakulte);
            return Json(fakulte);
        }
        public JsonResult BolumDuzenle(DTOBolum bolum)
        {
            bolum.bolum_id = Globals.Globals.id;
            servis.BolumDuzenle(bolum);
            return Json(bolum);
        }
        public JsonResult KazanimDuzenle(DTOKazanim kazanim)
        {
            kazanim.kazanim_id = Globals.Globals.id;
            servis.KazanimDuzenle(kazanim);
            return Json(kazanim);
        }
        public JsonResult DonemDuzenle(DTODonem donem)
        {
            if (donem.donem_durum == "Aktif")
            {
                servis.DonemPasiflestirme(donem);
            }
            donem.donem_id = Globals.Globals.id;
            servis.DonemDuzenle(donem);
            return Json(donem);
        }
        public JsonResult DersDuzenle(DTODers ders)
        {
            ders.ders_id = Globals.Globals.id;
            servis.DersDuzenle(ders);
            return Json(ders);
        }
        public JsonResult DersAtamaDuzenle(DTODersAtama ders)
        {
            ders.dersatama_id = Globals.Globals.id;
            servis.DersAtamaDuzenle(ders);
            return Json(ders);
        }
        public JsonResult BolumKazanimTuruId(string id)
        {
            List<string> KazanimListesi = new List<string>();
            foreach (var item in servis.KazanimListele())
            {
                if (item.kazanim_turu == "Bölüm" && item.kazanim_turu_id == id)
                {
                    KazanimListesi.Add(item.kazanim_adi);
                }
            }
            return Json(KazanimListesi);
        }
        public JsonResult DersKazanimTuruId(string id)
        {
            List<string> KazanimListesi = new List<string>();
            foreach (var item in servis.KazanimListele())
            {
                if (item.kazanim_turu == "Ders" && item.kazanim_turu_id == id)
                {
                    KazanimListesi.Add(item.kazanim_adi);
                }
            }
            return Json(KazanimListesi);
        }
       
    }
}