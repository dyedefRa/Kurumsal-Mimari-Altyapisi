using SiparisTakip2.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip2.DAL.Concrete.EntityFramework.Repository
{
    public class Repository<TT> : IRepository<TT> where TT : class
    {
        private readonly SiparisTakipContext ctx = new SiparisTakipContext();

        private DbSet<TT> _objectSet;

        public Repository()
        {
            _objectSet = ctx.Set<TT>();
        }


        public List<TT> Listele(Expression<Func<TT, bool>> expression)
        {
            return _objectSet.Where(expression).ToList();
        }

        public TT Getir(int id)
        {
         return   _objectSet.Find(id);
        }

        public int Guncelle(TT entity)
        {
            _objectSet.AddOrUpdate(entity);
            return ctx.SaveChanges();
        }

        public TT Kaydet(TT entity)
        {
        
                _objectSet.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public List<TT> Listele()
        {
            return _objectSet.AsNoTracking().ToList();
        }

        public bool Sil(int id)
        {
            _objectSet.Remove(Getir(id));
            return ctx.SaveChanges() > 0;
        }

        public TT Sil(TT entity)
        {
            _objectSet.Remove(entity);
            ctx.SaveChanges();
            return entity;
        }

        public TT Getir(Expression<Func<TT, bool>> expression)
        {
            return _objectSet.FirstOrDefault(expression);
        }
    }
}
