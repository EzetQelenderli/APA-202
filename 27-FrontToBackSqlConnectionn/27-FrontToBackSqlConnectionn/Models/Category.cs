using _27_FrontToBackSqlConnectionn.Models.Base;

namespace _27_FrontToBackSqlConnectionn.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
