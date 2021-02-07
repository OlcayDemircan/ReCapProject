using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>() {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=450, ModelYear = 2015, Description="Opel Astra"},
                new Car{Id=2, BrandId=2, ColorId=2, DailyPrice=500, ModelYear = 2017, Description="WW Passat"},
                new Car{Id=3, BrandId=3, ColorId=1, DailyPrice=1000, ModelYear = 2019, Description="Volvo S60"},
                new Car{Id=4, BrandId=2, ColorId=3, DailyPrice=450, ModelYear = 2018, Description="WW Jetta"},
                new Car{Id=5, BrandId=1, ColorId=1, DailyPrice=600, ModelYear = 2016, Description="Opel Insignia"}
            };   
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(Car car)
        {
            return _cars.Where(c => c.Id == car.Id).ToList();
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
