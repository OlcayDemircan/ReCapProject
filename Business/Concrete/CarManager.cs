using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        public IResult Add(Car car)
        {
            _iCarDal.Add(car);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Car car)
        {
            _iCarDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return new SuccessDataResult<Car>(context.Set<Car>().SingleOrDefault(filter));
            }
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_iCarDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(c => c.BrandId == id));
            }
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return new SuccessDataResult<List<Car>>(_iCarDal.GetAll(c => c.ColorId == id));
            }
        }

        public IResult Update(Car car)
        {
            _iCarDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }
    }
}