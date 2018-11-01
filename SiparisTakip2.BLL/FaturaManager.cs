using SiparisTakip2.DAL.Abstract;
using SiparisTakip2.Entities.Models;
using SiparisTakip2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip2.BLL
{
    public class FaturaManager : IFaturaService
    {

        private IFaturaDal faturaDal;

        public FaturaManager(IFaturaDal _faturaDal)
        {
            faturaDal = _faturaDal;
        }

        //Burasına dikkat . IFaturaDal da boyle bır ozellık yok.
        public Fatura FaturaRaporu(DateTime baslangic, DateTime bitis)
        {
            return faturaDal.Listele().FirstOrDefault(x => x.FaturaTarihi > baslangic && x.FaturaTarihi < bitis);
        }

        public Fatura Getir(int id)
        {
            return faturaDal.Getir(id);
        }

        public int Guncelle(Fatura entity)
        {
            return faturaDal.Guncelle(entity);
        }

        public Fatura Kaydet(Fatura entity)
        {
            return faturaDal.Kaydet(entity);
        }

        public List<Fatura> Listele()
        {
            return faturaDal.Listele();
        }

        public bool Sil(int id)
        {
            return faturaDal.Sil(id);
        }

        public Fatura Sil(Fatura entity)
        {
            return faturaDal.Sil(entity);
        }
    }
}
