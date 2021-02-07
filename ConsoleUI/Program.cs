using Business;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarDal efCarDal = new EfCarDal();
            ICarService carManager = new CarManager(efCarDal);

            Car car1 = new Car() { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2013, DailyPrice = 400, Description = "Fiat 500L" };
            Car car2 = new Car() { Id = 2, BrandId = 2, ColorId = 2, ModelYear = 2013, DailyPrice = 350, Description = "Opel Corsa" };
            Car car3 = new Car() { Id = 3, BrandId = 3, ColorId = 1, ModelYear = 2007, DailyPrice = 200, Description = "Renault Megane" };
            Car car4 = new Car() { Id = 4, BrandId = 4, ColorId = 3, ModelYear = 2019, DailyPrice = 900, Description = "Peugeot 3008" };
            Car car5 = new Car() { Id = 5, BrandId = 2, ColorId = 1, ModelYear = 2018, DailyPrice = 700, Description = "Opel Insignia" };
            Car car6 = new Car() { Id = 6, BrandId = 1, ColorId = 2, ModelYear = 2020, DailyPrice = 500, Description = "Fiat Egea" };
            //DatabaseFill(carManager, car1, car2, car3, car4, car5, car6);
            Console.WriteLine("---------------Tüm Kayıtlar-----------------------------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("---------------Brand ID'ye göre Filtreleme-----------------------------");

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("----------------Color ID'ye göre Filtreleme----------------------");

            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine(@"----------------Yeni Giriş Denemesi (Hatalı\ DailyPrice > 0 Hatası)----------------------");

            carManager.Add(new Car() { Id = 7, BrandId = 3, ColorId = 3, ModelYear = 2014, DailyPrice = 0, Description = "Renault Clio" });

            Console.WriteLine(@"----------------Yeni Giriş Denemesi (Hatalı\ Description en az 2 karater olmalı Hatası)----------------------");

            carManager.Add(new Car() { Id = 7, BrandId = 3, ColorId = 3, ModelYear = 2014, DailyPrice = 400, Description = "R" });

        }

        private static void DatabaseFill(ICarService carManager, Car car1, Car car2, Car car3, Car car4, Car car5, Car car6)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Tüm araçların veritabanına kaydedilmesi");

            List<Car> cars = new List<Car> { car1, car2, car3, car4, car5, car6 };
            int i = 1;
            foreach (var car in cars)
            {
                Console.WriteLine(i + ". araç kaydı yapıldı" + car.Description);
                carManager.Add(car);
                i = i + 1;
            }
        }
    }
}
