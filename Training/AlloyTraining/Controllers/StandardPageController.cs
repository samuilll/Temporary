using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;

namespace AlloyTraining.Controllers
{
    public class StandardPageController : PageControllerBase<StandardPage>
    {
        public ActionResult Index(StandardPage currentPage)
        {
            var viewModel = new DefaultPageViewModel<StandardPage>(currentPage);

            return View(viewModel);
        }
    }
}