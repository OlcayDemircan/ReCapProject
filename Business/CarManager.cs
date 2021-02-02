using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class CarManager : ICarService
    {
        ICarDal _iCarDal;

        public CarManager(ICarDal iCarDal)
        {
            _iCarDal = iCarDal;
        }

        public void Add(Car car)
        {
            _iCarDal.Add(car);
        }

        public void Delete(Car car)
        {
            _iCarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _iCarDal.GetAll();
        }

        public List<Car> GetById(Car car)
        {
            return _iCarDal.GetById(car);
        }

        public void Update(Car car)
        {
            _iCarDal.Update(car);
        }
    }
}
