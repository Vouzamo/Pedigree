using System;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Pedigree.Common.Interfaces;
using Pedigree.Common.ViewModels;

namespace Pedigree.App.TagHelpers
{
    [HtmlTargetElement("dog-name", Attributes = "name")]
    public class DogNameTagHelper : TagHelper
    {
        private ITitleService TitleService { get; set; }

        [HtmlAttributeName("titleId")]
        public Guid? TitleId { get; set; }
        [HtmlAttributeName("name")]
        public string Name { get; set; }

        public DogNameTagHelper(ITitleService titleService)
        {
            TitleService = titleService;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(TitleId.HasValue)
            {
                var response = TitleService.Get(TitleId.Value);

                if(response.Success)
                {
                    var title = response.Result;

                    var color = string.Empty;
                    if(title.Color.HasValue)
                    {
                        switch(title.Color.Value)
                        {
                            case Common.Models.Color.Red:
                                color = "color-red";
                                break;
                        }
                    }

                    output.Content.AppendHtml($"<small class=\"{color}\"><attr title=\"{title.Name}\">{title.Abbreviation}</attr></small> {Name}");
                    return;
                }
            }

            output.Content.AppendHtml(Name);
        }
    }
}
