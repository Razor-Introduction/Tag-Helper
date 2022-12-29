using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Net;
using System.Reflection.Emit;
using System.Text.Encodings.Web;

namespace RazorIntroduction.TagHelpers.Web.TagHelpers.Extended
{
    [HtmlTargetElement("input", Attributes = "[type^=password],[asp-for]", TagStructure = TagStructure.WithoutEndTag)]
    public class PasswordInputTagHelper : InputTagHelper
    {
        public PasswordInputTagHelper(IHtmlGenerator generator) : base(generator)
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.AddClass("custom-password", HtmlEncoder.Default);

            output.PreElement.SetHtmlContent("<div class='input-group' id='show_hide_password'>");

            output.PostElement.SetHtmlContent(@"
                    <span class='input-group-text' id='basic-addon2'>
                        <i style ='cursor:pointer;font-size:22px' class='la la-eye-slash'></i>
                    </span>
                </div>");

            base.Process(context, output);

        }
    }
}
