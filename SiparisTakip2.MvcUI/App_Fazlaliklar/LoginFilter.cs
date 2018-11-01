using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiparisTakip2.MvcUI.App_Fazlaliklar
{
    //Kişiye özgü satır bazlı yetkilendirilme yapılır.??

    public class LoginFilter : ActionFilterAttribute
    {
        //Burayı dinamik olarak tasarlayabiliriz.
        //Dinamik olarak arguman göndereyim..

        //private string modulAdi;
        //public LoginFilter(string _modulAdi)
        //{
        //    modulAdi = _modulAdi;
        //}
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.HttpContext.Session["aktifKullaniciID"] == null)
            {
                // filterContext.HttpContext.Response.Redirect("/Kullanici/KullaniciGiris");
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "controller", "Kullanici" }, { "action", "KullaniciGiris" } });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}