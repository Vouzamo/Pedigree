using System;
using Pedigree.Common.Models;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Common.ViewModels
{
    public class TitleViewModel : IEditable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public Color? Color { get; set; }
    }
}
