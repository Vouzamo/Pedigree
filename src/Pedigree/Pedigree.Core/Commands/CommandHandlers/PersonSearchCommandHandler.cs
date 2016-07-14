using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.EntityFramework.CommandHandlers;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Core.Commands.CommandHandlers
{
    public class PersonSearchCommandHandler : SearchEntityCommandHandler<Person, PersonViewModel>
    {
        public PersonSearchCommandHandler(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }
    }
}
