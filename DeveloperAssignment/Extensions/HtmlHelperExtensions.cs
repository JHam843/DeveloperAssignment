using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Html;

namespace DeveloperAssignment.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IHtmlContent RenderButton(this IHtmlHelper htmlHelper, string text, string cssClass = "btn btn-primary", string type = "button", object htmlAttributes = null)
        {
            var tagBuilder = new TagBuilder("button");
            tagBuilder.InnerHtml.Append(text);
            tagBuilder.AddCssClass(cssClass);
            tagBuilder.Attributes.Add("type", type);

            if (htmlAttributes != null)
            {
                var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                tagBuilder.MergeAttributes(attributes);
            }

            return tagBuilder;
        }
    }
}
