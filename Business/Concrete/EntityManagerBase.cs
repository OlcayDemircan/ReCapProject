using Business.Abstract;
using Business.Constant;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class EntityManagerBase<TEntity,TContext> : IServiceRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
        //where TEntityDal : class, IEntityRepository<TEntity>, new()
    {
        IEntityRepository<TEntity> _iEntityRepository;

        public EntityManagerBase(IEntityRepository<TEntity> iEntityRepository)
        {
            _iEntityRepository = iEntityRepository;
        }


        public IResult Add(TEntity entity)
        {            
            _iEntityRepository.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(TEntity entity)
        {
            _iEntityRepository.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {            
            using (TContext context = new TContext())
            {
                return new SuccessDataResult<TEntity>(context.Set<TEntity>().SingleOrDefault(filter));
            }
        }

        public IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<TEntity>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<TEntity>>(_iEntityRepository.GetAll(), Messages.Listed);
        }

        public IResult Update(TEntity entity)
        {
            _iEntityRepository.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
