using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AlloyTraining.Models.Pages;
using EPiServer.Web.Mvc;

namespace AlloyTraining.Controllers
{
    public abstract class PageControllerBase<T>
    :PageController<T> where T:SitePageData
    {
        public PageControllerBase()
        {
            
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}