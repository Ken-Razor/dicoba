using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace LPS_ProjectManagement.Helper
{
    public static class MenuHelper
    {
        /// <summary>
        /// Determines whether the specified controller is selected.s
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        public static string IsActive(this HtmlHelper html, string controller = null, string action = null)
        {
            const string cssClass = "active";
            var currentAction = (string)html.ViewContext.RouteData.Values["action"];
            var currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static void IsToggleSideBar(this HtmlHelper html, out string Topbar, out string Sidebar, out string Mainbar)
        {
            if (HttpContext.Current.Request.Cookies["StatusToogle"] != null && HttpContext.Current.Request.Cookies["StatusToogle"].Value.ToString() == "isActive")
            {
                Topbar = "sidebar_shift";
                Sidebar = "collapseit";
                Mainbar = "sidebar_shift";
            }
            else
            {
                Topbar = "expandit";
                Sidebar = " ";
                Mainbar = " ";
            }
        }

        public static string BuildBreadcrumbNavigation(this HtmlHelper helper, string title)
        {
            // optional condition: I didn't wanted it to show on home and account controller
            //if (helper.ViewContext.RouteData.Values["controller"].ToString() == "Home" ||
            //    helper.ViewContext.RouteData.Values["controller"].ToString() == "Account")
            //{
            //    return string.Empty;
            //}

            StringBuilder breadcrumb = new StringBuilder("<ol class='breadcrumb'><li><i class='fa fa-home'></i>").Append(helper.ActionLink("Beranda", "Index", "Beranda").ToHtmlString()).Append("</li>");

        
            if (helper.ViewContext.RouteData.Values["action"].ToString() != "Index")
            {
                breadcrumb.Append("<li>");
                breadcrumb.Append(title);
                breadcrumb.Append("</li>");
            }

            return breadcrumb.Append("</ol>").ToString();
        }

        public static string Titleize(this string text)
        {
            return text.AddSpacesToSentence();
        }

        public static string ToSentenceCase(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
        }

        public static string AddSpacesToSentence(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != ' ')
                    newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }
    }
}