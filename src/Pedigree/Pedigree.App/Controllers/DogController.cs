using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.Specifications;
using Pedigree.Common.ViewModels;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.App.Controllers
{
    public class DogController : BasicController<Dog, DogViewModel, IDogService>
    {
        public DogController(IDogService service) : base(service)
        {
            
        }

        protected override IOrderBySpecification<Dog> BrowseSpecification(DogViewModel filter)
        {
            return new DogBrowseSpecification(filter);
        }
    }
}
