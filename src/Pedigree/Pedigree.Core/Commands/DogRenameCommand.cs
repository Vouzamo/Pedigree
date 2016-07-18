using Pedigree.Common.ViewModels;
using System;
using Vouzamo.EntityFramework.Commands;

namespace Pedigree.Core.Commands
{
    public class DogRenameCommand : ModifyCommand<string, DogViewModel>
    {
        public DogRenameCommand(Guid id, string value) : base(id, value)
        {

        }
    }
}
