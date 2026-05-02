using System;
using System.Collections.Generic;
using System.Text;

internal class Administrator : Person
{
    public string Position;
    public string Department;
    public int AccessLevel;
    public Administrator(string name, string surname, int age, string email, string id, string position, string department, int accesslevel) : base(name, surname, age, email, id)
    {
        this.Position = position;
        this.Department = department;
        this.AccessLevel = accesslevel;
    }
    public void ShowAdminInfo()
    {
        //Console.WriteLine($"name:{Name},surname:{Surname},age:{Age},Email:{Email},id:{Id},Position:{Position},Department:{Department},Accesslevel:{AccessLevel}");
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine($"Name:{Name}");
        Console.WriteLine($"Surname:{Surname}");
        Console.WriteLine($"Age:{Age}");
        Console.WriteLine($"Email:{Email}");
        Console.WriteLine($"Id:{Id}");
        Console.WriteLine($"Position:{Position}");
        Console.WriteLine($"Department:{Department}");
        Console.WriteLine($"Accesslevel:{AccessLevel}");
        Console.WriteLine("--------------------------------------------------------------");


    }
    public void GrantAccess(Student student)
    {
        Console.WriteLine($"{student.Name} - Telebeye sistem girişi verir!!!");
    }

}

