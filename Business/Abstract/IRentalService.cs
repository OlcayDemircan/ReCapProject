using Core.Utilities.Results;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService 
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
