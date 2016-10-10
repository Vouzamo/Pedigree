using Microsoft.AspNetCore.Mvc;
using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;

namespace Pedigree.App.Controllers
{
    [Route("api/coatcolor")]
    public class CoatColorApiController : BasicApiController<CoatColor, CoatColorViewModel, ICoatColorService>
    {
        public CoatColorApiController(ICoatColorService service) : base(service)
        {

        }
    }
}
