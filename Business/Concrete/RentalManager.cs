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
            return new  SuccessDataResult<List<Rental>>( _efRentalDal.GetAll());
        }

        public IDataResult<Rental> GetByCarId(int id)
        {
            return new SuccessDataResult<Rental>(_efRentalDal.Get(r=>r.CarID==id ));
        }

        public IDataResult<Rental> GetByCustomerId(short id)
        {
            return new SuccessDataResult<Rental>(_efRentalDal.Get(r => r.CustomerID == id));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_efRentalDal.Get(r => r.ID == id));
        }

        public IDataResult<List<Rental>> GetByRentDate(DateTime rentTime)
        {
            return new SuccessDataResult<List<Rental>>(_efRentalDal.GetAll(r=> r.RentDate==rentTime));
        }

        public IDataResult<List<Rental>> GetByReturnDate(DateTime returnTime)
        {
            return new SuccessDataResult<List<Rental>>(_efRentalDal.GetAll(r => r.RentDate == returnTime));
        }
    }
}
