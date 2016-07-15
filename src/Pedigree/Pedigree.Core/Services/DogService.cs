using System;
using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.Command.Interfaces;
using Vouzamo.Interop.Interfaces;
using Vouzamo.EntityFramework.Commands;

namespace Pedigree.Core.Services
{
    public class DogService : BasicService<Dog, DogViewModel>, IDogService
    {
        public DogService(ICommandDispatcher dispatcher) : base(dispatcher)
        {

        }

        public IResponse<DogViewModel> Rename(Guid id, string name)
        {
            var command = new ModifyEntityCommand<string, DogViewModel>(id, name);

            var result = Dispatcher.Invoke(command);

            return result;
        }
    }
}
