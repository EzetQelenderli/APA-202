using _27_FrontToBackSqlConnectionn.Models;

namespace _27_FrontToBackSqlConnectionn.Areas.AdminPanel.ViewModels
{
    public class ProductUpdateVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string Description { get; set; }
        public List<int>? TagIDs { get; set; }

        public int? CategoryId { get; set; }
        public List<Category>? Categories { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}
