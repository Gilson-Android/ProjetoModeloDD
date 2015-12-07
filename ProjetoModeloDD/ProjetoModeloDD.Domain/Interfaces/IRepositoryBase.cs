using System;
using System.Collections;
using System.Linq.Expressions;

namespace ProjetoModeloDD.Domain.Interfaces
{
    //Recebe sempre um entidade onde seja sempre uma classe
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity Get(Expression<Func<TEntity, Boolean>> filtro_);
        IEnumerable GetAll(Expression<Func<TEntity, Boolean>> filtro_);
        void Update(TEntity obj);
        void Remover(TEntity obj);

        void Dispose();
    }
}
