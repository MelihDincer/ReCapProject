
using Core.Utilities;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetByRentalId(int rentalId);
        IDataResult<Rental> GetByCarId(int carId);
        IDataResult<Rental> GetByCustomerId(int customerId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IResult CarDeliver(int rentalId);
    }
}
