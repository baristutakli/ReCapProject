using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _ICarImageDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _ICarImageDal = rentalDal;       
        }
        public IResult Add(Rental rental)
        {
            if (_ICarImageDal.Get(c=>c.CarID== rental.CarID).ReturnDate<rental.RentDate)
            {
                _ICarImageDal.Add(rental);
                return new SuccessResult(Messages.ProductAdded);
            }
            else
            {
                return new ErrorResult(Messages.ProductAdded);
            }
            
            
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new  SuccessDataResult<List<Rental>>( _ICarImageDal.GetAll());
        }

        public IDataResult<Rental> GetByCarId(int id)
        {
            return new SuccessDataResult<Rental>(_ICarImageDal.Get(r=>r.CarID==id ));
        }

        public IDataResult<Rental> GetByCustomerId(short id)
        {
            return new SuccessDataResult<Rental>(_ICarImageDal.Get(r => r.CustomerID == id));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_ICarImageDal.Get(r => r.ID == id));
        }

        public IDataResult<List<Rental>> GetByRentDate(DateTime rentTime)
        {
            return new SuccessDataResult<List<Rental>>(_ICarImageDal.GetAll(r=> r.RentDate==rentTime));
        }

        public IDataResult<List<Rental>> GetByReturnDate(DateTime returnTime)
        {
            return new SuccessDataResult<List<Rental>>(_ICarImageDal.GetAll(r => r.RentDate == returnTime));
        }

        public IDataResult<List< RentalDetailDto>>GetRentalDetail(int rentalId)
        {
            // Düzenlenecek, parametreli şekilde tekrardan ayzılacak.
            return new SuccessDataResult<List<RentalDetailDto>>(_ICarImageDal.GetRentalDetail(rentalId));
        }
    }
}
