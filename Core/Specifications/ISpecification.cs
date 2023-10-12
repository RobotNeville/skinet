using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public interface ISpecification<T> 
    {
        Expression<Func<T,bool>> Criteria{get;} //"Where" criteria
        List<Expression<Func<T,object>>> Includes {get;}


    }
}