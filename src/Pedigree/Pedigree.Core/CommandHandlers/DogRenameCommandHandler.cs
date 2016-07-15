using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.EntityFramework.CommandHandlers;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Core.CommandHandlers
{
    public class DogRenameCommandHandler : ModifyEntityCommandHandler<string, Dog, DogViewModel>
    {
        public DogRenameCommandHandler(IMapper mapper, DbContext context) : base(mapper, context, x => x.Name)
        {
            
        }
    }
}
