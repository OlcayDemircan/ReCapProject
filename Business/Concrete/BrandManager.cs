using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _iBrandDal;

        public BrandManager(IBrandDal iBrandDal)
        {
            _iBrandDal = iBrandDal;
        }

        public void Add(Brand entity)
        {
            _iBrandDal.Add(entity);
        }

        public void Delete(Brand entity)
        {
            _iBrandDal.Delete(entity);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return context.Set<Brand>().SingleOrDefault(filter);
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return _iBrandDal.GetAll();
        }   
        
        public void Update(Brand entity)
        {
            _iBrandDal.Update(entity);
        }
    }
}
