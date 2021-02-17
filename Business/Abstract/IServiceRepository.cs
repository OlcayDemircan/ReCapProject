using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IServiceRepository<T> where T:class, IEntity, new()
    {
        IDataResult<List<T>> GetAll(Expression<Func<T, bool>> filter=null);
        IDataResult<T> Get(Expression<Func<T, bool>> filter);
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}
