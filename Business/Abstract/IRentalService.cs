using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        IDataResult<Rental> GetByCustomerId(short id);
        IDataResult<Rental> GetByCarId(int id);
        IDataResult<List<Rental>> GetByRentDate(DateTime rentTime);
        IDataResult<List<Rental>> GetByReturnDate(DateTime returnTime);
        IDataResult<List<RentalDetailDto>> GetRentalDetail();
        IDataResult<RentalDetailDto> GetRentalDetailById(int userId);
        IResult Add(Rental rental);
    }

  
}

