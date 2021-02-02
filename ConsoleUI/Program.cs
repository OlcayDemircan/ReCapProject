using Business;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarDal inMemoryCarDal = new InMemoryCarDal();
            ICarService carManager = new CarManager(inMemoryCarDal);

            Car car1 = new Car()
            {
                Id = 6,
                BrandId = 4,
                ColorId = 2,
                ModelYear = 2014,
                DailyPrice = 385,
                Description = "Peugeot 307"
            };

            Console.WriteLine("Hiç bir Business seviyesi kod çalıştırılmadan önce 'GetAll' ile gelen liste");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId+" | "+car.Description+" | "+car.ModelYear+" | "+car.DailyPrice);
            }

            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("BrandId 4 olan yeni bir araç eklendikten sonra ");

            carManager.Add(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId + " | " + car.Description + " | " + car.ModelYear + " | " + car.DailyPrice);
            }

            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("WW Passat Silinir");

            carManager.Delete(new Car() {Id = 2});

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId + " | " + car.Description + " | " + car.ModelYear + " | " + car.DailyPrice);
            }

            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Peugeot 307 Renault Megane Olarak Değiştirilir");

            carManager.Update(new Car() { Id = 6, BrandId = 5, ColorId = 1, DailyPrice = 580, Description = "Renault Megane", ModelYear = 2016 });

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId + " | " + car.Description + " | " + car.ModelYear + " | " + car.DailyPrice);
            }

        }
    }
}
