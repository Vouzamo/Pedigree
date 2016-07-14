using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.Command.Interfaces;

namespace Pedigree.Core.Services
{
    public class DogService : BasicService<Dog, DogViewModel>, IDogService
    {
        public DogService(ICommandDispatcher dispatcher) : base(dispatcher)
        {

        }
    }
}
