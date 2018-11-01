using SiparisTakip2.MvcUI.App_Fazlaliklar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SiparisTakip2.MvcUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Eklenti ****
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
        }
    }
}
