using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SiparisTakip2.WebApi.App_Classes.Attribute
{
    public class Status
    {
        public int statusCode { get; set; }
        public string Message { get; set; }
    }
    public enum MessageCode
    {
        [Description("İşlem Başarılı")]
        Basarili = 100,
        [Description("İşlem Başarısız")]
        Basarisiz =200,
        [Description("Sistemsel Hata/ Parametre hatası oluştu.")]
        Hata =300,
        [Description("TC no uyumsuzluğu.")]
        TCNoUyumsuzlugu =333,
        [Description("Erişim yok.Oturum bilgisi hatası.")]
        OturumHatasi=444,
        [Description("İşlem Başarılı .Böyle bir kayıt yok.")]
        KayitYok=555
    }

}