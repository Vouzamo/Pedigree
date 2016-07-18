using Pedigree.Common.ViewModels;
using System;
using Vouzamo.EntityFramework.Commands;

namespace Pedigree.Core.Commands
{
    public class AssignDamCommand : ModifyCommand<Guid, DogViewModel>
    {
        public AssignDamCommand(Guid id, Guid value) : base(id, value)
        {

        }
    }
}
