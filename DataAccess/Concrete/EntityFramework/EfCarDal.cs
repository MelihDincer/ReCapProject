using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Context>, ICarDal
    {
        //Araba bilgileri içerisinde brand ve color bilgilerinin Id olarak değil anlamlı bir metin olarak alınıp bilgilerin listelenmesi.
        public List<CarDetailDto> GetCarDetails()
        {
            using (Context context = new Context())
            {
                var result = from car in context.Cars
                             join brand in context.Brands
                             on car.BrandId equals brand.Id
                             join color in context.Colors
                             on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 Id = car.Id,
                                 CarName = car.CarName,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description, 
                                 ModelYear = car.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}