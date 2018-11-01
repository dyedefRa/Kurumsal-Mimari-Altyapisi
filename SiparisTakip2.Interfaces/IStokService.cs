using SiparisTakip2.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip2.Interfaces
{
    public interface IStokService : IGenericService<Stok>
    {
        List<Stok> ilkxStokGetir(int x);
    }
}
