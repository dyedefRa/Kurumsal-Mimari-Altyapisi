using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SiparisTakip2.MvcUI.App_Fazlaliklar
{
    public class RESULTJSON
    {
        public int IslemKodu { get; set; }
        public string Aciklama { get; set; }
        public object Data { get; set; }
    }


    public enum IslemKodu
    {
        [Description("Başarılı")]
        Basarili = 1,
        [Description("Başarısız")]
        Basarisiz = 2,
        [Description("Hatalı")]
        Hata = 3,
        [Description("Eksik Parametre")]
        EksikParametre = 4,
        [Description("Sistemsel Hata")]
        SistemselHata =5


    }


}

