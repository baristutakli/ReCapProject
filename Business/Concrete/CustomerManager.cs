using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _ICustomerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _ICustomerDal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            try
            {
                _ICustomerDal.Add(customer);
            }
            catch (Exception)
            {

                return new ErrorResult();
            }
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_ICustomerDal.GetAll());
        }

        public IDataResult<Customer> GetByCompanyName(string companyName)
        {
            return new SuccessDataResult<Customer>(_ICustomerDal.Get(c => c.CompanyName == companyName));
        }

        public IDataResult<Customer> GetByUserID(int id)
        {
            return new SuccessDataResult<Customer>(_ICustomerDal.Get(c => c.UserID==id));
        }
    }
}
