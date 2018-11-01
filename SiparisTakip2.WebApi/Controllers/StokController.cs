using SiparisTakip2.BLL;
using SiparisTakip2.DAL.Concrete.EntityFramework.Repository;
using SiparisTakip2.Entities.Models;
using SiparisTakip2.Interfaces;
using SiparisTakip2.WebApi.App_Classes.Attribute;
using SiparisTakip2.WebApi.App_Classes.Request;
using SiparisTakip2.WebApi.App_Classes.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;



//Gelen requesti nesne olarak yakalamak için [FromBody] dememiz gerek parametrenin önüne..
namespace SiparisTakip2.WebApi.Controllers
{
    [RoutePrefix("StokApi")]
    public class StokController : ApiController
    {
        IStokService stokService = new StokManager(new EFStokDal());

        #region SerilizeEtmeMetodları
        public StokSeri StokAlStokSeriDon(Stok temp)
        {
            return ClassConverter.Convert<Stok, StokSeri>(temp);

        }
        public Stok StokSeriAlStokDon(StokSeri temp)
        {
            return ClassConverter.Convert<StokSeri, Stok>(temp);

        }
        #endregion
        //Request için=>
        //Herhangi bir metodun parametre sınıfının ıcınde OturumBilgisi olması gerek
        //Ekle sıl guncelle ıcın  aldıgı parametresınde O sınıfı a it property olması gerek => public Stok stok {get;set;}
        //Response için ise ;
        //Listele ve Getir için  oluşturduğum classların ıcınde propert olarak List<T> olması gerek ve tabıkı statusCode de olması gerek
        //ve herhangi bir metodun Response sinde StatusCode olması gerek

            //BU METOD POST CUNKU ARGUMAN OLARKA PARAMETRE ALMIYOR ...
            //DIREK YOLLANILMASI GEREKEN BIR NESNE ALIYOR
        [HttpPost]
        [Route("Getir")]
        public StokListeleyadaGetir Listele(RequestListeleveGetir temp)
        {//STOK TIPI DONDEREMIYORUM OYUZDEN StokSer donderecegım

            StokListeleyadaGetir donecek = new StokListeleyadaGetir();
            donecek.Status = new Status();


            try
            {
                //stokun içinde oturumbilgisi ozelliklerine bakıyoruz.Sonucta her onune gelen buraya gırmesın.
                if (temp.oturumBilgisi.userName == "admin" && temp.oturumBilgisi.Password == "1234")
                {
                    //Gelen Id=0 iste tüm listeyi donder
                    if (temp.IdVer == 0)
                    {
                        List<StokSeri> serilizeEdilmisStokListesi = new List<StokSeri>();
                        foreach (var stok in stokService.Listele())
                        {
                            serilizeEdilmisStokListesi.Add(StokAlStokSeriDon(stok));
                        }
                        donecek.GenericListe = serilizeEdilmisStokListesi;
                        donecek.Status.statusCode = (int)MessageCode.Basarili;
                        donecek.Status.Message = ClassConverter.GetDescription(MessageCode.Basarili);
                    }
                    else
                    {//Gelen Id==0 degılse bak oyle bır nesne varsa onu donder yoksa hat aver
                        var gosterilecekTekliStok = stokService.Getir(temp.IdVer);
                        if (gosterilecekTekliStok != null)
                        {
                            //Tek bir StokSeri donderecegız. 
                            //Donecek nesnesının ıcındeki GenericListe ye eşitelememız lazım. Tek nesneye listele esıtlenmıyor. Bu sekılde cozdum.
                            List<StokSeri> tekStokLiteyeesitlenmedii = new List<StokSeri>();
                            tekStokLiteyeesitlenmedii.Add(StokAlStokSeriDon(gosterilecekTekliStok));
                            donecek.GenericListe = tekStokLiteyeesitlenmedii;
                            donecek.Status.statusCode = (int)MessageCode.Basarili;
                            donecek.Status.Message = ClassConverter.GetDescription(MessageCode.Basarili);
                        }
                        else
                        {// Bu id li kayıt yok.
                            donecek.Status.statusCode = (int)MessageCode.KayitYok;
                            donecek.Status.Message = ClassConverter.GetDescription(MessageCode.KayitYok);
                        }
                    }


                  
                }
                else
                {
                    //OturumBilgisi Hatasi
                    donecek.Status.statusCode = (int)MessageCode.OturumHatasi;
                    donecek.Status.Message = ClassConverter.GetDescription(MessageCode.OturumHatasi);

                }


            }
            catch (Exception ex)
            {
                //Sistemsel Hata
                donecek.Status.statusCode = (int)MessageCode.Hata;
                donecek.Status.Message = ClassConverter.GetDescription(MessageCode.Hata) + " " + ex.Message;


            }
            return donecek;




        }
       

        [Route("Kaydet")]
        [HttpPost]
        public ResponseExtreme StokKaydet([FromBody]StokRequest stok)
        {
            ResponseExtreme donecek = new ResponseExtreme();

            try
            {
                //stokun içinde oturumbilgisi ozelliklerine bakıyoruz.Sonucta her onune gelen buraya gırmesın.
                if (stok.oturumBilgisi.userName == "admin" && stok.oturumBilgisi.Password == "1234")
                {
                    //Burada Serilize olabılmesı ıcın Stokseri <-> Stok donusumu yapmamız gerek
                    var StokSeriSinifiniStokaCevirme = StokSeriAlStokDon(stok.GenericRequest);
                    //StokService.Add Stok tipi alıyor.Stok sınıfı serilize degıl ve parametreden StokSeri odnuyor. Stokserıyı Stoka cevırdım.
                    var eklenecekStok = stokService.Kaydet(StokSeriSinifiniStokaCevirme);
                    if (eklenecekStok != null)
                    {
                        donecek.etkilenenID = stok.GenericRequest.StokID;
                        donecek.Status.statusCode = (int)MessageCode.Basarili;
                        donecek.Status.Message = ClassConverter.GetDescription(MessageCode.Basarili);
                    }
                    else
                    {
                        //Eklenme Olayi olmadıysa
                        donecek.Status.statusCode = (int)MessageCode.Basarisiz;
                        donecek.Status.Message = ClassConverter.GetDescription(MessageCode.Basarisiz);
                    }
                }
                else
                {
                    //OturumBilgisi Hatasi
                    donecek.Status.statusCode = (int)MessageCode.OturumHatasi;
                    donecek.Status.Message = ClassConverter.GetDescription(MessageCode.OturumHatasi);

                }


            }
            catch (Exception ex)
            {
                //Sistemsel Hata
                donecek.Status.statusCode = (int)MessageCode.Hata;
                donecek.Status.Message = ClassConverter.GetDescription(MessageCode.Hata) + " " + ex.Message;


            }
            return donecek;


        }

        //FidlerdaEkleyePostMetoduylaVeriAtalim

        //        {
        //"oturumBilgisi":{
        //"userName":"SELAM",
        //"password":"12345"
        //},
        //"GenericRequest":{
        //"StokID":1,
        //"BarkodNo":3,
        //"StokKodu":435,
        //"StokAdi":"zaaa"
        //}
        //}

        //3795 stokid


        //HAZIR RESPONSELAR
        public HttpResponseMessage Salla()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "OKEYYYYY");
        }
        public IHttpActionResult Salla2()
        {
            return Ok("AKAKGAKGA");

        }
    }
}
