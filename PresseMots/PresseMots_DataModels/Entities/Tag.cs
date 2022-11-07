using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace PresseMots_DataModels.Entities
{
    public class Tag
    {
        [Display(Name="Id")] public int Id { get; set; }
        [Display(Name="Name")] public string Name { get; set; }
        [Display(Name="StoryTags")] public virtual IList<StoryTag> StoryTags { get; set; } = new List<StoryTag>();

    }
}
