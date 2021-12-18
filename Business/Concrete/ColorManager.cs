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
    public class ColorManager : IColorService
    {
        EfColorDal _efColorDal;

        public ColorManager(EfColorDal efColorDal)
        {
            _efColorDal = efColorDal;
        }

        public List<Color> GetAll()
        {
            throw new NotImplementedException();
        }

        public Color GetById(int id)
        {
            return _efColorDal.Get(c => c.ID == id);
        }
    }
}
