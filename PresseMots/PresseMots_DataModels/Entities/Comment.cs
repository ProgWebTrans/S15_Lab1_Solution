using PresseMots_Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseMots_DataModels.Entities
{
    public class Comment : IWordCountable
    {
        [Display(Name="Id")] public int Id { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "EmailRequired")]

        [Display(Name="Email")] public String Email { get; set; }

        [MaxLength(100, ErrorMessage = "Max100Please")]
        [Required(ErrorMessage = "DisplayNameRequired")]
        [Display(Name="DisplayName")] public String DisplayName { get; set; }

        [MaxLength(2500, ErrorMessage="Max2500Please")]
        [Required(ErrorMessage = "ContentRequired")]
        [Display(Name="Content")] public String Content { get; set; }


        [Display(Name="Hidden")] public bool Hidden { get; set; }
        [Range(0,5, ErrorMessage = "{0} needs to be between {1} and  {2}")]
        [Display(Name = "Rating")] public decimal? Rating { get; set; }



        [Display(Name="StoryId")] public int StoryId { get; set; }
        [Display(Name="Story")] public virtual Story Story { get; set; }





    }
}
