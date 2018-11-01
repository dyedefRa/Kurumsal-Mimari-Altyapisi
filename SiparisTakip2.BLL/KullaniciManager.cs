using SiparisTakip2.DAL.Abstract;
using SiparisTakip2.Entities.Models;
using SiparisTakip2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip2.BLL
{
    public class KullaniciManager : IKullaniciService
    {
        private IKullaniciDal kullaniciDal;
        public KullaniciManager(IKullaniciDal _kullaniciDal)
        {
            kullaniciDal = _kullaniciDal;
        }
        public Kullanici Getir(int id)
        {
          return  kullaniciDal.Getir(id);

        }

        public int Guncelle(Kullanici entity)
        {
            return kullaniciDal.Guncelle(entity);
        }

        public Kullanici Kaydet(Kullanici entity)
        {
            return kullaniciDal.Kaydet(entity);
        }

        //BURADA PAROLA CEVIRMESI YAPACAGIZ.
        public Kullanici KullaniciGiris(string kullaniciAdi, string parola)
        {
            try
            {
                if (string.IsNullOrEmpty(kullaniciAdi)||string.IsNullOrEmpty(parola))
                {
                    throw new Exception("Kullanici veya Parola boş geçilemez.");
                }
                var sifre = new ToPasswordRepository().Md5(parola);


                var kullanici = kullaniciDal.KullaniciGiris(kullaniciAdi, sifre);
                if (kullanici == null)
                {
                    //throw new Exception("Kullanici ve Parola uyuşmuyor.");
                    return null;
                }
                else
                {
                    return kullanici;
                }
            }
            catch (Exception e)
            {

                throw new Exception("Kullanıcı giriş hatası. Bkz :"+e.Message);
            }
        }

        public List<Kullanici> Listele()
        {
            return kullaniciDal.Listele();
        }

        public bool Sil(int id)
        {
            return kullaniciDal.Sil(id);
        }

        public Kullanici Sil(Kullanici entity)
        {
            return kullaniciDal.Sil(entity);
        }
    }
}
