using Pedigree.Common.ViewModels;
using Microsoft.EntityFrameworkCore;
using Vouzamo.Interop.Interfaces;
using Vouzamo.Command.Interfaces;
using Pedigree.Core.Commands;
using System;
using Pedigree.Common.Models;
using Vouzamo.EntityFramework;

namespace Pedigree.Core.CommandHandlers
{
    public class AssignDamCommandHandler : Modify<Guid, Dog, DogViewModel>, ICommandHandler<AssignDamCommand, IResponse<DogViewModel>>
    {
        protected readonly IMapper _mapper;
        protected readonly DbContext _context;

        public AssignDamCommandHandler(IMapper mapper, DbContext context) : base(mapper, context, x => (Guid)x.SireId)
        {
            _mapper = mapper;
            _context = context;
        }

        public IResponse<DogViewModel> Handle(AssignDamCommand command)
        {
            return Invoke(command);
        }
    }
}
