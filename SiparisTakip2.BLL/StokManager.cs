using SiparisTakip2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiparisTakip2.Entities.Models;
using SiparisTakip2.DAL.Abstract;

namespace SiparisTakip2.BLL
{
    public class StokManager : IStokService
    {

        private IStokDal stokDal;
        public StokManager(IStokDal _stokDal)
        {
            stokDal = _stokDal;
        }
        public Stok Getir(int id)
        {
            return stokDal.Getir(id);
        }

        public int Guncelle(Stok entity)
        {
            return stokDal.Guncelle(entity);
        }

        //ONEMLII
        public List<Stok> ilkxStokGetir(int x)
        {
            return stokDal.Listele().OrderBy(y => y.StokID).Take(x).ToList();
        }

        public Stok Kaydet(Stok entity)
        {
            return stokDal.Kaydet(entity);
        }

        public List<Stok> Listele()
        {
            return stokDal.Listele();
        }

        public bool Sil(int id)
        {
            return stokDal.Sil(id);
        }

        public Stok Sil(Stok entity)
        {
            return stokDal.Sil(entity);
        }
    }
}
