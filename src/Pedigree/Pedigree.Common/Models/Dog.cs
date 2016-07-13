using System;
using Vouzamo.Interop.Interfaces;

namespace Pedigree.Common.Models
{
    public class Dog : IEntity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public Sex Sex { get; protected set; }

        public Guid? SireId { get; set; }
        public Guid? DamId { get; set; }

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
