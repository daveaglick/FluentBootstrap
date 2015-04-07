using FluentBootstrap.Tests.Web.Models.MvcTests;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using RazorGenerator.Testing;
using NUnit.Framework;

namespace FluentBootstrap.Tests
{
    public static class TestHelper
    {
        public static HtmlDocument Render<TView>()
            where TView : WebViewPage, new()
        {
            WebViewPage<dynamic> view = new TView() as WebViewPage<dynamic>;
            HtmlDocument doc = view.RenderAsHtml();
            Assert.IsEmpty(doc.ParseErrors.Where(x => x.Code != HtmlParseErrorCode.EndTagNotRequired));
            return doc;
        }

        public static HtmlDocument Render<TView, TModel>(TModel model = default(TModel))
            where TView : WebViewPage<TModel>, new()
        {
            var view = new TView();
            HtmlDocument doc = view.RenderAsHtml(model);
            Assert.IsEmpty(doc.ParseErrors.Where(x => x.Code != HtmlParseErrorCode.EndTagNotRequired));
            return doc;
        }

        // Removes all newlines for easier comparison
        public static string CollapsedOuterHtml(this HtmlNode node)
        {
            return CollapsedHtml(node.OuterHtml);
        }

        public static string CollapsedInnerHtml(this HtmlNode node)
        {
            return CollapsedHtml(node.InnerHtml);
        }

        private static string CollapsedHtml(string html)
        {
            html = html
                .Replace(Environment.NewLine, string.Empty)
                .Replace("\t", " ");
            while(html.IndexOf("  ") != -1)
            {
                html = html.Replace("  ", " ");
            }
            html = html.Replace("> ", ">").Replace(" <", "<");
            return html.Trim();
        }

        public static void AssertHtml<TView>(string containerId, string expected, bool collapsed = false)
            where TView : WebViewPage, new()
        {
            HtmlDocument doc = Render<TView>();
            expected = expected.Replace("\r\n", "\n");
            string actual = collapsed ? doc.GetElementbyId(containerId).CollapsedInnerHtml().Replace("\r\n", "\n") : doc.GetElementbyId(containerId).InnerHtml.Trim().Replace("\r\n", "\n");
            //Console.WriteLine("EXPECTED");
            //Console.WriteLine(expected);
            //Console.WriteLine("ACTUAL");
            //Console.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }

        public static void AssertMvcHtml<TView>(string containerId, string expected, bool collapsed = false)
            where TView : WebViewPage<ViewModel>, new()
        {
            ViewModel model = new ViewModel
            {
                PropA = "A",
                PropB = 2,
                PropC = new Dictionary<int, string>()
                {
                    { 1, "One"},
                    { 2, "Two"},
                    { 3, "Three"}
                },
                PropD = true
            };
            HtmlDocument doc = Render<TView, ViewModel>(model);
            expected = expected.Replace("\r\n", "\n");
            string actual = collapsed ? doc.GetElementbyId(containerId).CollapsedInnerHtml().Replace("\r\n", "\n") : doc.GetElementbyId(containerId).InnerHtml.Trim().Replace("\r\n", "\n");
            //Console.WriteLine("EXPECTED");
            //Console.WriteLine(expected);
            //Console.WriteLine("ACTUAL");
            //Console.WriteLine(actual);
            Assert.AreEqual(expected, actual);
        }
    }
}
