namespace _27_FrontToBackSqlConnectionn.Models.Base
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
