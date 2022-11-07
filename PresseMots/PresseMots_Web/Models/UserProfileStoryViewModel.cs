using PresseMots_DataModels.Entities;
using System.ComponentModel.DataAnnotations;

namespace PresseMots_Web.Models
{
    public class UserProfileStoryViewModel
    {
        public UserProfileStoryViewModel()
        {

        }


        public UserProfileStoryViewModel(Story model)
        {
            Id = model.Id;
            Title = model.Title;
        }

        public UserProfileStoryViewModel(int id, string title)
        {
            Id = id;
            Title = title;  
        }

        [Display(Name = "Id")] public int Id { get; set; }
        [Display(Name = "Title")] public string Title { get; set; }



    }
}