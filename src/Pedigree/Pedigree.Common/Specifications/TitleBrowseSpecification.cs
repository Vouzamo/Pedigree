using System.Linq;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.EntityFramework.Interfaces;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.Common.Specifications
{
    public class TitleBrowseSpecificationContainer : IBrowseSpecification<Title, TitleViewModel>
    {
        public IOrderBySpecification<Title> Browse(TitleViewModel model)
        {
            return new TitleBrowseSpecification(model);
        }
    }

    public class TitleBrowseSpecification : IOrderBySpecification<Title>
    {
        public TitleViewModel Filter { get; protected set; }

        public TitleBrowseSpecification(TitleViewModel filter)
        {
            Filter = filter;
        }

        public IOrderedQueryable<Title> SatisfiesMany(IQueryable<Title> queryable)
        {
            if (Filter.Color != null)
            {
                queryable = queryable.Where(x => x.Color == Filter.Color.Value);
            }

            return queryable.OrderBy(x => x.Name);
        }
    }
}
