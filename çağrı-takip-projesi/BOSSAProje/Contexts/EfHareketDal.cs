using BOSSAProje.Contexts.Abstract;
using BOSSAProje.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BOSSAProje.Contexts
{
    public class EfHareketDal : IHareketDal
    {
        public void AddHareket(Hareket hareket)
        {
            using (CihazContext context = new CihazContext())
            {
                var addedEntity = context.Entry(hareket);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();  
            }
        }

        public List<Hareket> GetAll(Expression<Func<Hareket, bool>> filter = null)
        {
            using (CihazContext context = new CihazContext())
            {
                if (filter == null)
                {
                    return context.Set<Hareket>().ToList();
                }
                else
                {
                    return context.Set<Hareket>().Where(filter).ToList();
                }

                //return filter == null ? context.Set<Hareket>().ToList() : context.Set<Hareket>().Where(filter).ToList();
            }
        }
    }
}
