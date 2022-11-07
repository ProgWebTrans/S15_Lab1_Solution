using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresseMots_DataModels.Entities
{
    public class User
    {

        public User()
        {
            Stories = new List<Story>();
            Likes = new List<Like>();
            Shares = new List<Share>();
        }
        [Display(Name="Id")] public int Id { get; set; }
        [Display(Name="Username")] public string Username { get; set; }
        [Display(Name="Email")] public string Email { get; set; }
        [Display(Name="Password")] public string? Password { get; set; }

        [Display(Name="Stories")] public virtual List<Story> Stories { get; set; }
        [Display(Name="Likes")] public virtual List<Like> Likes { get; set; }
        [Display(Name="Shares")] public virtual List<Share> Shares { get; set; }
    }
}
