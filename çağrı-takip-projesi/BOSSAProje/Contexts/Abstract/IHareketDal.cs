using BOSSAProje.Models;
using System.Linq.Expressions;

namespace BOSSAProje.Contexts.Abstract
{
    public interface IHareketDal
    {
        public void AddHareket(Hareket hareket);
        List<Hareket> GetAll(Expression<Func<Hareket, bool>> filter = null);
    }
}
