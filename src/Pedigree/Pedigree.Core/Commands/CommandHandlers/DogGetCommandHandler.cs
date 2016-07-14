using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.EntityFramework.CommandHandlers;
using Microsoft.EntityFrameworkCore;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Core.Commands.CommandHandlers
{
    public class DogGetCommandHandler : GetEntityCommandHandler<Dog, DogViewModel>
    {
        public DogGetCommandHandler(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }
    }
}
