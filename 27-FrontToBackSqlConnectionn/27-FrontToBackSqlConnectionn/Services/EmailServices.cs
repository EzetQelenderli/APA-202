using static _27_FrontToBackSqlConnectionn.Services.IEmailServices;

namespace _27_FrontToBackSqlConnectionn.Services
{
    public class EmailServices
    {

    
        public class EmailService : IEmailService
        {
            public string OffEmail { get; set; }


            public EmailService()
            {
                throw new Exception();
            }
            public void SendEmail()
            {
                Console.WriteLine("Send mail!");
            }
        }
    }
}
}
