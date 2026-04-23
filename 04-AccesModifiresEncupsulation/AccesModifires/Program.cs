using System.Runtime.ConstrainedExecution;
using AccesModifires.Models;

namespace AccesModifires
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            {
                // Person person = new Person();

                //// Student student = new Student();
                //// student.Name = "Test";
                //// Console.WriteLine(student.Name);
                //typeof(Person).GetField("Name",BindingFlags.NonPublic | BindingFlags.Instance).SetValue(person, "APA202");
                // var newName = typeof(Person).GetField("Name", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(person);
                // Console.WriteLine(newName);
                Car car = new Car();
                car.HorsePower = 60;
                Console.WriteLine(car.HorsePower);
            }
        }
    }
}
