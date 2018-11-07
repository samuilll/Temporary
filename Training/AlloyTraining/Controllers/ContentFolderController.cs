using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;

namespace AlloyTraining.Controllers
{
    public class ContentFolderController : PartialContentController<ContentFolder>
    {
        public override ActionResult Index(ContentFolder currentBlock)
        {
            return PartialView(currentBlock);
        }
    }
}
