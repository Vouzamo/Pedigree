using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using System.Linq;
using Vouzamo.Specification.Interfaces;
using Vouzamo.EntityFramework.Interfaces;

namespace Pedigree.Common.Specifications
{
    public class PersonBrowseSpecificationContainer : IBrowseSpecification<Person, PersonViewModel>
    {
        public IOrderBySpecification<Person> Browse(PersonViewModel model)
        {
            return new PersonBrowseSpecification(model);
        }
    }

    public class PersonBrowseSpecification : IOrderBySpecification<Person>
    {
        public PersonViewModel Filter { get; protected set; }

        public PersonBrowseSpecification(PersonViewModel filter)
        {
            Filter = filter;
        }

        public IOrderedQueryable<Person> SatisfiesMany(IQueryable<Person> queryable)
        {
            return queryable.OrderBy(x => x.Name);
        }
    }
}
