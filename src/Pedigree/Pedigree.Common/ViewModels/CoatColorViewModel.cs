using System;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Common.ViewModels
{
    public class CoatColorViewModel : IEditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
