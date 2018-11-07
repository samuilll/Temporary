using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "Start",
        // your code will have a random GUID here
        GroupName = SiteGroupNames.Specialized,
        Order = 10,
        Description = "The home page for a website with an area for blocks and partial pages.")]
    [AvailableContentTypes(ExcludeOn = new []{typeof(StartPage)})]
    [SiteStartIcon]
    public class StartPage : SitePageData
    {
        [CultureSpecific]
        [Display(Name = "Heading",
            Description = "If the Heading is not set, the page falls back to showing the Name.",     
        GroupName = SystemTabNames.Content,
        Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
        GroupName = SystemTabNames.Content,
        Order = 20)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(Name="Main content area",
        Description = "Drag and drop images, blocks, and pages with partial templates",
        GroupName = SystemTabNames.Content,
        Order = 30)]
        [AllowedTypes(typeof(StandardPage),typeof(BlockData),typeof(ImageData))]
        public virtual ContentArea MainContentArea { get; set; }

        [CultureSpecific]
        [Display(Name = "Footer text",
            GroupName = SiteTabNames.SiteSettings,
            Order = 100)]
        public virtual string FooterText { get; set; }
     
    }
}
