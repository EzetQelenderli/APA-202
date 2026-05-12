using _27_FrontToBackSqlConnectionn.Models;

namespace _27_FrontToBackSqlConnectionn.ViewModels
{
    public class DetailVM
    {
        public Product Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
    }
}
