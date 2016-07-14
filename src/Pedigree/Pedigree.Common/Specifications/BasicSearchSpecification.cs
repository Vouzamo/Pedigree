using Pedigree.Common.Interfaces;
using Vouzamo.Specification;

namespace Pedigree.Common.Specifications
{
    public class BasicSearchSpecification<T> : WhereSpecification<T> where T : IBasicEntity
    {
        public BasicSearchSpecification(string term)
        {
            Predicate = x => x.Name.Contains(term);
        }
    }
}
