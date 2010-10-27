namespace System.Web.Mvc 
{
    using Microsoft.Security.Application;

    public static class XSSHelper 
    {
        public static string h(this HtmlHelper helper, string input) 
        {
            return AntiXss.HtmlEncode(input);
        }

        public static string Sanitize(this HtmlHelper helper, string input) 
        {
            return AntiXss.GetSafeHtml(input);
        }

        /// <summary>
        /// Encodes Javascript
        /// </summary>
        public static string hscript(this HtmlHelper helper, string input) 
        {
            return AntiXss.JavaScriptEncode(input);
        }
    }
}
