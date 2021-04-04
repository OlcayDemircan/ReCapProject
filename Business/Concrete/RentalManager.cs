using Business.Abstract;
using Business.Constant;
using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _iRentalDal;

        public RentalManager(IRentalDal iRentalDal)
        {
            _iRentalDal = iRentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = _iRentalDal.Get(r => r.ReturnDate == rental.ReturnDate);
            if (result==null)
            {
                _iRentalDal.Add(rental);
                Console.WriteLine(Messages.RentalValid);
                return new SuccessResult(Messages.Added);
            }
            else
            {
                Console.WriteLine(Messages.RentalInvalid);
                return new ErrorResult();
            }           
        }

        public IResult Delete(Rental rent)
        {
            _iRentalDal.Delete(rent);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return new SuccessDataResult<Rental>(context.Set<Rental>().SingleOrDefault(filter));
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 4)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_iRentalDal.GetAll(), Messages.Listed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_iRentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _iRentalDal.Update(rental);
            return new SuccessResult(Messages.Updated);
        }

    }
}
