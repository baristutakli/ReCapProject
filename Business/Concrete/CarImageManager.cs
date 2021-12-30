using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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
        IFileHelper _fileHelper;
        public CarImageManager(EfCarImageDal carImageDal, IFileHelper fileHelper)
        {
            _efCarImageDal = carImageDal;
            _fileHelper = fileHelper;
        }
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimitExceded(carImage.CarID));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _efCarImageDal.Add(carImage);
            return new SuccessResult("Resim başarıyla yüklendi");
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _efCarImageDal.Delete(carImage);
            return new SuccessResult();
        }
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);
            _efCarImageDal.Update(carImage);
            return new SuccessResult();
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

  
        private IResult CheckIfCarImageLimitExceded(int carID)
        {
            var result = _efCarImageDal.GetAll(c => c.CarID == carID).Count;
            if (result>5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
