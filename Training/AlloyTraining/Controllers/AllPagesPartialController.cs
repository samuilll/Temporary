using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer.Web.Mvc;
using System.Web.Mvc;
using EPiServer.Framework.DataAnnotations;

namespace AlloyTraining.Controllers
{
    [TemplateDescriptor(Inherited = true,   
    Tags = new[] { SiteTags.Full }, AvailableWithoutTag = true)]
    public class AllPagesFullPartialController
        : PartialContentController<SitePageData>
    {
        public override ActionResult Index(SitePageData currentPage)
        {
            var viewmodel =
                new DefaultPageViewModel<SitePageData>(currentPage);
            return PartialView(SiteTags.Full, viewmodel);
        }
    }

    [TemplateDescriptor(Inherited = true,
        Tags = new[] { SiteTags.Wide }, AvailableWithoutTag = true)]
    public class AllPagesWidePartialController
        : PartialContentController<SitePageData>
    {
        public override ActionResult Index(SitePageData currentPage)
        {
            var viewmodel =
                new DefaultPageViewModel<SitePageData>(currentPage);
            return PartialView(SiteTags.Wide, viewmodel);
        }
    }

    [TemplateDescriptor(Inherited = true,
        Tags = new[] { SiteTags.Narrow }, AvailableWithoutTag = true)]
    public class AllPagesNarrowPartialController
        : PartialContentController<SitePageData>
    {
        public override ActionResult Index(SitePageData currentPage)
        {
            var viewmodel =
                new DefaultPageViewModel<SitePageData>(currentPage);
            return PartialView(SiteTags.Narrow, viewmodel);
        }
    }
}