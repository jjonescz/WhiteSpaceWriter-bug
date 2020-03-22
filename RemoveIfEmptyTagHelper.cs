using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace WhiteSpaceWriter_bug
{
    [HtmlTargetElement(Attributes = "remove-if-empty")]
    public class RemoveIfEmptyTagHelper : TagHelper
    {
        public bool RemoveIfEmpty { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if (!RemoveIfEmpty)
                return;

            var content = await output.GetChildContentAsync(NullHtmlEncoder.Default);
            if (content.IsEmptyOrWhiteSpace)
                output.SuppressOutput();
        }
    }
}
