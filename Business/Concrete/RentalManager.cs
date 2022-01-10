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
        IRentalDal _IRentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _IRentalDal = rentalDal;       
        }
        public IResult Add(Rental rental)
        {
            if (_IRentalDal.Get(c=>c.CarID== rental.CarID).ReturnDate<rental.RentDate)
            {
                _IRentalDal.Add(rental);
                return new SuccessResult(Messages.ProductAdded);
            }
            else
            {
                return new ErrorResult(Messages.ProductAdded);
            }
            
            
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new  SuccessDataResult<List<Rental>>( _IRentalDal.GetAll());
        }

        public IDataResult<Rental> GetByCarId(int id)
        {
            return new SuccessDataResult<Rental>(_IRentalDal.Get(r=>r.CarID==id ));
        }

        public IDataResult<Rental> GetByCustomerId(short id)
        {
            return new SuccessDataResult<Rental>(_IRentalDal.Get(r => r.CustomerID == id));
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_IRentalDal.Get(r => r.ID == id));
        }

        public IDataResult<List<Rental>> GetByRentDate(DateTime rentTime)
        {
            return new SuccessDataResult<List<Rental>>(_IRentalDal.GetAll(r=> r.RentDate==rentTime));
        }

        public IDataResult<List<Rental>> GetByReturnDate(DateTime returnTime)
        {
            return new SuccessDataResult<List<Rental>>(_IRentalDal.GetAll(r => r.RentDate == returnTime));
        }

        public IDataResult<List< RentalDetailDto>>GetRentalDetail()
        {
            // Düzenlenecek, parametreli şekilde tekrardan ayzılacak.
            return new SuccessDataResult<List<RentalDetailDto>>(_IRentalDal.GetRentalDetail());
        }
        public IDataResult<RentalDetailDto> GetRentalDetailById(int userId)
        {
            return new SuccessDataResult<RentalDetailDto>(_IRentalDal.GetRentalDetailById(userId));
        }

    }
}
