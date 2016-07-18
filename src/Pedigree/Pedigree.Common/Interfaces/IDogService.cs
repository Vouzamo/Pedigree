using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;
using System;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Common.Interfaces
{
    public interface IDogService : IBasicService<Dog, DogViewModel>
    {
        IResponse<DogViewModel> Rename(Guid id, string name);
        IResponse<DogViewModel> AssignSire(Guid id, Guid sireId);
        IResponse<DogViewModel> AssignDam(Guid id, Guid damId);
    }
}
