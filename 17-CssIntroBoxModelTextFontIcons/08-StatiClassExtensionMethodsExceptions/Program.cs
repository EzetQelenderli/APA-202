using _08_StatiClassExtensionMethodsExceptions.Exceptions;
using _08_StatiClassExtensionMethodsExceptions.Models;

namespace _08_StatiClassExtensionMethodsExceptions
{
    internal class Program
    {
        static void Main(string[] args)

        {
            //LoginSystem = new LoginSystem(Console.ReadLine());
            LoginSystem loginSystem = new LoginSystem("");
           


         
            while (true)
            {
                
                try
                {
                    Console.WriteLine("Username:");
                    string username = Console.ReadLine();

                    Console.WriteLine("Password:");
                    string password = Console.ReadLine();

                    loginSystem.Login(username, password);
                    Console.WriteLine("Giris ugurludur!");
                    break;
                }
                catch (InvalidUsernameException ex)
                {
                    Console.WriteLine("ERROR:" + ex.Message);
                }
                catch (InvalidPasswordException ex)
                {
                    Console.WriteLine("ERROR" + ex.Message);
                }
                catch (UserNotFoundException ex)
                {
                    Console.WriteLine("ERROR:" + ex.Message);
                    loginSystem.ShowUser();
                }
                catch (IncorrectPasswordException ex)
                {
                    Console.WriteLine("WARNING!!:" + ex.Message);
                }
                catch (AccountLockedException ex)
                {
                    Console.WriteLine("CRITICAL:" + ex.Message + "contact admin");

                }
                catch (Exception ex)
                {

                    Console.WriteLine("UNEXPECTED ERROR: " + ex.Message);
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
