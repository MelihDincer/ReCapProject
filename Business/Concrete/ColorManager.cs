using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }
        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(b => b.ColorId == id));
        }

        public IResult Add(Color Color)
        {
            if (Color.Name.Length >= 2)
            {
                _colorDal.Add(Color);
                return new SuccessResult(Messages.ColorAdded);
            }
            return new ErrorResult(Messages.ColorNameInvalid);
        }

        public IResult Delete(Color Color)
        {
            _colorDal.Delete(Color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IResult Update(Color Color)
        {
            _colorDal.Update(Color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
