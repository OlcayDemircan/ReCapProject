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
    public class ColorManager : IColorService
    {
        IColorDal _iColorDal;

        public ColorManager(IColorDal iColorDal)
        {
            _iColorDal = iColorDal;
        }

        public void Add(Color entity)
        {
            _iColorDal.Add(entity);
        }

        public void Delete(Color entity)
        {
            _iColorDal.Delete(entity);
        }

        public Color Get(Expression<Func<Color, bool>> filter)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return context.Set<Color>().SingleOrDefault(filter);
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return _iColorDal.GetAll();
        }

        public void Update(Color entity)
        {
            _iColorDal.Update(entity);
        }
    }
}
