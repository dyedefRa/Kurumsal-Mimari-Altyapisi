using SiparisTakip2.WebApi.App_Classes.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiparisTakip2.WebApi.App_Classes.Response
{
    public class ResponseExtreme
    {
        public ResponseExtreme()
        {
            this.Status = new Status();
        }
        public Status  Status { get; set; }
        public int etkilenenID { get; set; }
    }
}