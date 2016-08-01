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

        public string RegistrationNumber { get; set; }
        public string StudNumber { get; set; }

        public string HipScore { get; set; }
        public string ElbowScore { get; set; }
        public string EyeCertificate { get; set; }
        public string GPRA { get; set; }
        public string CNM { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Guid? SireId { get; set; }
        public Guid? DamId { get; set; }

        public Guid? TitleId { get; set; }
        public Guid? CoatColorId { get; set; }

        public Guid? PersonId { get; set; }
        public Guid? OwnerId { get; set; }
    }
}
