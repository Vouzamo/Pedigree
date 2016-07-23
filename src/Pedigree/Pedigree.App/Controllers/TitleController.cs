using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;

namespace Pedigree.App.Controllers
{
    public class TitleController : BasicController<Title, TitleViewModel, ITitleService>
    {
        public TitleController(ITitleService service) : base(service)
        {

        }
    }
}
