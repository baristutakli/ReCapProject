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
    public class BrandManager : IBrandService
    {
        EfBrandDal _efBrandDal;

        public BrandManager(EfBrandDal efBrandDal)
        {
           _efBrandDal = efBrandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _efBrandDal.Add(brand);
            return new SuccessResult(Messages.ProductAdded);
            
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_efBrandDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            //return _efBrandDal.Get();
            return new SuccessDataResult<Brand>(_efBrandDal.Get(b => b.ID == id));
        }
    }
}
