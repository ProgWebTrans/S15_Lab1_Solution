using PresseMots_DataModels.Entities;
using System.Collections.Generic;

namespace PresseMots_Web.Models
{
    public class CommentViewModel
    {

        public int WordCount { get; set; }
        public string ShortTitle { get; set; }
        public string ShortStory { get; set; }
        public int? StoryId { get; set; }
        public List<Comment> Comments { get; internal set; }
    }
}
