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
    public class ColorManager : IColorService
    {
        EfColorDal _efColorDal;

        public ColorManager(EfColorDal efColorDal)
        {
            _efColorDal = efColorDal;
        }

        public IResult Add(Color color)
        {
            if (color.Name.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _efColorDal.Add(color);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_efColorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_efColorDal.Get(c => c.ID == id));
        }
    }
}
