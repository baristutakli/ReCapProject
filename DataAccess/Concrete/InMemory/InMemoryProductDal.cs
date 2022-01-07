using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryProductDal()
        {
            _cars = new List<Car> { 
                new Car { Id = 1, BrandId = 2, ColorID = 1, DailyPrice = 100, ModelYear = "1990", Description = "Old" },
            new Car { Id = 2, BrandId = 2, ColorID = 1, DailyPrice = 200, ModelYear = "1995", Description = "Old" },
            new Car { Id = 3, BrandId = 3, ColorID = 2, DailyPrice = 1000, ModelYear = "2010", Description = "Old" },
            new Car { Id = 4, BrandId = 3, ColorID = 2, DailyPrice = 500, ModelYear = "200", Description = "Old" },
            new Car { Id = 5, BrandId = 4, ColorID = 3, DailyPrice = 1500, ModelYear = "2019", Description = "new" },
            new Car { Id = 6, BrandId = 5, ColorID = 3, DailyPrice = 1100, ModelYear = "2014", Description = "new" },

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);

            //throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
            //throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
           // throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            
            return _cars.SingleOrDefault(p => p.Id == id);
            //throw new NotImplementedException();
        }

        public List<CarDetailDto> GetProductDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate =  _cars.SingleOrDefault(c => c.Id == car.Id); 
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;

           // throw new NotImplementedException();
        }
    }
}
