using Pedigree.Common.Interfaces;
using System;

namespace Pedigree.Common.Models
{
    public class CoatColor : IBasicEntity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }

        protected CoatColor()
        {
            Id = Guid.NewGuid();
        }

        public CoatColor(string name) : this()
        {
            Name = name;
        }
    }
}
