using ChushkaWebApp.Models;
using ChushkaWebApp.Utilities;
using ChushkaWebApp.ViewModels.Products;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChushkaWebApp.Controllers
{
   public class ProductsController:BaseController
    {
        public IHttpResponse Details(int id)
        {
            Product product = this.Db.Products
                  .FirstOrDefault(p => p.Id == id);

            if (product==null)
            {
                return this.BadRequestError("Invalid id!");
            }

            ProductDetailsViewModel model = new ProductDetailsViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Type = product.Type.ToString()
            };

            return View(model);
        }

        public IHttpResponse Order(int id)
        {
            Product product = this.Db.Products
                  .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return this.BadRequestError("Invalid id!");
            }

            MvcUserInfo userInfo = this.User;

            int userId = this.Db.Users.FirstOrDefault(u => u.Username == userInfo.Username).Id;

            Order order = new Order()
            {
                OrderedOn = DateTime.UtcNow,
                ProductId = id,
                UserId = userId,
            };

            this.Db.Orders.Add(order);
            this.Db.SaveChanges();

            return Redirect("/");
        }

        [Authorize("Admin")]
        public IHttpResponse Edit(int id)
        {
            Product product = this.Db.Products
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return this.BadRequestError("Invalid id!");
            }

            ProductDetailsViewModel model = new ProductDetailsViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Type = product.Type.ToString()
            };

            return View(model);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Edit(ProductDetailsViewModel model)
        {
            if (!Validation.IsValid(model))
            {
                return this.BadRequestError("Some of the fields is incorrect!");
            }

            Product product = this.Db.Products
                 .FirstOrDefault(p => p.Id == model.Id);

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
           product.Type = Enum.Parse<ProductType>(model.Type);

            this.Db.Products.Update(product);
            this.Db.SaveChanges();

            return Redirect("/");
        }

        [Authorize("Admin")]
        public IHttpResponse Create()
        {
            ProductDetailsViewModel model = new ProductDetailsViewModel();

            return View(model);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse Create(ProductDetailsViewModel model)
        {
            if (!Validation.IsValid(model))
            {
                return this.BadRequestError("Some of the fields is incorrect!");
            }

            Product product = new Product();
               

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Type =Enum.Parse<ProductType>(model.Type) ;

            this.Db.Products.Add(product);
            this.Db.SaveChanges();

            return Redirect("/");
        }

        [Authorize("Admin")]
        public IHttpResponse Delete(int id)
        {
            Product product = this.Db.Products
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return this.BadRequestError("Invalid id!");
            }

            ProductDetailsViewModel model = new ProductDetailsViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Type = product.Type.ToString()
            };

            return View(model);
        }

        [Authorize("Admin")]
        [HttpPost]
        public IHttpResponse DoDelete(int id)
        {
            Product product = this.Db.Products
                .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return this.BadRequestError("Invalid id!");
            }

            this.Db.Products.Remove(product);
            this.Db.SaveChanges();

            return Redirect("/");
        }
    }
}
