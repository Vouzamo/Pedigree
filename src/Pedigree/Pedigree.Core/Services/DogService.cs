using System;
using Pedigree.Common.Interfaces;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using Vouzamo.Command.Interfaces;
using Vouzamo.Interop.Interfaces;
using Pedigree.Core.Commands;

namespace Pedigree.Core.Services
{
    public class DogService : BasicService<Dog, DogViewModel>, IDogService
    {
        public DogService(ICommandDispatcher dispatcher) : base(dispatcher)
        {

        }

        public IResponse<DogViewModel> Rename(Guid id, string name)
        {
            var command = new DogRenameCommand(id, name);

            var result = Dispatcher.Invoke(command);

            return result;
        }

        public IResponse<DogViewModel> AssignSire(Guid id, Guid sireId)
        {
            var command = new AssignSireCommand(id, sireId);

            var result = Dispatcher.Invoke(command);

            return result;
        }

        public IResponse<DogViewModel> AssignDam(Guid id, Guid damId)
        {
            var command = new AssignDamCommand(id, damId);

            var result = Dispatcher.Invoke(command);

            return result;
        }
    }
}
