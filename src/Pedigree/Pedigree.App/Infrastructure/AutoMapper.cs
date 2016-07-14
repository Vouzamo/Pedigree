using AutoMapper;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;

namespace Pedigree.App.Infrastructure
{
    public class AutoMapper : Vouzamo.Interop.Interfaces.IMapper
    {
        public static void Register()
        {
            Mapper.Initialize(
                cfg =>
                {
                    cfg.CreateMap<Dog, DogViewModel>().ReverseMap();
                    cfg.CreateMap<Person, PersonViewModel>().ReverseMap();
                }
            );
        }

        public TDestination Map<TSource, TDestination>(TSource toBeMapped)
        {
            return Mapper.Map<TSource, TDestination>(toBeMapped);
        }
    }
}
