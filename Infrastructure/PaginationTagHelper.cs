using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using RecipeWebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebApp.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-info")]

    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory _UrlHelper;

        public PaginationTagHelper(IUrlHelperFactory uhf)
        {
            _UrlHelper = uhf;
        }

        public Paging PageInfo { get; set; }        
        //dictionary of key-value pairs
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> KeyValuePairs { get; set; } = new Dictionary<string, object>();
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper UrlHelp = _UrlHelper.GetUrlHelper(ViewContext);

            TagBuilder outputTag = new TagBuilder("div");            

            for (int i = 1; i <= PageInfo.NumPages; i++)
            {
                TagBuilder linkTag = new TagBuilder("a");

                KeyValuePairs["pagenum"] = i;

                linkTag.Attributes["href"] = UrlHelp.Action("Index", KeyValuePairs);
                linkTag.InnerHtml.AppendHtml(i.ToString());

                outputTag.InnerHtml.AppendHtml(linkTag);
            }            

            output.Content.AppendHtml(outputTag.InnerHtml);
        }
    }
}
