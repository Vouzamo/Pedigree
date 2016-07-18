using Pedigree.Common.Models;
using System;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Common.ViewModels
{
    public class DogViewModel : IEditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Sex? Sex { get; set; }

        public Guid? SireId { get; set; }
        public Guid? DamId { get; set; }
    }
}
