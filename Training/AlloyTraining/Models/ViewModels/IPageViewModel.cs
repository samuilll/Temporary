using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlloyTraining.Models.Pages;
using EPiServer.Core;

namespace AlloyTraining.Models.ViewModels
{
    public interface IPageViewModel<out T>
    where T : SitePageData
    {
        T CurrentPage { get; }

        IContent Section { get; }
    }
}