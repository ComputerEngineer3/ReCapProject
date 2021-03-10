using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            return new SuccessResult(Messages.ColorDeleted);
        }


        //key, value
        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }



        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.Id == id));
        }


        [SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand entity)
        {
            /*if (entity.Name.Length >= 2)
            {
                _brandDal.Add(entity);
                return new SuccessResult(Messages.BrandAdded);
            }
            else
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }*/

            //ValidationTool.Validate(new BrandValidator(),entity);

            _brandDal.Add(entity);
            return new SuccessResult(Messages.BrandAdded);
        }



        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccessResult(Messages.BrandUpdated);
        }



        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
