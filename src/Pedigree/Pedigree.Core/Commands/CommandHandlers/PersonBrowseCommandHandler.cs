using Microsoft.EntityFrameworkCore;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Core.Commands.CommandHandlers
{
    public class PersonBrowseCommandHandler : BrowseEntityCommandHandler<Person, PersonViewModel>
    {
        public PersonBrowseCommandHandler(IMapper mapper, DbContext context) : base(mapper, context)
        {

        }
    }
}
