using System;
using System.Linq;
using MishMashWebApp.Models;
using MishMashWebApp.Utilities;
using MishMashWebApp.ViewModels.Users;
using SIS.HTTP.Cookies;
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using SIS.MvcFramework.Services;

namespace MishMashWebApp.Controllers
{
    public class UsersController : BaseController
    {
        private IHashService hashService;

        public UsersController(IHashService hashService)
        {
            this.hashService = hashService;
        }

        [HttpGet]
        public IHttpResponse Register()
        {
            return View();
        }

        [HttpPost]
        public IHttpResponse Register(DoRegisterInputModel user)
        {

          bool isValid =   Validation.IsValid(user);

            if (!isValid)
            {
                return this.BadRequestErrorWithView("Invalid user parameters");
            }

            User userToInput = new User()
            {
                Username = user.Username,
                Password = this.hashService.Hash(user.Password),
                Email = user.Email,
                Role = Role.User
            };

            this.Db.Users.Add(userToInput);

            this.Db.SaveChanges();

            return this.Redirect("/Users/Login");
        }

        [HttpGet]
        public IHttpResponse Login()
        {
            return View();
        }

        [HttpPost]
        public IHttpResponse Login(DoLoginInputModel model)
        {
            User user = this.Db.Users.
                FirstOrDefault(u => u.Password == this.hashService.Hash(model.Password)  && u.Username == model.Username);

            if (user==null)
            {
                return this.BadRequestErrorWithView("Invalid username or password");
            }

            MvcUserInfo mvcUser = new MvcUserInfo { Username = user.Username, Role = user.Role.ToString(), Info = user.Email };
            string cookieContent = this.UserCookieService.GetUserCookie(mvcUser);

            var cookie = new HttpCookie(".auth-cakes", cookieContent, 7) { HttpOnly = true };
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
             }

        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-cakes");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }
         }
}
