using Pedigree.Common.ViewModels;
using System;
using Vouzamo.EntityFramework.Commands;

namespace Pedigree.Core.Commands
{
    public class AssignSireCommand : ModifyCommand<Guid, DogViewModel>
    {
        public AssignSireCommand(Guid id, Guid value) : base(id, value)
        {

        }
    }
}
