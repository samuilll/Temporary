using System;
using System.Collections.Generic;
using System.Text;
using MishMashWebApp.ViewModels.Channels;

namespace MishMashWebApp.ViewModels.Home
{
   public class LoggedInViewModel
    {
        public ICollection<ChannelViewModel> UserChannels { get; set; }

        public ICollection<ChannelViewModel> SuggestedChannels { get; set; }

        public ICollection<ChannelViewModel> OtherChannels { get; set; }

    }
}
