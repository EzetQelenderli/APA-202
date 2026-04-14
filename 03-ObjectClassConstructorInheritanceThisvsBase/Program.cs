

//Person person1 = new Person("Zeyneb", "Eliyeva", 20, "zeynebeliyeva@gmail.com", "1");
//person1.ShowBasicInfo();
//Console.WriteLine(person1.GetFullName());


Student student1 = new Student("Zeyneb", "Eliyeva", 20, "zeynebeliyeva@gmail.com", "1", "A1", "ITT", 88.5, 3);
Student student2 = new Student("Zehra", "Abbasova", 26, "zehraabbasova.@gmail.com", "2", "A2", "ITT", 92, 5);
Student student3 = new Student("nermin", "Eliyeva", 20, "nermineliyeva@gmail.com", "1", "A1", "ITT", 68.5, 3);
student1.ShowStudentInfo();
student2.ShowStudentInfo();
student3.ShowStudentInfo();
Console.WriteLine("Scholarship:" + student1.CalculateScholarship() + "AZN");
Console.WriteLine("Scholarship:" + student2.CalculateScholarship() + "AZN");
Console.WriteLine("Scholarship:" + student3.CalculateScholarship() + "AZN");


Teacher teacher1 = new Teacher("Nezrin", "Abbasova", 30, "nezrinabbasova@gmail.com", "1", "texniki fennler", "Riyaziyyat", 800, 15);
Teacher teacher2 = new Teacher("Gulcin", "Eliyeva", 20, "gulcineliyeva@gmail.com", "1", "texniki fennler", "Fizika", 800, 8);
teacher1.ShowTeacherInfo();
teacher2.ShowTeacherInfo();
Console.WriteLine("maas:" + teacher1.CalculateSalary());
Console.WriteLine("maas:" + teacher2.CalculateSalary());


Administrator administrator1 = new Administrator("Natiq", "Agaverdiyev", 24, "natiqagaverdiyev@gmail.com", "1", "dekan", "mexatronika", 3);
administrator1.ShowAdminInfo();
administrator1.GrantAccess(student1);


decimal GeneralMany = 0;

GeneralMany += student1.CalculateScholarship();
GeneralMany += student2.CalculateScholarship();
GeneralMany += student3.CalculateScholarship();

decimal GeneralSAlary = 0;
GeneralSAlary += teacher1.CalculateSalary();
GeneralSAlary += teacher2.CalculateSalary();




Console.WriteLine("----------------------------------------------------");
Console.WriteLine($"Teqaudkerin Cemi : {GeneralMany}");

Console.WriteLine($"Maas xerci:{GeneralSAlary}");