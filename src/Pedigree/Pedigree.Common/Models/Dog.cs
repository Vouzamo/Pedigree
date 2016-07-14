using Pedigree.Common.Interfaces;
using System;

namespace Pedigree.Common.Models
{
    public class Dog : IBasicEntity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Sex Sex { get; protected set; }

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

        protected Dog()
        {
            Id = Guid.NewGuid();
        }

        public Dog(string name, Sex sex) : this()
        {
            Name = name;
            Sex = sex;
        }
    }
}
