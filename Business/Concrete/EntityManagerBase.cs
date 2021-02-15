using Business.Abstract;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class EntityManagerBase<TEntity, TContex, TEntityDal> : IServiceRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContex : DbContext, new()
        where TEntityDal : class, IEntityRepository<TEntity>, new()
    {
        EfEntityRepositoryBase<TEntity,TContex> _efEntityRepositoryBase;

        public EntityManagerBase(EfEntityRepositoryBase<TEntity, TContex> efEntityRepositoryBase)
        {
            _efEntityRepositoryBase = efEntityRepositoryBase;
        }

        public void Add(TEntity entity)
        {
            _efEntityRepositoryBase.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _efEntityRepositoryBase.Delete(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContex context = new TContex())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return _efEntityRepositoryBase.GetAll();
        }        
        public void Update(TEntity car)
        {
            _efEntityRepositoryBase.Update(car);
        }
    }
}
