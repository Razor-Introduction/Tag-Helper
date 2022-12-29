using Microsoft.AspNetCore.Mvc.Razor.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Encodings.Web;

namespace RazorIntroduction.TagHelpers.Web.TagHelpers.Extended
{
    [HtmlTargetElement("img", TagStructure = TagStructure.WithoutEndTag)]
    public class ResponsiveImageTagHelper : ImageTagHelper
    {
        public ResponsiveImageTagHelper(IWebHostEnvironment hostingEnvironment, TagHelperMemoryCacheProvider cacheProvider, IFileVersionProvider fileVersionProvider, HtmlEncoder htmlEncoder, IUrlHelperFactory urlHelperFactory) : base(hostingEnvironment, cacheProvider, fileVersionProvider, htmlEncoder, urlHelperFactory)
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var img = new TagBuilder("img");
            img.Attributes.Add("class", "img-fluid");
            output.MergeAttributes(img);

            base.Process(context, output);

        }
    }
}
