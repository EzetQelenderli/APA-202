using System;
using System.Collections.Generic;
using System.Text;
internal class Person
{
    public string Name;
    public string Surname;
    public int Age;
    public string Email;
    public string Id;
    public Person(string name, string surname, int age, string email, string id)
    {
        this.Name = name;
        this.Surname = surname;
        this.Age = age;
        this.Email = email;
        this.Id = id;

    }
    public string GetFullName()
    {
        return Name + " " + Surname;
    }
    public void ShowBasicInfo()
    {
        //Console.WriteLine($"name:{Name},surname:{Surname},age:{Age},Email:{Email},id:{Id}");
        Console.WriteLine("--------------------------------------------------------------");
        Console.WriteLine($"Name:{Name}");
        Console.WriteLine($"Surname:{Surname}");
        Console.WriteLine($"Age:{Age}");
        Console.WriteLine($"Email:{Email}");
        Console.WriteLine($"Id:{Id}");
        Console.WriteLine("--------------------------------------------------------------");


    }
}
