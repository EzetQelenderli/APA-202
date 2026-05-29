using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace _27_FrontToBackSqlConnectionn.ViewModels
{
    public class RegisterVM
    {
        [MinLength(3)]
        [MaxLength(20)] 
        public string Name { get; set; }
        [MinLength(3)]
        [MaxLength(20)]
        public string Surname { get; set; }
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }
        [MaxLength(20)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password{ get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
