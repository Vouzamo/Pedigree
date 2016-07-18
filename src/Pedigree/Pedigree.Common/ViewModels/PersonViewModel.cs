using System;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Common.ViewModels
{
    public class PersonViewModel : IEditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
