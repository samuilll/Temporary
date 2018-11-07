
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace AlloyTraining.Models.Pages
{
    [ContentType(DisplayName = "Product",
        GroupName = SiteGroupNames.Specialized,
        Order = 20,
        Description = "Use this for software products that Alloy sells")]
    [SiteCommerceIcon]
    public class ProductPage : StandardPage
    {
        [CultureSpecific]
        [Display(Name = "Unique selling points",
            GroupName =  SystemTabNames.Content,
            Order = 320)]
        [UIHint(UIHint.Textarea)]
        [Required]
        public virtual string UniqueSellingPoints { get; set; }

        [Display(Name = "Main content area",
            Description = "Drag and drop blocks and pages with partial templates.",
            GroupName = SystemTabNames.Content,
            Order = 330)]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(Name = "Related content area",
            Description = "Drag and drop blocks and pages with partial templates.",
            GroupName = SystemTabNames.Content,
            Order = 340)]
        public virtual ContentArea RelatedContentArea { get; set; }

    }
}