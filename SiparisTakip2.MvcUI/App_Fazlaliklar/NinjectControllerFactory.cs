using Ninject;
using SiparisTakip2.BLL;
using SiparisTakip2.DAL.Concrete.EntityFramework.Repository;
using SiparisTakip2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SiparisTakip2.MvcUI.App_Fazlaliklar
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            BllBindingEKLE();
        }

        private void BllBindingEKLE()
        {
            //ControllerFactory artık şunu yapıyor :
            //IKullaniciServic işlem(istendiğinde) yapıldığında
            //KullaniciManager'a gidilecek.
            // ve Manager'in _kullaniciDal Argumanına 
            //EFKullaniciDal'ı verecek.

            ninjectKernel.Bind<IKullaniciService>().To<KullaniciManager>().WithConstructorArgument("_kullaniciDal", new EFKullaniciDal());


            ninjectKernel.Bind<IStokService>().To<StokManager>().WithConstructorArgument("_stokDal", new EFStokDal());

            ninjectKernel.Bind<IFaturaService>().To<FaturaManager>().WithConstructorArgument("_faturaDal", new EFFaturaDal());
        }
        //Global.asax'ta aktifligine yapalım.
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
    }
}