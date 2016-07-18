using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.EntityFramework.CommandHandlers;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Core.CommandHandlers
{
    public class DogPostCommandHandler : PostCommandHandler<Dog, DogViewModel>
    {
        public DogPostCommandHandler(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }
    }
}
