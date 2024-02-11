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
                             on r.CarId equals car.Id
                             join customer in context.Customers
                             on r.CustomerId equals customer.Id
                             join u in context.Users
                             on customer.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
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
                var updatedRental = context.Rentals.FirstOrDefault(r => r.Id == rentalId);
                updatedRental.ReturnDate = DateTime.Now;
                context.SaveChanges();
            }
        }
    }
}
