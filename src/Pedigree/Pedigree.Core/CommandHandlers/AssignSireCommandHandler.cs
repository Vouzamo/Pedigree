using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using System;
using Microsoft.EntityFrameworkCore;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Command.Interfaces;
using Pedigree.Core.Commands;
using Vouzamo.EntityFramework;

namespace Pedigree.Core.CommandHandlers
{
    public class AssignSireCommandHandler : Modify<Guid, Dog, DogViewModel>, ICommandHandler<AssignSireCommand, IResponse<DogViewModel>>
    {
        public AssignSireCommandHandler(IMapper mapper, DbContext context) : base(mapper, context, x => (Guid)x.SireId)
        {

        }

        public IResponse<DogViewModel> Handle(AssignSireCommand command)
        {
            return Invoke(command);
        }
    }
}
