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
    public class ProductPagePartialController : PartialContentController<ProductPage>
    {
        public override ActionResult Index(ProductPage currentPage)
        { 
            var viewModel = new DefaultPageViewModel<ProductPage>(currentPage);

            return PartialView(viewModel);
        }
    }
}