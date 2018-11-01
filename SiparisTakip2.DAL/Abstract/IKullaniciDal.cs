using SiparisTakip2.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip2.DAL.Abstract
{
  public   interface IKullaniciDal:IRepository<Kullanici>
    {
        Kullanici KullaniciGiris(string kullaniciKodu, string Sifre);
    }
}
