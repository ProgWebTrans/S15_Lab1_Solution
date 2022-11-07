using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace PresseMots_DataModels.Entities
{
    public class StoryTag
    {
        [Display(Name="Id")] public int Id { get; set; }
        [Display(Name="StoryId")] public int StoryId { get; set; }
        [Display(Name="TagId")] public int TagId { get; set; }
        [Display(Name="Tag")] public virtual Tag Tag { get; set; }
        [Display(Name="Story")] public virtual Story Story { get; set; }


    }
}
