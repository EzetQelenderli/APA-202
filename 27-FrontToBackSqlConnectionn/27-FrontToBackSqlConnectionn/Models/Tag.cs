using _27_FrontToBackSqlConnectionn.Models.Base;

namespace _27_FrontToBackSqlConnectionn.Models
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; }
        public List<ProductTag> ProductTags{ get; set; }
    }
}
