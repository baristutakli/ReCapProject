using Business.Abstract;
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

        public List<Brand> GetAll()
        {
            return _efBrandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            //return _efBrandDal.Get();
            return _efBrandDal.Get(b => b.ID == id);
        }
    }
}
