using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.Command.Interfaces;

namespace Pedigree.Core.Services
{
    public class PersonService : BasicService<Person, PersonViewModel>, IPersonService
    {
        public PersonService(ICommandDispatcher dispatcher) : base(dispatcher)
        {

        }
    }
}
