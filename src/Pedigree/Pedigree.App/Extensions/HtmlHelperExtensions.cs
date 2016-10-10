using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pedigree.Common.Models;
using Pedigree.Common.ViewModels;

namespace Pedigree.App.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString SexIcon(this IHtmlHelper html, DogViewModel dog)
        {
            var iconFormat = "<i class=\"fa fa-{0} {1}\" aria-hidden=\"true\"></i>";
            var result = string.Format(iconFormat, "genderless", string.Empty);

            switch (dog.Sex)
            {
                case Sex.Dog:
                    result = string.Format(iconFormat, "mars", "sire");
                    break;
                case Sex.Bitch:
                    result = string.Format(iconFormat, "venus", "bitch");
                    break;
            }

            return new HtmlString(result);
        }
    }
}
