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

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        EfProductDal _efProductDal;
        public List<Car> GetAll()
        {
            return _efProductDal.GetAll();
        }



        public List<Car> GetAllByModelYear(string year)
        {
            return _efProductDal.GetAll(p => p.ModelYear == year);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            // return _efCarDal.GetByDailyPrice(min, max);
            return _efProductDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice >= max);
        }

        public Car GetById(int id)
        {
            return _efProductDal.Get(p => p.Id == id);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            //  return _efCarDal.GetCarsByBrandId(id);
            return _efProductDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(short id)
        {
            return _efProductDal.GetAll(p => p.ColorID == id);
        }

        public List<ProductDetailDto> GetProductDetail()
        {
            return _efProductDal.GetProductDetail();
        }
    }
}
