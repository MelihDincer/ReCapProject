using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
               new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 299, ModelYear = 2023, Description = "Aracımız sıfır km bayi çıkışlı bir araçtır. Keyifli sürüşler dileriz..." },
               new Car { Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 189, ModelYear = 2020, Description = "Aracımız size konforlu sürüş deneyimi yaşatabilecek bir araçtır. Keyifli sürüşler dileriz..." },
               new Car { Id = 3, BrandId = 3, ColorId = 3, DailyPrice = 260, ModelYear = 2022, Description = "Aracımız sıfıra yakın bakımlı bir araçtır. Keyifli sürüşler dileriz..." },
               new Car { Id = 4, BrandId = 4, ColorId = 4, DailyPrice = 326, ModelYear = 2023, Description = "Aracımız size gerçek bir SUV sürüşü yaşatacaktır. Keyifli sürüşler dileriz..." },
               new Car { Id = 5, BrandId = 5, ColorId = 5, DailyPrice = 300, ModelYear = 2021, Description = "Aracımız tam donanımlı bir offroad aracıdır. Sizi yarı yolda bırakmayacaktır. Keyifli sürüşler dileriz..." },
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var value = _cars.SingleOrDefault(c => c.Id == car.Id); //silinecek değeri bul.
            _cars.Remove(value);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.Id == carId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id); //güncellenecek değeri bul.
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
