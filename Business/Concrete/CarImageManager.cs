using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        
        public IResult Delete(CarImage entity)
        {
            FileHelper.Delete(entity.ImagePath);
            _carImageDal.Delete(entity);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == id));
        }


        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
        }


        public IResult Insert(IFormFile file, CarImage entity)
        {
            IResult result = BusinessRules.Run(CheckIfPictureLimitExceded(entity.CarId));

            if (result != null)
            {
                return result;
            }

            entity.ImagePath = FileHelper.Add(file);
            entity.Date = DateTime.Now;
            entity.ImagePath = entity.ImagePath.Substring(101);

            _carImageDal.Add(entity);
            return new SuccessResult(Messages.CarImageAdded);
        }

        
        public IResult Update(IFormFile file, CarImage entity)
        {
            entity.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.Id == entity.Id).ImagePath, file);
            entity.Date = DateTime.Now;
            entity.ImagePath = entity.ImagePath.Substring(101);

            _carImageDal.Update(entity);
            return new SuccessResult();
        }



        private IResult CheckIfPictureLimitExceded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;

            if (result >= 5)
            {
                return new ErrorResult(Messages.PictureLimitExceded);
            }

            return new SuccessResult();
        }

        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\logo.png";

            var result = _carImageDal.GetAll(c => c.CarId == id).Any();

            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }

            return _carImageDal.GetAll(p => p.CarId == id);
        }

        
    }
}
