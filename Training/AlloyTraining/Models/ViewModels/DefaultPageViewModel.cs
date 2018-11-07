using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AlloyTraining.Models.Pages;
using EPiServer.Core;

namespace AlloyTraining.Models.ViewModels
{
    public class DefaultPageViewModel<T>
    :IPageViewModel<T> where T: SitePageData
    {
        public DefaultPageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }

        public T CurrentPage { get; set; }
        public IContent Section { get; set; }
    }
}