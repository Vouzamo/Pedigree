using System;
using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.Specifications;
using Pedigree.Common.ViewModels;
using Vouzamo.Command.Interfaces;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Specification;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.Core.Services
{
    public class TitleService : BasicService<Title, TitleViewModel>, ITitleService
    {
        public TitleService(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }

        public override IOrderBySpecification<Title> BrowseSpecification(TitleViewModel filter)
        {
            return new TitleBrowseSpecification(filter);
        }

        public override IOrderBySpecification<Title> SearchSpecification(string term)
        {
            return new BasicSearchSpecification<Title>(term).OrderBy(x => x.Name);
        }
    }
}
