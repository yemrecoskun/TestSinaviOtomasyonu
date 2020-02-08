using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSinaviOtomasyon.Common.DataTransferObjects;
using TestSinaviOtomasyon.Entity;

namespace TestSinaviOtomasyon.Service
{
  public  class ServiceCode
    {
        public string Login(DTOKullanici login)
        {
            ELogin elogin = new ELogin();
            return elogin.Login(login);
        }
      
        public List<DTOKullanici> KullaniciListele()
        {
            EKullanici listele = new EKullanici();
            return listele.KullaniciListele();
        }

        public List<DTOFakulte> FakulteListele()
        {
            EFakulte listele = new EFakulte();
            return listele.FakulteListele();
        }

        public List<DTOBolum> BolumListele()
        {
            EBolum listele = new EBolum();
            return listele.BolumListele();
        }

        public List<DTOKazanim> KazanimListele()
        {
            EKazanim listele = new EKazanim();
            return listele.KazanimListele();
        }

        public List<DTODonem> DonemListele()
        {
            EDonem listele = new EDonem();
            return listele.DonemListele();
        }

        public List<DTODers> DersListele()
        {
            EDers listele = new EDers();
            return listele.DersListele();
        }

        public List<DTODersAtama> DersAtamaListele()
        {
            EDersAtama listele = new EDersAtama();
            return listele.DersAtamaListele();
        }

        public void KullaniciEkle(DTOKullanici kullanici)
        {
            EKullanici ekle = new EKullanici();
            ekle.KullaniciEkle(kullanici);
        }
        public void FakulteEkle(DTOFakulte fakulte)
        {
            EFakulte ekle = new EFakulte();
            ekle.FakulteEkle(fakulte);
        }

        public void BolumEkle(DTOBolum bolum)
        {
            EBolum ekle = new EBolum();
            ekle.BolumEkle(bolum);
        }

        public void KazanimEkle(DTOKazanim kazanim)
        {
            EKazanim ekle = new EKazanim();
            ekle.KazanimEkle(kazanim);
        }

        public void DonemEkle(DTODonem donem)
        {
            EDonem ekle = new EDonem();
            ekle.DonemEkle(donem);
        }

        public void DersEkle(DTODers ders)
        {
            EDers ekle = new EDers();
            ekle.DersEkle(ders);
        }

        public void DersAtamaEkle(DTODersAtama ders)
        {
            EDersAtama ekle = new EDersAtama();
            ekle.DersAtamaEkle(ders);
        }
        public void KullaniciDuzenle(DTOKullanici kullanici)
        {
            EKullanici duzenle = new EKullanici();
            duzenle.KullaniciDuzenle(kullanici);
        }

        public void FakulteDuzenle(DTOFakulte fakulte)
        {
            EFakulte duzenle = new EFakulte();
            duzenle.FakulteDuzenle(fakulte);
        }

        public void BolumDuzenle(DTOBolum bolum)
        {
            EBolum duzenle = new EBolum();
            duzenle.BolumDuzenle(bolum);
        }

        public void KazanimDuzenle(DTOKazanim kazanim)
        {
            EKazanim duzenle = new EKazanim();
            duzenle.KazanimDuzenle(kazanim);
        }

        public void DonemDuzenle(DTODonem donem)
        {
            EDonem duzenle = new EDonem();
            duzenle.DonemDuzenle(donem);
        }

        public void DersDuzenle(DTODers ders)
        {
            EDers duzenle = new EDers();
            duzenle.DersDuzenle(ders);
        }

        public void DersAtamaDuzenle(DTODersAtama ders)
        {
            EDersAtama duzenle = new EDersAtama();
            duzenle.DersAtamaDuzenle(ders);
        }
        public void KullaniciSil(int id)
        {
            EKullanici sil = new EKullanici();
            sil.KullaniciSil(id);
        }

        public void FakulteSil(int id)
        {
            EFakulte sil = new EFakulte();
            sil.FakulteSil(id);
        }

        public void BolumSil(int id)
        {
            EBolum sil = new EBolum();
            sil.BolumSil(id);
        }

        public void KazanimSil(int id)
        {
            EKazanim sil = new EKazanim();
            sil.KazanimSil(id);
        }

        public void DersSil(string id)
        {
            EDers sil = new EDers();
            sil.DersSil(id);
        }

        public void DersAtamaSil(string id)
        {
            EDersAtama sil = new EDersAtama();
            sil.DersAtamaSil(id);
        }

        public void DonemSil(string id)
        {
            EDonem sil = new EDonem();
            sil.DonemSil(id);
        }
        public void TestSinaviOku(DTOSinav sinav)
        {
            ETestSinaviOku oku = new ETestSinaviOku();
            oku.SinavOku(sinav);
        }
        public void KazanimDegerlendirme(DTOKazanimDegerlendirme kazanim)
        {
            ETestSinaviOku degerlendir = new ETestSinaviOku();
            degerlendir.KazanimBazliDegerlendirme(kazanim);
        }
        public void DonemPasiflestirme(DTODonem donem)
        {
            EDonem donemislemi = new EDonem();
            donemislemi.DonemPasiflestirme(donem);
        }
        public List<DTODersAtama> AktifDonemDersler()
        {
            EDersAtama eDers = new EDersAtama();
            return eDers.AktifDonemDersler();
        }
    }
}
