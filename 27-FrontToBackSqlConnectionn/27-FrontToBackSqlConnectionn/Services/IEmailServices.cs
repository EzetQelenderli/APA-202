namespace _27_FrontToBackSqlConnectionn.Services
{
    public class IEmailServices
    {
        public interface IEmailService
        {
            string OffEmail { get; set; }

            public void SendEmail();

        }
    }
}
