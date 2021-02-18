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
    public class UserManager :  IUserService
    {
        IUserDal _iUserDal;

        public UserManager(IUserDal iUserDal)
        {
            _iUserDal = iUserDal;
        }

        public IResult Add(User entity)
        {
            _iUserDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User entity)
        {
            _iUserDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return new SuccessDataResult<User>(context.Set<User>().SingleOrDefault(filter));
            }
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<User>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<User>>(_iUserDal.GetAll(), Messages.Listed);
        }

        public IResult Update(User entity)
        {
            _iUserDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }

    }

}
