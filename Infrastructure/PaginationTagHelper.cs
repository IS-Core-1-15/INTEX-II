using INTEX_II.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INTEX_II.Infrastructure
{
    [HtmlTargetElement("div", Attributes="page-links")]
    public class PaginationTagHelper : TagHelper
    {
        //dynamically create page links
        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory temp) => uhf = temp;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        public PageInfo PageLinks { get; set; }
        public string PageAction { get; set; }

        // for css styling
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            int start;
            int last;
            if (PageLinks.CurrentPage <= 2)
            {
                start = 1;
                last = 5;
            }
            else if (PageLinks.CurrentPage >= PageLinks.TotalPages - 1)
            {
                start = PageLinks.TotalPages - 4;
                last = PageLinks.TotalPages;
            }
            else
            {
                start = PageLinks.CurrentPage - 2;
                last = PageLinks.CurrentPage + 2;
            }

            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            TagBuilder firstTb = new TagBuilder("a");

            firstTb.Attributes["href"] = uh.Action(PageAction, new { pageNum = 1 });

            if (PageClassesEnabled)
            {
                firstTb.AddCssClass(PageClass);
                firstTb.AddCssClass(1 == PageLinks.CurrentPage
                    ? PageClassSelected : PageClassNormal);
            }

            firstTb.InnerHtml.Append("First");

            final.InnerHtml.AppendHtml(firstTb);

            for (int i = start; i <= last; i++)
            {
                TagBuilder tb = new TagBuilder("a");

                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });

                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageLinks.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }

                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }

            TagBuilder lastTb = new TagBuilder("a");

            lastTb.Attributes["href"] = uh.Action(PageAction, new { pageNum = PageLinks.TotalPages });

            if (PageClassesEnabled)
            {
                lastTb.AddCssClass(PageClass);
                lastTb.AddCssClass(PageLinks.TotalPages == PageLinks.CurrentPage
                    ? PageClassSelected : PageClassNormal);
            }

            lastTb.InnerHtml.Append("Last");

            final.InnerHtml.AppendHtml(lastTb);

            output.Content.AppendHtml(final.InnerHtml);
        }
    }
}
