using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.Command.Interfaces;

namespace Pedigree.Core.Services
{
    public class CoatColorService : BasicService<CoatColor, CoatColorViewModel>, ICoatColorService
    {
        public CoatColorService(ICommandDispatcher dispatcher) : base(dispatcher)
        {

        }
    }
}
