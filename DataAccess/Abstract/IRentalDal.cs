using Core.DataAccess;
using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
        void CarDeliver(int rentalId);
    }
}
