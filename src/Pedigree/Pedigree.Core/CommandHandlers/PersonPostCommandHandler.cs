using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.EntityFramework.CommandHandlers;
using Microsoft.EntityFrameworkCore;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Core.CommandHandlers
{
    public class PersonPostCommandHandler : PostCommandHandler<Person, PersonViewModel>
    {
        public PersonPostCommandHandler(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }
    }
}
