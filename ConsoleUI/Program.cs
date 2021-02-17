using Business;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            EfBrandDal efBrandDal = new EfBrandDal();
            BrandManager brandManager = new BrandManager(efBrandDal);

            EfCarDal efCarDal = new EfCarDal();
            CarManager carManager = new CarManager(efCarDal);

            EfColorDal efColorDal = new EfColorDal();
            ColorManager colorManager = new ColorManager(efColorDal);

            //Car GetAll Test
            //CarGetAll(carManager);

            //Car GetCarsByBrandId Test
            //CarGetCarsByBrandId(carManager);

            Brand brand1 = new Brand();
            Brand brand2 = new Brand();
            Brand brand3 = new Brand();
            Brand brand4 = new Brand();
            Brand brand5 = new Brand();
            brand1.Id = 1; brand1.BrandName = "Fiat";
            brand2.Id = 2; brand2.BrandName = "Opel";
            brand3.Id = 3; brand3.BrandName = "Renault";
            brand4.Id = 4; brand4.BrandName = "Peugeot";
            
                        
            Color color1 = new Color();
            Color color2 = new Color();
            Color color3 = new Color();
            Color color4 = new Color();
            color1.Id = 1; color1.ColorName = "Siyah";
            color2.Id = 2; color2.ColorName = "Beyaz";
            color3.Id = 3; color3.ColorName = "Kırmızı";

            //Color Insert
            //ColorInsert(colorManager, color1, color2, color3);

            //List Cars with properties from different tables
            //ListCarsDueToDetails(carManager);

            

        }

        //private static void ListCarsDueToDetails(CarManager carManager)
        //{
        //    foreach (var car in carManager.GetCarDetails)
        //    {
        //        Console.WriteLine("CarName : " + car.Description + " | BrandName : " + car.BrandName + " | ColorName : " + car.ColorName +
        //                            " | DailyPrice : " + car.DailyPrice);
        //    }
        //}

        private static void ColorInsert(ColorManager colorManager, Color color1, Color color2, Color color3)
        {
            Color[] colors = new Color[] { color1, color2, color3 };

            foreach (var color in colors)
            {
                colorManager.Add(color);
            }
        }

       

        //private static void CarGetCarsByBrandId(CarManager carManager)
        //{
        //    int id = 1; //Id filtresinin girişi

        //    foreach (var car in carManager.GetCarsByBrandId(id))
        //    {
        //        Console.WriteLine("CarId : " + car.Id + " | BrandId : " + car.BrandId + " | ColorId : " + car.ColorId +
        //                            " | ModelYear : " + car.ModelYear + " | Description : " + car.Description + " | DailyPrice : " + car.DailyPrice);
        //    }
        //}

        //private static void CarGetAll(CarManager carManager)
        //{
        //    foreach (var car in carManager.GetAll())
        //    {
        //        Console.WriteLine("CarId : " + car.Id + " | BrandId : " + car.BrandId + " | ColorId : " + car.ColorId +
        //                            " | ModelYear : " + car.ModelYear + " | Description : " + car.Description + " | DailyPrice : " + car.DailyPrice);
        //    }
        //}

    }
}
