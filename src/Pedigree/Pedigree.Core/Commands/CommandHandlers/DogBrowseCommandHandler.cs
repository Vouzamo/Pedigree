using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Core.Commands.CommandHandlers
{
    public class DogBrowseCommandHandler : BrowseEntityCommandHandler<Dog, DogViewModel>
    {
        public DogBrowseCommandHandler(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }
    }
}
