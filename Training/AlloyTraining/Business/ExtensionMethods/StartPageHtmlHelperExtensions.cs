using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlloyTraining.Models.Pages;
using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;

namespace AlloyTraining.Business.ExtensionMethods
{
    public static class StartPageHtmlHelperExtensions
    {
        public static StartPage GetStartPage(
            this HtmlHelper html)
        {
            var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
            return loader.Get<StartPage>(ContentReference.StartPage);
        }
        public static IEnumerable<PageData> GetStartPageChildren(
            this HtmlHelper html)
        {
            var loader = ServiceLocator.Current.GetInstance<IContentLoader>();
            return loader.GetChildren<PageData>(ContentReference.StartPage);
        }

    }
}