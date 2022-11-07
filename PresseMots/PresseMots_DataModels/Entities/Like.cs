using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseMots_DataModels.Entities
{
    public class Like
    {

        [Display(Name="Id")] public int Id { get; set; }
        [Display(Name="StoryId")] public int StoryId { get; set; }
        [Display(Name="Story")] public virtual Story Story { get; set; }

        [Display(Name="UserId")] public int? UserId { get; set; }
        [Display(Name="User")] public virtual User User { get; set; }

        [Display(Name="SubmittedDate")] public DateTime SubmittedDate { get; set; }

    }
}
