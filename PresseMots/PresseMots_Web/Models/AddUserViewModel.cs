using PresseMots_DataModels.Entities;
using System.ComponentModel.DataAnnotations;

namespace PresseMots_Web.Models
{
    public class AddUserViewModel
    {
        public AddUserViewModel(int? id, string username, string email, string password, string confirmPassword)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public AddUserViewModel(User user)
        {
            if (user == null) return;
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
           

        }

        public AddUserViewModel()
        {

        }

        public int? Id { get; set; }
        [Display(Name = "Username")]
        [StringLength(100)]
        public string Username { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "ConfirmPassword")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
