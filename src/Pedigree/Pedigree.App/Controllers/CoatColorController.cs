using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;

namespace Pedigree.App.Controllers
{
    public class CoatColorController : BasicController<CoatColor, CoatColorViewModel, ICoatColorService>
    {
        public CoatColorController(ICoatColorService service) : base(service)
        {

        }
    }
}
