using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.Specification.Interfaces;
using Pedigree.Common.Specifications;

namespace Pedigree.App.Controllers
{
    public class PersonController : BasicController<Person, PersonViewModel, IPersonService>
    {
        public PersonController(IPersonService service) : base(service)
        {

        }

        protected override IOrderBySpecification<Person> BrowseSpecification(PersonViewModel filter)
        {
            return new PersonBrowseSpecification(filter);
        }
    }
}
