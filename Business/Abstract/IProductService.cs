﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Car> getAll();
        List<Car> getAllByBrand(int id);
        List<Car> getAllByColor(int id);
        List<Car> getAllByModelYear(int id);
        List<Car> getByDailyPrice(decimal min, decimal max);
    }
}
