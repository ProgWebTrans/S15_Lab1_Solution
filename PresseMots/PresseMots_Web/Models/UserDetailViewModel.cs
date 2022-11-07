using PresseMots_DataModels.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresseMots_Web.Models
{
    public class UserProfileViewModel
    {
        public UserProfileViewModel()
        {

        }

        public UserProfileViewModel(User user, string searchTerm, bool authoredOpened, bool likedStoriesOpened, bool sharedStoriesOpened, bool likeableStoriesOpened, List<UserProfileStoryViewModel> authoredStories, List<UserProfileStoryViewModel> likedStories, List<UserProfileStoryViewModel> sharedStories, List<UserProfileStoryViewModel> likeableStories)
        {
            this.UserId = user.Id;
            this.SearchTerm = searchTerm;
            this.UserNameEmail = makeUserNameEmail(user.Username, user.Email);
            AuthoredOpened = authoredOpened;
            LikedStoriesOpened = likedStoriesOpened;
            SharedStoriesOpened = sharedStoriesOpened;
            LikeableStoriesOpened = likeableStoriesOpened;
            AuthoredStories = authoredStories;
            LikedStories = likedStories;
            SharedStories = sharedStories;
            LikeableStories = likeableStories;

        }


        public UserProfileViewModel(int userId, string searchTerm, string userName, string Email, bool authoredOpened, bool likedStoriesOpened, bool sharedStoriesOpened, bool likeableStoriesOpened, List<UserProfileStoryViewModel> authoredStories, List<UserProfileStoryViewModel> likedStories, List<UserProfileStoryViewModel> sharedStories, List<UserProfileStoryViewModel> likeableStories)
        {
            UserId = userId;
            SearchTerm = searchTerm;
            UserNameEmail = makeUserNameEmail(userName,Email);
            AuthoredOpened = authoredOpened;
            LikedStoriesOpened = likedStoriesOpened;
            SharedStoriesOpened = sharedStoriesOpened;
            LikeableStoriesOpened = likeableStoriesOpened;
            AuthoredStories = authoredStories;
            LikedStories = likedStories;
            SharedStories = sharedStories;
            LikeableStories = likeableStories;
        }

        private string makeUserNameEmail(string userName, string email)
        {
            var sb = new StringBuilder();
            sb.Append(userName)
                .Append(" (")
                .Append(email)
                .Append(")");
            return sb.ToString();
        }

        
        public  int UserId { get; set; }


        [Display(Name=" SearchTerm")]
        public string  SearchTerm { get; set; }


        [Display(Name="UserNameEmail")] 
        public string UserNameEmail { get; set; }


        [Display(Name="AuthoredOpened")]        public bool AuthoredOpened { get; set; }
        [Display(Name="LikedStoriesOpened")]    public bool LikedStoriesOpened { get; set; }
        [Display(Name="SharedStoriesOpened")]   public bool SharedStoriesOpened { get; set; }
        [Display(Name="LikeableStoriesOpened")] public bool LikeableStoriesOpened { get; set; }

        [Display(Name="AuthoredStories")] public List<UserProfileStoryViewModel> AuthoredStories { get; set; }
        [Display(Name="LikedStories")] public List<UserProfileStoryViewModel> LikedStories { get; set; }
        [Display(Name="SharedStories")] public List<UserProfileStoryViewModel> SharedStories { get; set; }
        [Display(Name="LikeableStories")] public List<UserProfileStoryViewModel> LikeableStories { get; set; }


    }
}
