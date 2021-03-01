using Business.Abstract;
using Business.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers;
using Core.Utilities.Business;
using DataAccess.Concrete.EntityFramework;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        string imagePath = @"..\WebAPI\Images\";
        string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".bmp" };

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckNumberOfCarImages(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = imagePath + FileHelper.GenerateGUIDFileName(file, 20);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete( CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            using (ReCapDatabaseContext context = new ReCapDatabaseContext())
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(ci => ci.CarId == id));
            }
            
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckNumberOfCarImages(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count();
            if (result==5)
            {
                return new ErrorResult(Messages.CarHasAlreadyFiveImages);
            }
            return new SuccessResult();
        }
    }
}
