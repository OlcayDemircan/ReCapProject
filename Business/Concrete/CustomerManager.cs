using Business.Abstract;
using Business.Constant;
using Core.DataAccess;
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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _iCustomerDal;

        public CustomerManager(ICustomerDal iCustomerDal)
        {
            _iCustomerDal = iCustomerDal;
        }

        public IResult Add(Customer customer)
        {
            _iCustomerDal.Add(customer);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customer customer)
        {
            _iCustomerDal.Delete(customer);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return new SuccessDataResult<Customer>(context.Set<Customer>().SingleOrDefault(filter));
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_iCustomerDal.GetAll(), Messages.Listed);
        }

        public IResult Update(Customer entity)
        {
            _iCustomerDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

    }
}
