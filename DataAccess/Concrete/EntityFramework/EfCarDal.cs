using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join cn in context.Colors
                             on c.BrandId equals cn.Id

                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = b.Id,
                                 ColorId = cn.Id,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = cn.ColorName,
                                 ModelYear = c.ModelYear,                                 
                                 DailyPrice = c.DailyPrice,
                                 
                             };
                return result.ToList();
            }
        }
    }
}

