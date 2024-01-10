using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void TAdd(Car car)
        {
            _carDal.Add(car);
        }

        public void TDelete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> TGetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> TGetById(int carId)
        {
            return _carDal.GetById(carId).ToList();
        }

        public void TUpdate(Car car)
        {
            _carDal.Update(car);
        }
    }
}
