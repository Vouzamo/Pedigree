using Pedigree.Common.Models;
using Vouzamo.Specification;
using System.Linq;
using Vouzamo.Specification.Interfaces;
using Pedigree.Common.ViewModels;
using Vouzamo.EntityFramework.Interfaces;

namespace Pedigree.Common.Specifications
{
    public class DogBrowseSpecificationContainer : IBrowseSpecification<Dog, DogViewModel>
    {
        public IOrderBySpecification<Dog> Browse(DogViewModel model)
        {
            return new DogBrowseSpecification(model);
        }
    }

    public class DogBrowseSpecification : IOrderBySpecification<Dog>
    {
        public DogViewModel Filter { get; protected set; }

        public DogBrowseSpecification(DogViewModel filter)
        {
            Filter = filter;
        }

        public IOrderedQueryable<Dog> SatisfiesMany(IQueryable<Dog> queryable)
        {
            if(Filter.Sex.HasValue)
            {
                queryable = queryable.Where(x => x.Sex == Filter.Sex.Value);
            }

            if(Filter.SireId.HasValue)
            {
                queryable = queryable.Where(x => x.SireId == Filter.SireId.Value);
            }

            if(Filter.DamId.HasValue)
            {
                queryable = queryable.Where(x => x.DamId == Filter.DamId.Value);
            }

            return queryable.OrderBy(x => x.Name);
        }
    }
}
