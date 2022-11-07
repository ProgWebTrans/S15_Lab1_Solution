using PresseMots_DataModels.Entities;
using System.ComponentModel.DataAnnotations;

namespace PresseMots_Web.Models
{
    public class SimpleUserViewModel
    {
        public SimpleUserViewModel()
        {

        }

        public SimpleUserViewModel(User model,int storiesCount)
        {
            this.Id = model.Id;
            this.Username = model.Username;
            this.Email = model.Email;
            this.StoriesCount = storiesCount; 
        }

        public SimpleUserViewModel(int id, string username, string email, int storiesCount)
        {
            Id = id;
            Username = username;
            Email = email;
            StoriesCount = storiesCount;
        }


       
        public int Id { get; set; }

        [Display(Name="Username")]
        [StringLength(100)]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Stories' count")]
        public int StoriesCount { get; set; }
    }
}
