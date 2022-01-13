using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal IBrandDal)
        {
           _brandDal = IBrandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length < 2)// Bu kısmı validation ile kontrol edeceğiz
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.ProductAdded);
            
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            //return _brandDal.Get();
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.ID == id));
        }

        public IResult Update(Brand brand)
        {
            try
            {
                _brandDal.Update(brand);
            }
            catch (Exception)
            {

                return new ErrorResult();
            }
            
            return new SuccessResult();
        }

        
    }
}
