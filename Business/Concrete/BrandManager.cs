using Business.Abstract;
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

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(p => p.Id == id);
        }

        public void Insert(Brand entity)
        {
            if (entity.Name.Length >= 2)
            {
                _brandDal.Add(entity);
            }
            else
            {
                Console.WriteLine("Renk ismi minimum 2 karakter olmalıdır.");
            }
        }

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
        }
    }
}
