﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        EfUserDal _efUserDal;
        public UserManager(EfUserDal efUserDal)
        {
            _efUserDal = efUserDal;
        }
        public IResult Add(User user)
        {
            // Business control operations goes here.
            _efUserDal.Add(user);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_efUserDal.GetAll());
        }

        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_efUserDal.Get(u=>u.ID==id));
        }

        public IDataResult<User> GetUsersByEmail(string email)
        {
            return new SuccessDataResult<User>(_efUserDal.Get(u=>u.Email==email));
        }
    }
}
