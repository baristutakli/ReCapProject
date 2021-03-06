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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            if (color.Name.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(short id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ID == id));
        }

        public IResult Update(Color color)
        {
            try
            {
                _colorDal.Update(color);
            }
            catch (Exception)
            {

                return new ErrorResult();
            }

            return new SuccessResult();
        }
    }
}
