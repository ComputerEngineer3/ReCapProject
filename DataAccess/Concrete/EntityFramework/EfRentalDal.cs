using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : IRentalDal
    {
        public void Add(Rental entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Rental entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Rental Get(Expression<Func<Rental, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Set<Rental>().SingleOrDefault(filter);
            }
        }

        public List<Rental> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return filter == null
                    ? context.Set<Rental>().ToList()
                    : context.Set<Rental>().Where(filter).ToList();
            }
        }

        public void Update(Rental entity)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
