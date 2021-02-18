using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _iColorDal;

        public ColorManager(IColorDal iColorDal)
        {
            _iColorDal = iColorDal;
        }

        public IResult Add(Color entity)
        {
            _iColorDal.Add(entity);

            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Color entity)
        {
            _iColorDal.Delete(entity);

            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Color> Get(Expression<Func<Color, bool>> filter)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return new SuccessDataResult<Color>(context.Set<Color>().SingleOrDefault(filter));
            }
        }

        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_iColorDal.GetAll(), Messages.Listed);
        }

        public IResult Update(Color entity)
        {
            _iColorDal.Update(entity);

            return new SuccessResult(Messages.Updated);
        }
    }
}