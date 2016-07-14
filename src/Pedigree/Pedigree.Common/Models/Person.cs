using Pedigree.Common.Interfaces;
using System;

namespace Pedigree.Common.Models
{
    public class Person : IBasicEntity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        protected Person()
        {
            Id = Guid.NewGuid();
        }

        public Person(string name) : this()
        {
            Name = name;
        }
    }
}
