using _27_FrontToBackSqlConnectionn.Models;
using _27_FrontToBackSqlConnectionn.Models.Base;

namespace _27_FrontToBackSqlConnection.Models
{
    public class ProductImage : BaseEntity
    {
        public string Image { get; set; }
        public bool? IsPrimary { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}