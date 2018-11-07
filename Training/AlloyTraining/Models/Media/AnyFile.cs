using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(DisplayName = "AnyFile",
        Description = "Use this to upload any type of file")]
    public class AnyFile : MediaData
    {

        //[CultureSpecific]
        //[Editable(true)]
        //[Display(
        //    Name = "Description",
        //    Description = "Description field's description",
        //    GroupName = SystemTabNames.Content,
        //    Order = 1)]
        //public virtual string Description { get; set; }

    }
}