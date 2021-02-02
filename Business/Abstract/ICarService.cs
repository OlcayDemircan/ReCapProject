using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface ICarService
    {
        List<Car> GetAll();

        List<Car> GetById(Car car);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
