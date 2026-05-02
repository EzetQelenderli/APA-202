using System;
using System.Collections.Generic;
using System.Text;
internal class Student : Person
{
    public string StudentNumber;
    public string Faculty;
    public double Gpa;
    public int Year;
    public Student(string name, string surname, int age, string email, string id, string studentnumber, string faculty, double gpa, int year)
        : base(name, surname, age, email, id)
    {
        this.StudentNumber = studentnumber;
        this.Faculty = faculty;
        this.Gpa = gpa;
        this.Year = year;
    }


    public void ShowStudentInfo()
    {
        //Console.WriteLine($"name:{Name},surname:{Surname},age:{Age},Email:{Email},id:{Id},studentnumber:{StudentNumber},faculty:{Faculty},gpa:{Gpa},year:{Year},Teqaüd:{CalculateScholarship()}");
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine($"Name:{Name}");
        Console.WriteLine($"Surname:{Surname}");
        Console.WriteLine($"Age:{Age}");
        Console.WriteLine($"Email:{Email}");
        Console.WriteLine($"Id:{Id}");
        Console.WriteLine($"Studentnumber:{StudentNumber}");
        Console.WriteLine($"Faculty:{Faculty}");
        Console.WriteLine($"Gpa:{Gpa}");
        Console.WriteLine($"Year:{Year}");
        Console.WriteLine($"Teqaüd:{CalculateScholarship()}");
        Console.WriteLine("--------------------------------------------------------------");
    }

    public int CalculateScholarship()
    {
        if (Gpa >= 90)
        {
            return 500;
        }
        else if (Gpa >= 80)
        {
            return 350;
        }
        else if (Gpa >= 70)
        {
            return 200;
        }
        else
        {
            return 0;
        }
    }


}