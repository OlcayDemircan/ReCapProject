using Business.Concrete;
using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            EfCarImageDal efCarImageDal = new EfCarImageDal();
            CarImageManager carImageManager = new CarImageManager(efCarImageDal);

            CarImage carImage1 = new CarImage() { CarId = 1, };

            //carImageManager.Add(@"..\WebAPI\Images\", carImage1);






        }



    }
}
