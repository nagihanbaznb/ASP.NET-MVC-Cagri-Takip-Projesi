using BOSSAProje.Contexts.Abstract;
using BOSSAProje.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BOSSAProje.Contexts
{
    public class EfHesapDal : IHesapDal
    {
        public void AddHareket(Hesap hesap)
        {
            using (CihazContext context = new CihazContext())
            {
                var addedEntity = context.Entry(hesap);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();  
            }
        }

        public List<Hesap> GetAll(Expression<Func<Hesap, bool>> filter = null)
        {
            using (CihazContext context = new CihazContext())
            {
                if (filter == null)
                {
                    return context.Set<Hesap>().ToList();
                }
                else
                {
                    return context.Set<Hesap>().Where(filter).ToList();
                }

                //return filter == null ? context.Set<Hareket>().ToList() : context.Set<Hareket>().Where(filter).ToList();
            }
        }

        public Hesap Get(Expression<Func<Hesap, bool>> filter)
        {
            using (CihazContext context = new CihazContext())
            {
                return context.Set<Hesap>().SingleOrDefault(filter);

            }
        }
    }
}
