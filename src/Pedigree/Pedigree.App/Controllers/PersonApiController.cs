using Microsoft.AspNetCore.Mvc;
using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;

namespace Pedigree.App.Controllers
{
    [Route("api/person")]
    public class PersonApiController : BasicApiController<Person, PersonViewModel, IPersonService>
    {
        public PersonApiController(IPersonService service) : base(service)
        {

        }
    }
}
