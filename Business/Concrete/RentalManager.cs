using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var rentACar = _rentalDal.Get(r => r.CarId == rental.CarId);
            if (rentACar == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else if(rentACar != null)
            {
                if (rentACar.CarId == rental.CarId && rentACar.ReturnDate == null)
                {
                    return new ErrorResult(Messages.RentalInvalid);
                }
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else
            {
                return new ErrorResult(Messages.RentalInvalid);
            }
        }

        public IResult CarDeliver(int rentalId)
        {
            var rental = _rentalDal.Get(r=>r.RentalId ==  rentalId);
            if(rental != null)
            {
                _rentalDal.CarDeliver(rentalId);
                return new SuccessResult(Messages.CarDeliver);
            }
            else
            {
                return new ErrorResult(Messages.CarDeliverEmpty);
            }
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == carId));
        }

        public IDataResult<Rental> GetByCustomerId(int customerId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CustomerId == customerId));

        }

        public IDataResult<Rental> GetByRentalId(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.CarId == rentalId));

        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(),Messages.RentalsListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
