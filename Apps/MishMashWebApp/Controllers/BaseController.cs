using Microsoft.EntityFrameworkCore;
using MishMashWebApp.Data;
using SIS.MvcFramework;

namespace MishMashWebApp.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            this.Db = new ApplicationDbContext();
            this.Db.Database.Migrate();
        }

        protected ApplicationDbContext Db { get; }
    }
}
