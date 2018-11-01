using SiparisTakip2.MvcUI.App_Fazlaliklar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiparisTakip2.MvcUI.Controllers
{
    [LoginFilter]
    public class StokController : Controller
    {
        // GET: Stok
        public ActionResult Index()
        {
            return View();
        }
        //[Authorize]
        //[LoginFilter("Kullanici")]
        public ActionResult Selam()
        {
            return View();
        }

    }
}