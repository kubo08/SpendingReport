using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace SpendingReport.Helpers
{
    public static class HtmlExtensions
    {
        public static string AutocompleteDropdown(string text, IList<SelectListItem> items)
        {
            string result = "<select id='combobox'>" +
                            "<option value=''>" + text + "</option>";
            foreach (var selectListItem in items)
            {
                result += String.Format("<option value='{0}'>{1}</option>", selectListItem.Value, selectListItem.Text);
            }
            result += "</select>";

            return result;
        }

        public static MvcHtmlString Script(this HtmlHelper htmlHelper, Func<object, HelperResult> template)
        {
            htmlHelper.ViewContext.HttpContext.Items["_script_" + Guid.NewGuid()] = template;
            return MvcHtmlString.Empty;
        }

        public static MvcHtmlString Script(this HtmlHelper htmlHelper, IList<Func<object, HelperResult>> templates)
        {
            foreach (var template in templates)
            {
                htmlHelper.Script(template);
            }
            return MvcHtmlString.Empty;
        }

        public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
        {
            foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
            {
                if (key.ToString().StartsWith("_script_"))
                {
                    var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
                    if (template != null)
                    {
                        htmlHelper.ViewContext.Writer.Write(template(null));
                    }
                }
            }
            return MvcHtmlString.Empty;
        }
    }
}