using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.EntityFramework.CommandHandlers;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Specification.Interfaces;
using Pedigree.Common.Specifications;

namespace Pedigree.Core.CommandHandlers
{
    public class PersonBrowseCommandHandler : BrowseEntityCommandHandler<Person, PersonViewModel>
    {
        public PersonBrowseCommandHandler(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }

        public override IOrderBySpecification<Person> Specification(PersonViewModel model)
        {
            return new PersonBrowseSpecification(model);
        }
    }
}
