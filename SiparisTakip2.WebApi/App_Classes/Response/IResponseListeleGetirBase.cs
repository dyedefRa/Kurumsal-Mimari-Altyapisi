using SiparisTakip2.WebApi.App_Classes.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip2.WebApi.App_Classes.Response
{
  public  class IResponseListeleGetirBase<T>
    {
        //Bu metod Listele ve Getir için Response gorevını ustelenecel
        //Listele ve Getir metodlarının donus tıpı bu olacak.
        //Cunku Ikısındede StatusCode ve Stok sınıfı veya Listesi donecek
     public    Status Status { get; set; }
     public    List<T> GenericListe { get; set; }
    }
}
