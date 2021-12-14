using Business.Abstract;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        EfCarDal _efCarDal;
        public List<Car> getAll()
        {
            return _efCarDal.GetAll();
        }



        public List<Car> getAllByModelYear(int id)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
           // return _efCarDal.GetByDailyPrice(min, max);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
          //  return _efCarDal.GetCarsByBrandId(id);
        }

        public List<Car> GetCarsByColorId(short id)
        {
            throw new NotImplementedException();
        }
    }
}
