using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> Get(Expression<Func<Color, bool>> filter);
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
    }
}
