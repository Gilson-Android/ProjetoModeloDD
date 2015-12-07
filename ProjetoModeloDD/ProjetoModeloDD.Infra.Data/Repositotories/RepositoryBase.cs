using System;
using System.Collections;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ProjetoModeloDD.Domain.Interfaces;
using ProjetoModeloDD.Infra.Data.Context;

namespace ProjetoModeloDD.Infra.Data.Repositotories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class 
    {
        protected ProjetoModeloContext projetoModeloContext_ = new ProjetoModeloContext();

        public void Add(TEntity obj)
        {
            projetoModeloContext_.Set<TEntity>().Add(obj);
            projetoModeloContext_.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filtro_)
        {
            return projetoModeloContext_.Set<TEntity>().Find(filtro_);
        }

        public IEnumerable GetAll(Expression<Func<TEntity, bool>> filtro_)
        {
            return projetoModeloContext_.Set<TEntity>().Where(filtro_).ToList();
        }

        public void Update(TEntity obj)
        {
            projetoModeloContext_.Entry(obj).State = EntityState.Modified;
            projetoModeloContext_.SaveChanges();
        }

        public void Remover(TEntity obj)
        {
            projetoModeloContext_.Set<TEntity>().Remove(obj);
            projetoModeloContext_.SaveChanges();
        }

        void IRepositoryBase<TEntity>.Dispose()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
