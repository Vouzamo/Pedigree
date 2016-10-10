using Microsoft.AspNetCore.Mvc;
using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;

namespace Pedigree.App.Controllers
{
    [Route("api/title")]
    public class TitleApiController : BasicApiController<Title, TitleViewModel, ITitleService>
    {
        public TitleApiController(ITitleService service) : base(service)
        {

        }
    }
}
