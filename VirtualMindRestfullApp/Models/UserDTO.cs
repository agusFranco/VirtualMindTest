using System.ComponentModel.DataAnnotations;
using Domain;

namespace VirtualMindRestfullApp.Models
{
    public class UserDTO
    {        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public void ApplyTo(User user)
        {
            user.Id = Id;
            user.Name = Name;
            user.Password = Password;
            user.Email = Email;
            user.LastName = LastName;
        }
    }
}
