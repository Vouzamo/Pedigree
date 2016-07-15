using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;

namespace Pedigree.App.Controllers
{
    public class PersonController : BasicController<Person, PersonViewModel, IPersonService>
    {
        public PersonController(IPersonService service) : base(service)
        {

        }
    }
}
