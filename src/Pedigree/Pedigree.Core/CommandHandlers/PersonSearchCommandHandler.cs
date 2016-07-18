using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Models;
using Pedigree.Common.Specifications;
using Pedigree.Common.ViewModels;
using Vouzamo.EntityFramework.CommandHandlers;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Specification;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.Core.CommandHandlers
{
    public class PersonSearchCommandHandler : SearchCommandHandler<Person, PersonViewModel>
    {
        public PersonSearchCommandHandler(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }

        public override IOrderBySpecification<Person> Specification(string term)
        {
            return new BasicSearchSpecification<Person>(term).OrderBy(x => x.Name);
        }
    }
}
