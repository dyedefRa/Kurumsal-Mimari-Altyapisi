using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiparisTakip2.MvcUI.App_Fazlaliklar
{
    //BUNU KULLANMADIM
    [JsonObject(MemberSerialization.OptIn)]
    public class ProcessResultModel
    {
        public ProcessResultModel(int islemKodu,string baslik,string aciklama,string aciklamaDetay,object data)
        {
            this.IslemKodu = islemKodu;
            this.Aciklama = aciklama;
            this.AciklamaDetay = aciklamaDetay;
            this.Data = Data;
        }

        public ProcessResultModel(IslemKodu islemSonucKodu,string aciklama="",string aciklamaDetay="",object data=null)
        {

            this.IslemKodu = (int)islemSonucKodu;
            this.Aciklama = aciklama;
            this.AciklamaDetay = aciklamaDetay;
            this.Data = Data;
        }

        [JsonProperty]
        public int IslemKodu { get; set; }
        [JsonProperty]
        public string Baslik { get; set; }
        [JsonProperty]
        public string Aciklama { get; set; }
        [JsonProperty]
        public string AciklamaDetay { get; set; }
        [JsonProperty]
        public object Data { get; set; }

    }
}