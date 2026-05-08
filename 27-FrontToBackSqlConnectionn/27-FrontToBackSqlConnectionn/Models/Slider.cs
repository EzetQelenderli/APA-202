using _27_FrontToBackSqlConnectionn.Models.Base;

namespace _27_FrontToBackSqlConnectionn.Models
{
    public class Slider:BaseEntity
    {

        public string Image { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }



    }
}
