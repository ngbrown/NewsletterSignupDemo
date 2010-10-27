namespace System.Web.Mvc 
{
    using System.Text;

    using Collections.Generic;

    using Routing;

    public static class HtmlHelpers 
    {
        const string pubDir="/Public";
        const string cssDir="css";
        const string imageDir="images";
        const string scriptDir="javascript";

        public static string DatePickerEnable(this HtmlHelper helper) 
        {
            StringBuilder sb=new StringBuilder();
            sb.AppendLine("<script type=\"text/javascript\">$(document).ready(function() {$('.date-selector').datepicker();});</script>\n");
            return sb.ToString();
        }

        public static string Friendly(this HtmlHelper helper) 
        {
            if (helper.ViewContext.HttpContext.Request.Cookies["friendly"] != null) 
            {
                return helper.h(helper.ViewContext.HttpContext.Request.Cookies["friendly"].Value);
            }
            else 
            {
                return "";
            }
        }

        public static string Script(this HtmlHelper helper, string fileName) 
        {
            if (!fileName.EndsWith(".js"))
                fileName += ".js";
            var jsPath = string.Format("<script src=\"{0}/{1}/{2}\"></script>\n", pubDir, scriptDir, helper.AttributeEncode(fileName));
            return jsPath;
        }

        public static string CSS(this HtmlHelper helper, string fileName) 
        {
            return CSS(helper, fileName, "screen");
        }

        public static string CSS(this HtmlHelper helper, string fileName, string media) 
        {
            if (!fileName.EndsWith(".css"))
                fileName += ".css";
            var jsPath = string.Format("<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}/{1}/{2}\"  media=\"" + media + "\"/>\n", pubDir, cssDir, helper.AttributeEncode(fileName));
            return jsPath;
        }

        public static string Image(this HtmlHelper helper, string fileName) 
        {
            return Image(helper, fileName, "");
        }

        public static string Image(this HtmlHelper helper, string fileName, object htmlAttributes) 
        {
            fileName = string.Format("{0}/{1}/{2}", pubDir, imageDir, fileName);
            return string.Format("<img src=\"{0}\" {1} />", helper.AttributeEncode(fileName), ConvertObjectToAttributeList(htmlAttributes));
        }

        public static string ConvertObjectToAttributeList(object htmlAttributes)
        {
            StringBuilder builder = new StringBuilder();
            if (htmlAttributes != null)
            {
                IDictionary<string, object> dictionary = htmlAttributes as IDictionary<string, object>;
                if (dictionary == null)
                {
                    dictionary = new RouteValueDictionary(htmlAttributes);
                }
                string format = "{0}=\"{1}\" ";
                foreach (string str2 in dictionary.Keys)
                {
                    object obj2 = dictionary[str2];
                    if (dictionary[str2] is bool)
                    {
                        obj2 = dictionary[str2].ToString().ToLowerInvariant();
                    }
                    builder.AppendFormat(format, str2.Replace("_", "").ToLowerInvariant(), obj2);
                }
            }
            return builder.ToString();
        }
    }
}
