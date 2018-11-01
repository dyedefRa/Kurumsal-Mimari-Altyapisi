using SiparisTakip2.WebApi.App_Classes.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiparisTakip2.WebApi.App_Classes.Request
{
    public class RequestListeleveGetir
    {
        //Bu metod Sadece Listeleme ve Getir/5 e gore ıslem yapıcak.
        //StokRequest gibi parametre olarak Stok Sınıfı almayacak.
        public OturumBilgisi   oturumBilgisi { get; set; }
        public int IdVer { get; set; }
        //IdVer = 0 olursa Hepsini Listelesin
        //IdVer in degerli Stokun degerıne esıtse o stoku getırsın
    }
}