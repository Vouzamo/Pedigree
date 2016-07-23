using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.Command.Interfaces;

namespace Pedigree.Core.Services
{
    public class TitleService : BasicService<Title, TitleViewModel>, ITitleService
    {
        public TitleService(ICommandDispatcher dispatcher) : base(dispatcher)
        {

        }
    }
}
