//1
//class Program
//{

//    static void Main()
//    {
//        Parametrs(12, 18);
//    }
//    public static void Parametrs(int a, int b)
//    {
//        int toplama = a + b;
//        int cixma = a - b;
//        int vurma = a * b;
//        int bolme = a / b;
//        Console.WriteLine("cem:" + toplama);
//        Console.WriteLine("ferq:" + cixma);
//        Console.WriteLine("hasil:" + vurma);
//        Console.WriteLine("qaliq:" + bolme);
//    }
//}



//2 /

//class Program
//{
//    static void Main()
//    {
//        int[] numbers = { 14, 20, 35, 40, 57, 60, 100 };
//        Argument(numbers);

//    }
//    public static void Argument(int[] a)
//    {

//        for (int i = 0; i < a.Length; i++)
//        {
//            if (a[i] % 2 == 0)
//            {
//                Console.WriteLine(a[i] + "-cut");
//            }
//            else
//            {

//                Console.WriteLine(a[i] + "-tek");
//            }
//        }
//    }
//}


////3 /
//class program
//{
//    static void Main()
//    {
//        int[] numbers = { 14, 20, 35, 40, 57, 60, 100 };
//        int cem = Arrives(numbers);
//        Console.WriteLine(cem);
//        Console.ReadLine();
//    }
//    public static int Arrives(int[] a)
//    {
//        int cem = 0;
//        for (int i = 0; i < a.Length; i++)
//        {
//            if (a[i] % 4 == 0)
//            {
//                cem += a[i];
//            }
//            if (a[i] % 5 == 0)
//            {
//                cem += a[i];
//            }
//        }
//        return cem;
//    }
//}


////4 /
//class program
//{
//    static void Main()
//    {
//        string cumle;
//        int herf = 0;
//        char simvol;
//        Console.WriteLine("soz daxil et");
//        cumle = Console.ReadLine();
//        Console.WriteLine("simvol daxil et");
//        simvol = Convert.ToChar(Console.ReadLine());
//        for (int i = 0; i < cumle.Length; i++)
//        {
//            if (cumle[i] == simvol)
//            {
//                herf++;
//            }
//        }
//        Console.WriteLine("herfin sayi" + herf);

//    }
//}
