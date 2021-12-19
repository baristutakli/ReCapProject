using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        EfProductDal _efProductDal;

        public IResult Add(Car car)
        {
            if (car.Id<1)
            {
                
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _efProductDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Car>> GetAll()
        {
            // Business code goes here. For instance,
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_efProductDal.GetAll(),Messages.ProductListed);
        }



        public IDataResult<List<Car>> GetAllByModelYear(string year)
        {
            return  new SuccessDataResult<List<Car>>(_efProductDal.GetAll(p => p.ModelYear == year));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            // return _efCarDal.GetByDailyPrice(min, max);
            return new SuccessDataResult<List<Car>>(_efProductDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice >= max));
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_efProductDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            //  return _efCarDal.GetCarsByBrandId(id);
            return new SuccessDataResult<List<Car>>(_efProductDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(short id)
        {
            return new SuccessDataResult<List<Car>>(_efProductDal.GetAll(p => p.ColorID == id));
        }

        public IDataResult<List<CarDetailDto>> GetProductDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_efProductDal.GetProductDetail());
        }
    }
}
