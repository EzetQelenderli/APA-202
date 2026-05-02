using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

internal class Teacher : Person
{
    public string Department;
    public string MainSubject;
    public decimal BaseSalary;
    public int ExperienceYears;
    public Teacher(string name, string surname, int age, string email, string id, string department, string mainsubject, decimal basesalary, int experienceyears) : base(name, surname, age, email, id)
    {
        this.Department = department;
        this.MainSubject = mainsubject;
        this.BaseSalary = basesalary;
        this.ExperienceYears = experienceyears;
    }
    public void ShowTeacherInfo()
    {
        //Console.WriteLine($"name:{Name},surname:{Surname},age:{Age},Email:{Email},id:{Id},department:{Department},mainsubject:{MainSubject},basesalary:{BaseSalary},experienceYears:{ExperienceYears},maas:{CalculateSalary()}");


        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine($"Name:{Name}");
        Console.WriteLine($"Surname:{Surname}");
        Console.WriteLine($"Age:{Age}");
        Console.WriteLine($"Email:{Email}");
        Console.WriteLine($"Id:{Id}");
        Console.WriteLine($"Department:{Department}");
        Console.WriteLine($"Mainsubject:{MainSubject}");
        Console.WriteLine($"Basesalary:{BaseSalary}");
        Console.WriteLine($"ExperienceYears:{ExperienceYears}");
        Console.WriteLine($"Maas:{CalculateSalary()}");
        Console.WriteLine("--------------------------------------------------------------");
    }
    public decimal CalculateSalary()
    {
        return BaseSalary + (ExperienceYears * 50);
    }
}

