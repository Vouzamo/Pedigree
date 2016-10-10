using Pedigree.Common.Models;

namespace Pedigree.Common.ViewModels
{
    public class PedigreeViewModel
    {
        public DogViewModel Dog { get; protected set; }
        public PedigreeParentageViewModel Sire { get; protected set; }
        public PedigreeParentageViewModel Dam { get; protected set; }

        public PedigreeViewModel(DogViewModel dog, PedigreeParentageViewModel sire, PedigreeParentageViewModel dam)
        {
            Dog = dog;
            Sire = sire;
            Dam = dam;
        }
    }

    public class PedigreeParentageViewModel
    {
        public Parentage Type { get; protected set; }
        public DogViewModel Dog { get; protected set; }
        public int Generation { get; protected set; }
        public int Generations { get; protected set; }
        public PedigreeParentageViewModel Sire { get; set; }
        public PedigreeParentageViewModel Dam { get; set; }

        public PedigreeParentageViewModel(DogViewModel dog, Parentage type, int generations, int generation = 1)
        {
            Dog = dog;
            Type = type;
            Generations = generations;
            Generation = generation;
        }
    }

    public enum PedigreeGenerations
    {
        Current = 0,
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }
}
