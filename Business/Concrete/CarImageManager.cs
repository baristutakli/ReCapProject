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
    public class CarImageManager : ICarImageService
    {
        EfCarImageDal _efCarImageDal;
        public IResult Add(CarImage carImage)
        {
            if (carImage.ID>0)
            {
                _efCarImageDal.Add(carImage);
                return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult();
        }

        public IResult Delete(CarImage carImage)
        {
            if (_efCarImageDal.Get(c=>c.ID==carImage.ID)!=null)
            {
                _efCarImageDal.Delete(carImage);
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_efCarImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_efCarImageDal.GetAll(c=>c.CarID ==id));
        }

        public IDataResult<List<CarImage>> GetByDate(DateTime dateTime)
        {
            return new SuccessDataResult<List<CarImage>>(_efCarImageDal.GetAll(c => c.Date.Year == dateTime.Year));
        }

        public IDataResult<List<CarImage>> GetById(int id)
        {

            return new SuccessDataResult<List<CarImage>>(_efCarImageDal.GetAll(c => c.ID == id));
        }

        public IResult Update(CarImage carImage)
        {
            _efCarImageDal.Update(carImage);
            return new SuccessResult();
        }
    }
}
