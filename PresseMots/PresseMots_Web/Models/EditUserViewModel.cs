using PresseMots_DataModels.Entities;
using System.ComponentModel.DataAnnotations;

namespace PresseMots_Web.Models
{
    public class EditUserViewModel : AddUserViewModel
    {
        public EditUserViewModel()
        {

        }

        public EditUserViewModel(User user)
        {
            if (user == null) return;
            this.Id = user.Id;
            this.Username = user.Username;
            this.Email = user.Email;

        }

        public EditUserViewModel(int? id, string username, string email, string password, string confirmPassword,string oldPassword):base(id,  username,  email,  password,  confirmPassword)
        {
            OldPassword = oldPassword;
        }

        [Display(Name = "Old password")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
    }
}
