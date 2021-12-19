using Core.Utilities.Results;
using Entities.Concrete;
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
        IDataResult<List<Rental>> GetByCustomerId(short id);
        IDataResult<List<Rental>> GetByCarId(int id);
        IDataResult<List<Rental>> GetByRentDate(DateTime time);
        IDataResult<List<Rental>> GetByReturnDate(DateTime time);
        //IDataResult<List<RentalDetailDto>> GetProductDetail();
        IResult Add(Rental Rental);
    }

  
}

