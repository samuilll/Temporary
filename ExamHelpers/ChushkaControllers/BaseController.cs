using ChushkaWebApp.Data;
using Microsoft.EntityFrameworkCore;
using SIS.MvcFramework;

namespace ChushkaWebApp.Controllers
{
    public abstract class BaseController : Controller
    {
        protected BaseController()
        {
            this.Db = new ApplicationDbContext();
            Db.Database.Migrate();
        }

        public ApplicationDbContext Db { get; }
    }
}
