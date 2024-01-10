using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> TGetAll();
        List<Car> TGetById(int carId);
        void TAdd(Car car);
        void TDelete(Car car);
        void TUpdate(Car car);
    }
}
