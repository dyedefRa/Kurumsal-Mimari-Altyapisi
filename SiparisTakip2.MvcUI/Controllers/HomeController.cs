using SiparisTakip2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiparisTakip2.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        IStokService stokService;
        IFaturaService faturaService;

        public HomeController(IStokService _stokService, IFaturaService _faturaService)
        {
            faturaService = _faturaService;
            stokService = _stokService;
        }
        // GET: Home
        public ActionResult Index()
        {
            var model = stokService.Listele();
            return View(model);
        }

     
    }
}