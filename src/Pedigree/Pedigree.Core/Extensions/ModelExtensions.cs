using Pedigree.Common.Models;
using Pedigree.Core.Specifications;

namespace Pedigree.Core.Extensions
{
    public static class ModelExtensions
    {
        public static bool SetDam(this Dog dog, Dog dam)
        {
            var specification = new DamSpecification();

            if (specification.IsSatisfiedBy(dam))
            {
                dog.DamId = dam.Id;
                return true;
            }

            return false;
        }

        public static bool SetSire(this Dog dog, Dog sire)
        {
            var specification = new SireSpecification();

            if(specification.IsSatisfiedBy(sire))
            {
                dog.SireId = sire.Id;
                return true;
            }

            return false;
        }


    }
}
