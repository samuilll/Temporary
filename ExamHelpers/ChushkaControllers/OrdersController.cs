using ChushkaWebApp.ViewModels;
using ChushkaWebApp.ViewModels.Orders;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChushkaWebApp.Controllers
{
   public class OrdersController:BaseController
    {
        [Authorize("Admin")]
        public IHttpResponse All()
        {

            List<OrderViewModel> orders = this.Db.Orders
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    Customer = o.User.Username,
                    Product = o.Product.Name,
                    OrderedOn = o.OrderedOn.ToString("hh:mm dd-MM-yyyy")
                })
        .ToList();

            var model = new AllOrdersViewModel()
            {
                Orders = orders
            };

            return View(model);
        }
    }
}
