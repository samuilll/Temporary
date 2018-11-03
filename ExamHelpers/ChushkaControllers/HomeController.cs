using ChushkaWebApp.ViewModels.Home;
using ChushkaWebApp.ViewModels.Products;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChushkaWebApp.Controllers
{
   public class HomeController:BaseController
    {
        public IHttpResponse Index()
        {

            int z = 425;
            int y = 345;
            if (this.User.IsLoggedIn)
            {
                List<ProductViewModel> products = this.Db.Products
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description.Substring(0, Math.Min(50, p.Description.Length))
                })
                .ToList();

                HomeViewModel model = new HomeViewModel()
                {
                    Products = products
                };

                return View("Home/LoggedInIndex",model);
            }

            return View();
        }
    }
}
