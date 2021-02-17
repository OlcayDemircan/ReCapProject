﻿using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
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
    public class BrandManager : EntityManagerBase<Brand,ReCapDatabaseContext>
    {
        //IBrandDal _iBrandDal;

        //public BrandManager(IBrandDal iBrandDal)
        //{
        //    _iBrandDal = iBrandDal;
        //}

        //public IResult Add(Brand entity)
        //{
        //    _iBrandDal.Add(entity);
        //    return new SuccessResult(Messages.Added);
        //}

        //public IResult Delete(Brand entity)
        //{
        //    _iBrandDal.Delete(entity);
        //    return new SuccessResult(Messages.Deleted);
        //}

        //public IDataResult<Brand> Get(Expression<Func<Brand, bool>> filter)
        //{
        //    using (ReCapDatabaseContext context = new ReCapDatabaseContext())
        //    {
        //        return new SuccessDataResult<Brand>(context.Set<Brand>().SingleOrDefault(filter));
        //    }
        //}

        //public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        //{
        //    if (DateTime.Now.Hour == 22)
        //    {
        //        return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
        //    }
        //    return new SuccessDataResult<List<Brand>>(_iBrandDal.GetAll(), Messages.Listed);
        //}

        //public IResult Update(Brand entity)
        //{
        //    _iBrandDal.Update(entity);
        //    return new SuccessResult(Messages.Updated);
        //}
    }
}
