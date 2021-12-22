using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ECommerceContext>, ICarDal
    {

        public  List<CarDetailDto> GetProductDetail() {
            using (ECommerceContext context = new ECommerceContext())
            {
                var result = from p in context.Cars
                             join c in context.Colors
                             on p.ColorID equals c.ID
                             join b in context.Brands
                             on p.BrandId equals b.ID
                             select new CarDetailDto { CarId = p.Id, BrandName = b.Name, ColorName = c.Name, DailyPrice = p.DailyPrice };
                return result.ToList();

            }
        }

    }
      
}
