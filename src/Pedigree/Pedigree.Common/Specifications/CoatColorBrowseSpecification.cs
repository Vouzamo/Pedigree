using System.Linq;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.EntityFramework.Interfaces;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.Common.Specifications
{
    public class CoatColorBrowseSpecificationContainer : IBrowseSpecification<CoatColor, CoatColorViewModel>
    {
        public IOrderBySpecification<CoatColor> Browse(CoatColorViewModel model)
        {
            return new CoatColorBrowseSpecification(model);
        }
    }

    public class CoatColorBrowseSpecification : IOrderBySpecification<CoatColor>
    {
        public CoatColorViewModel Filter { get; protected set; }

        public CoatColorBrowseSpecification(CoatColorViewModel filter)
        {
            Filter = filter;
        }

        public IOrderedQueryable<CoatColor> SatisfiesMany(IQueryable<CoatColor> queryable)
        {
            return queryable.OrderBy(x => x.Name);
        }
    }
}
