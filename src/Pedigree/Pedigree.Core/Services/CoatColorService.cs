using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.Specifications;
using Pedigree.Common.ViewModels;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Specification;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.Core.Services
{
    public class CoatColorService : BasicService<CoatColor, CoatColorViewModel>, ICoatColorService
    {
        public CoatColorService(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }

        public override IOrderBySpecification<CoatColor> BrowseSpecification(CoatColorViewModel filter)
        {
            return new CoatColorBrowseSpecification(filter);
        }

        public override IOrderBySpecification<CoatColor> SearchSpecification(string term)
        {
            return new BasicSearchSpecification<CoatColor>(term).OrderBy(x => x.Name);
        }
    }
}
