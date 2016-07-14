using System;
using Microsoft.Extensions.DependencyInjection;
using Pedigree.Common.Models;
using System.Linq;

namespace Pedigree.App.Infrastructure
{
    public class AppDbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<AppDbContext>();

            // People
            if(!context.Set<Person>().Any())
            {
                context.Add(new Person("John Halstead"));
                context.Add(new Person("Sandra Halstead"));

                context.SaveChanges();
            }

            // CoatColors
            if(!context.Set<CoatColor>().Any())
            {
                context.Add(new CoatColor("Black"));
                context.Add(new CoatColor("Chocolate"));
                context.Add(new CoatColor("Yellow"));
                context.Add(new CoatColor("Fox Red"));

                context.SaveChanges();
            }

            // Titles
            if(!context.Set<Title>().Any())
            {
                context.Add(new Title("Belgium Champion", "BEL CH"));
                context.Add(new Title("Champion", "CH"));
                context.Add(new Title("Danish Field Trial Winner", "DAN FT W"));
                context.Add(new Title("Field Trial Champion", "FT CH"));

                context.SaveChanges();
            }

            // Dogs
            if(!context.Set<Dog>().Any())
            {
                context.Add(new Dog("Breeze", Sex.Bitch));
                context.Add(new Dog("Viper", Sex.Dog));
                context.Add(new Dog("Mark", Sex.Dog));

                context.SaveChanges();
            }
        }
    }
}
