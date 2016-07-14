using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.EntityFramework.CommandHandlers;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Core.Commands.CommandHandlers
{
    public class DogSearchCommandHandler : SearchEntityCommandHandler<Dog, DogViewModel>
    {
        public DogSearchCommandHandler(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }
    }
}
