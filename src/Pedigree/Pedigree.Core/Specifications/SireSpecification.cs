using Pedigree.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vouzamo.Specification;
using Vouzamo.Specification.Interfaces;

namespace Pedigree.Core.Specifications
{
    public class ParentageSpecification : WhereSpecification<Dog>
    {
        public ParentageSpecification(Parentage parentage)
        {
            switch(parentage)
            {
                case Parentage.Dam:
                    Predicate = x => x.Sex == Sex.Bitch;
                    break;
                case Parentage.Sire:
                    Predicate = x => x.Sex == Sex.Dog;
                    break;
            }
        }
    }

    public class SireSpecification : ParentageSpecification
    {
        public SireSpecification() : base(Parentage.Sire)
        {

        }
    }

    public class DamSpecification : ParentageSpecification
    {
        public DamSpecification() : base(Parentage.Dam)
        {

        }
    }
}
