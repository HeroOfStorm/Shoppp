using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using WebApplication1.Models;

namespace WebApplication1.HelperMethods
{
    public static class CustomHelpersMethods
    {
        //public static MvcHtmlString PageLinks(this HtmlHelper html, PageLinkModel pages, Func<int,string> func )
        //{
        //    StringBuilder result = new StringBuilder();
        //    for (int i = 1; 1 <= pages.CountPages; i++)
        //    {
        //        TagBuilder tag = new TagBuilder("a");
        //        tag.MergeAttribute("href",func(i));
        //        tag.InnerHtml = i.ToString();


        //        if (i == pages.CurrentPage)
        //            tag.AddCssClass("btn btn-success");
        //        else
        //            tag.AddCssClass("btn btn-outline-success");
        //        result.Append(tag.ToString());
        //    }
        //    return MvcHtmlString.Create(result.ToString());
        //}
        public static MvcHtmlString PageLinks(this AjaxHelper html,
          PageLinkModel pages, Func<int, string> func, string target)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pages.CountPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", func(i));
                tag.InnerHtml = i.ToString();


                AjaxOptions options = new AjaxOptions();
                options.UpdateTargetId = target;
                tag.MergeAttributes(options.ToUnobtrusiveHtmlAttributes());


                tag.AddCssClass("btn btn-success");

                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}