using SiparisTakip2.BLL;
using SiparisTakip2.DAL.Concrete.EntityFramework.Repository;
using SiparisTakip2.Entities.Models;
using SiparisTakip2.Interfaces;
using SiparisTakip2.MvcUI.App_Fazlaliklar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SiparisTakip2.MvcUI.Controllers
{
    public class KullaniciController : Controller
    {


        //IKullaniciService kullaniciService = new KullaniciManager(new EFKullaniciDal());

        IKullaniciService kullaniciService;
        IStokService stokService;
        public KullaniciController(IKullaniciService _kullaniciService, IStokService _stokService)
        {
            kullaniciService = _kullaniciService;
        }
        // GET: Kullanici
        public ActionResult KullaniciGiris()
        {
            return View();
        }


        [HttpPost]
        public JsonResult KullaniciGiris(Kullanici entity)
        {
            try
            {
                var kullanici = kullaniciService.KullaniciGiris(entity.KullaniciKodu, entity.Parola);
                if (kullanici != null)
                {
                    //FormsAuthentication.SetAuthCookie(kullanici.KullaniciID.ToString(), false);

                    Session["aktifKullaniciID"] = kullanici.KullaniciID;
                    Session["aktifKullaniciKodu"] = kullanici.KullaniciKodu;
                    Session["aktifKullaniciAdi"] = kullanici.KullaniciAdi + " " + kullanici.KullaniciSoyadi;
                    return Json(new RESULTJSON { Aciklama = "Giriş başarılı", IslemKodu = (int)IslemKodu.Basarili });
                }
                else
                {
                    return Json(new RESULTJSON { Aciklama = "Giriş başarısız", IslemKodu = (int)IslemKodu.Basarisiz });
                }
            }
            catch (Exception err)
            {

                //throw new Exception("Girerken hata oluştu .Bkz : " + err.Message);
                return Json(new RESULTJSON { Aciklama = err.Message, IslemKodu = (int)IslemKodu.SistemselHata });
            }

        }
        public ActionResult OturumCikis()
        {
            //FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}