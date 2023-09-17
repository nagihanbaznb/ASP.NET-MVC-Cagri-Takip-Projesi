using BOSSAProje.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq.Expressions;

namespace BOSSAProje.Contexts.Abstract
{
    public interface ICihazDal
    {
       public Cihaz Get(Expression<Func<Cihaz, bool>> filter);
          
    }
}
