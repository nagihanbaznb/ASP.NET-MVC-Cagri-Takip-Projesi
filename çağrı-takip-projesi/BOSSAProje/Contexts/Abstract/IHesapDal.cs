using BOSSAProje.Models;
using System.Linq.Expressions;

namespace BOSSAProje.Contexts.Abstract
{
    public interface IHesapDal
    {
        public void AddHareket(Hesap hesap);
        public Hesap Get(Expression<Func<Hesap, bool>> filter);
        List<Hesap> GetAll(Expression<Func<Hesap, bool>> filter = null);
    }
}
