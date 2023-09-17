using BOSSAProje.Contexts;
using BOSSAProje.Contexts.Abstract;
using BOSSAProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BOSSAProje.Views.Contexts
{
    public class EfCihazDal:ICihazDal
    {
        public void AddCihaz(Cihaz cihaz)
        {
            using (CihazContext context= new CihazContext())
            {
                var addedEntity = context.Entry(cihaz);
                addedEntity.State=EntityState.Added;
                context.SaveChanges();
            }
        }

        //public List<Cihaz> GetAll(Expression<Func<Cihaz, bool>> filter = null)
        //{
        //    using (CihazContext context = new CihazContext())
        //    {
        //        return filter == null ? context.Set<Cihaz>().ToList() : context.Set<Cihaz>().Where(filter).ToList();
        //    }
        //}

        public List<Cihaz> GetAll(Expression<Func<Cihaz, bool>> filter = null)
        {
            using (CihazContext context = new CihazContext())
            {
                return filter == null ? context.Set<Cihaz>().ToList() : context.Set<Cihaz>().Where(filter).ToList();
            }
        }

        public Cihaz Get(Expression<Func<Cihaz, bool>> filter )
        {
            using (CihazContext context = new CihazContext())
            {
                return context.Set<Cihaz>().SingleOrDefault(filter);

            }
        }
    }
}
