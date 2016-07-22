using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Pedigree.Core.Commands;
using Vouzamo.Command.Interfaces;
using Vouzamo.EntityFramework;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Core.CommandHandlers
{
    public class DogRenameCommandHandler : Modify<string, Dog, DogViewModel>, ICommandHandler<DogRenameCommand, IResponse<DogViewModel>>
    {
        public DogRenameCommandHandler(IMapper mapper, DbContext context) : base(mapper, context, x => x.Name)
        {
            
        }

        public IResponse<DogViewModel> Handle(DogRenameCommand command)
        {
            return Invoke(command);
        }
    }
}
