using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        //Bir arabaya ait resimleri listeleme imkanı oluşturunuz. (Liste)
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            List<CarImage> images = _carImageDal.GetAll(c => c.CarId == carId);
            IResult result = BusinessRules.Run(CheckIfCarImage(carId));
            if(result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
            }
            return new SuccessDataResult<List<CarImage>>(images);
        }
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CountByCarId(carImage));
            if (result != null)
            {
                return result;
            }
            string guid = _fileHelper.Add(file);
            carImage.ImagePath = guid;
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ImageUploaded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            _fileHelper.Delete(carImage.ImagePath!);
            return new SuccessResult(Messages.ImageDeleted);
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            _fileHelper.Update(file, carImage.ImagePath!);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessDataResult<CarImage>(carImage);
        }

        private IResult CountByCarId(CarImage carImage)
        {
            if (_carImageDal.GetAll(c => c.CarId == carImage.CarId).Count >= 5)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }
            else
            {
                return new SuccessResult();
            }
        }

        private IResult CheckIfCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId == carId).Count();
            if(result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "DefaultImage.png" });
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
    }
}