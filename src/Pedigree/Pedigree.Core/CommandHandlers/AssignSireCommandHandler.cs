using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using System;
using Vouzamo.EntityFramework.CommandHandlers;
using Microsoft.EntityFrameworkCore;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Command.Interfaces;
using Pedigree.Core.Commands;

namespace Pedigree.Core.CommandHandlers
{
    public class AssignSireCommandHandler : ModifyEntity<Guid, Dog, DogViewModel>, ICommandHandler<AssignSireCommand, IResponse<DogViewModel>>
    {
        public AssignSireCommandHandler(IMapper mapper, DbContext context) : base(mapper, context, x => (Guid)x.SireId)
        {

        }

        public IResponse<DogViewModel> Handle(AssignSireCommand command)
        {
            return Modify(command);
        }
    }
}
