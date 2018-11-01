using SiparisTakip2.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip2.Interfaces
{
 public   interface IKullaniciService:IGenericService<Kullanici>
    {
        Kullanici KullaniciGiris(string kullaniciAdi,string parola);
    }
}
