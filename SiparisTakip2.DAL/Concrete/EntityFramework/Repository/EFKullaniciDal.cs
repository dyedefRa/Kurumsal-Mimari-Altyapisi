using SiparisTakip2.DAL.Abstract;
using SiparisTakip2.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Repository olayını değiştirip sadece IKUllaniciDal da n miras alması gerekıyor.. video 8
namespace SiparisTakip2.DAL.Concrete.EntityFramework.Repository
{
    public class EFKullaniciDal : Repository<Kullanici>, IKullaniciDal
    {

        SiparisTakipContext ctx = new SiparisTakipContext();
        public Kullanici KullaniciGiris(string kullaniciKodu, string Sifre)
        {
            return ctx.Kullanici.FirstOrDefault(x => x.KullaniciKodu == kullaniciKodu && x.Sifre == Sifre);
        }
    }
}
