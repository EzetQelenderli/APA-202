namespace _27_FrontToBackSqlConnectionn.Services
{
    public class TestService : IEmailService
    {
        public string OffEmail { get; set; }

        public void SendEmail()
        {
            Console.WriteLine("Test SErvice");
        }
    }
}
