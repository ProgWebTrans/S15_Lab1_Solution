using PresseMots_Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseMots_DataModels.Entities
{
    public class Story : IWordCountable
    {

        public Story()
        {
            Likes = new List<Like>();
            Shares = new List<Share>();
            Comments = new List<Comment>();
            StoryTags = new List<StoryTag>();

        }
        [Display(Name="Id")] public int Id { get; set; }
        [Display(Name="Title")] public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name="Content")] public string Content { get; set; }

        [NotMapped]
        [Display(Name="Tags")] public IList<string> Tags { get; set; } = new List<string>();
        [Display(Name="CreationTime")] public DateTime CreationTime { get; set; }
        [Display(Name="LastEditTime")] public DateTime? LastEditTime { get; set; }
        [Display(Name="PublishTime")] public DateTime? PublishTime { get; set; }
        [Display(Name="Draft")] public bool Draft { get; set; }

        [Display(Name="Owner")] public virtual User Owner { get; set; }
        [Display(Name="OwnerId")] public int OwnerId { get; set; }
        [Display(Name="Likes")] public virtual IList<Like> Likes { get; set; }

        [Display(Name="Shares")] public virtual IList<Share> Shares { get; set; }

        [Display(Name="Comments")] public virtual IList<Comment> Comments { get; set; }


        [Display(Name="StoryTags")] public virtual IList<StoryTag> StoryTags { get; set; }


    }
}
