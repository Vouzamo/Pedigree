using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.EntityFramework.CommandHandlers;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Specification.Interfaces;
using Pedigree.Common.Specifications;

namespace Pedigree.Core.CommandHandlers
{
    public class DogBrowseCommandHandler : BrowseCommandHandler<Dog, DogViewModel>
    {
        public DogBrowseCommandHandler(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }

        public override IOrderBySpecification<Dog> Specification(DogViewModel model)
        {
            return new DogBrowseSpecification(model);
        }
    }
}
