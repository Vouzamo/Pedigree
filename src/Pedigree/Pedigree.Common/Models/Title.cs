using Pedigree.Common.Interfaces;
using System;

namespace Pedigree.Common.Models
{
    public class Title : IBasicEntity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Abbreviation { get; protected set; }
        public Color Color { get; protected set; }

        protected Title()
        {
            Id = Guid.NewGuid();
        }

        public Title(string name, string abbreviation, Color color = Color.Default) : this()
        {
            Name = name;
            Abbreviation = abbreviation;
            Color = color;
        }
    }
}
