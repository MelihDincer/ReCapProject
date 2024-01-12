using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandDal _brandDal;
        IColorDal _colorDal;

        public CarManager(ICarDal carDal, IBrandDal brandDal, IColorDal colorDal)
        {
            _carDal = carDal;
            _brandDal = brandDal;
            _colorDal = colorDal;
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.Id == carId);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId).ToList();
        }

        public void TAdd(Car car)
        {
            var result = from c in _carDal.GetAll()
                         join brand in _brandDal.GetAll()
                         on c.BrandId equals brand.Id
                         join color in _colorDal.GetAll()
                         on c.ColorId equals color.Id
                         select new CarDto { Id = c.Id, BrandName = brand.Name, ColorName = color.Name, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear, Description = c.Description };

            string carName = result.Where(x => x.Id == car.Id).Select(y => y.BrandName).ToString();

            if (carName.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                if (carName.Length < 2)
                {
                    throw new Exception("Yeni araç eklenememiştir. Araç ismi minimum 2 karakterden oluşmalıdır.");
                }
                else if (car.DailyPrice < 0)
                {
                    throw new Exception("Yeni araç eklenememiştir. Günlük fiyat 0'dan büyük olmalıdır.");
                }
                else
                {
                    throw new Exception("Belirlenen şartlar haricinde bir hata oluştu.");
                }

            }

        }

        public void TDelete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> TGetAll()
        {
            return _carDal.GetAll();
        }

        public void TUpdate(Car car)
        {
            _carDal.Update(car);
        }
    }
}
