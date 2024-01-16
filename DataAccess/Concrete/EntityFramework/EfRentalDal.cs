using Core.DataAccess.EntityFramework;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, Context>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (var context = new Context())
            {
                var result = from r in context.Rentals
                             join car in context.Cars
                             on r.CarId equals car.CarId
                             join customer in context.Customers
                             on r.CustomerId equals customer.CustomerId
                             join u in context.Users
                             on customer.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = r.CarId,
                                 CarName = car.CarName,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                             };
                return result.ToList();
            }

        }
        public void CarDeliver(int rentalId)
        {
            using (var context = new Context())
            {
                var updatedRental = context.Rentals.FirstOrDefault(r => r.RentalId == rentalId);
                updatedRental.ReturnDate = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
