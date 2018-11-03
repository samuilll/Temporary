using System.Collections.Immutable;
using System.Linq;
using MishMashWebApp.Models;
using MishMashWebApp.ViewModels.Channels;
using MishMashWebApp.ViewModels.Home;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MishMashWebApp.Controllers
{
    public class HomeController : BaseController
    {
        [HttpGet()]
        public IHttpResponse Index()
        {
            if (this.User.IsLoggedIn)
            {

                User user = this.Db.Users.FirstOrDefault(u => u.Username == this.User.Username);

                LoggedInViewModel model = new LoggedInViewModel();

                model.UserChannels= this.Db
                    .UserInChannel
                    .Where(uc => uc.User.Username == user.Username)
                    .Select(uc => new ChannelViewModel()
                    {
                        Id = uc.ChannelId,
                        Followers = uc.Channel.Followers.Count.ToString(),
                        Name = uc.Channel.Name,
                        Type = uc.Channel.Type.ToString()
                    })
                    .ToArray();

                var tags = this.Db
                    .Tags
                    .Where(t => t.Channels.Any(c => c.Channel.Followers.Any(f => f.User.Username == user.Username)))
                    .Select(t=>t.Id)
                    .ToArray();

                model.SuggestedChannels = this.Db.Channels
                    .Where(c => !c.Followers.Any(f => f.UserId == user.Id)&& c.Tags.Any(t=>tags.Contains(t.TagId)))
                    .Select(c => new ChannelViewModel()
                    {
                        Id = c.Id,
                        Followers = c.Followers.Count.ToString(),
                        Name = c.Name,
                        Type = c.ToString()
                    })
                    .ToArray();

                model.OtherChannels = Db.Channels
                    .Where(c => !(c.Followers.Any(f => f.UserId == user.Id)) &&
                                !(!c.Followers.Any(f => f.UserId == user.Id) &&
                                  c.Tags.Any(t => tags.Contains(t.TagId))))
                    .Select(c => new ChannelViewModel()
                    {
                        Id = c.Id,
                        Followers = c.Followers.Count.ToString(),
                        Name = c.Name,
                        Type = c.ToString()
                    })
                    .ToArray();

                return View("Home/LoggedInIndex",model);
            }
            return this.View();
        }
    }
}


//The Your Channels section holds all of the current user’s Followed Channels.If there are no such Channels, it should just be left empty.
//The Suggested section holds any Channels, which have at least 1 common tag with one of the current user’s Followed Channels.
//The See Other section holds all Channels, which are NOT included in the Your Channels and Suggested sections.
