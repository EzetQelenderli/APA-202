using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnectionn.Models;

namespace _27_FrontToBackSqlConnectionn.Areas.AdminPanel.ViewModels
{
    public class ProductGetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string SKU { get; set; }
        public string CategoryName { get; set; }
        public string Image { get; set; }
    }
}
