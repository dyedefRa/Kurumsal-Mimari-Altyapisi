using SiparisTakip2.WebApi.App_Classes.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiparisTakip2.WebApi.App_Classes.Request
{
    public class IBaseRequest<T> where T:class
    {
        
      public OturumBilgisi oturumBilgisi { get; set; }
        public T GenericRequest { get; set; }
        
    }
}