using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip2.DAL.Abstract
{
    public interface IRepository<T> where T : class
    {
        T Kaydet(T entity);
        List<T> Listele();
        T Getir(int id);
        int Guncelle(T entity);
        bool Sil(int id);
        T Sil(T entity);
        T Getir(Expression<Func<T, bool>> expression);
        List<T> Listele(Expression<Func<T, bool>> expression);
    }
}
