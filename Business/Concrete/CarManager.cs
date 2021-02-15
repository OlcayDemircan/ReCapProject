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

        public void Add(Car entity)
        {
            _iCarDal.Add(entity);
        }

        public void Delete(Car entity)
        {
            _iCarDal.Delete(entity);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _iCarDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _iCarDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return _iCarDal.GetAll(c => c.BrandId == id);
            }
        }

        public List<Car> GetCarsByColorId(int id)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return _iCarDal.GetAll(c => c.ColorId == id);
            }
        }

        public void Update(Car entity)
        {
            _iCarDal.Update(entity);
        }
    }
}
