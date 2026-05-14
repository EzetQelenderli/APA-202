using _27_FrontToBackSqlConnectionn.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnectionn.Models
{
    public class Category:BaseEntity
    {
        [Required(ErrorMessage ="Bos olmaz")]
        [MaxLength(30,ErrorMessage ="Yeniden daxil et")]
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
