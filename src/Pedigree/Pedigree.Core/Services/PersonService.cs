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
    public class PersonService : BasicService<Person, PersonViewModel>, IPersonService
    {
        public PersonService(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }

        public override IOrderBySpecification<Person> BrowseSpecification(PersonViewModel filter)
        {
            return new PersonBrowseSpecification(filter);
        }

        public override IOrderBySpecification<Person> SearchSpecification(string term)
        {
            return new BasicSearchSpecification<Person>(term).OrderBy(x => x.Name);
        }
    }
}
