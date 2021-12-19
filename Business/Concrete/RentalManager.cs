using Business.Abstract;
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
    public class RentalManager : IRentalService
    {
        EfRentalDal _efRentalDal;
        public IResult Add(Rental rental)
        {
            if (_efRentalDal.Get(c=>c.CarID== rental.CarID).ReturnDate<rental.RentDate)
            {
                _efRentalDal.Add(rental);
                return new SuccessResult(Messages.ProductAdded);
            }
            else
            {
                return new ErrorResult(Messages.ProductAdded);
            }
            
            
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetByCarId(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetByCustomerId(short id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetByRentDate(DateTime rentTime)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetByReturnDate(DateTime returnTime)
        {
            throw new NotImplementedException();
        }
    }
}
