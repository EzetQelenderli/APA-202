class Program
{
    public static void Main()
    {
        int[] numbers = { 2, 4, 6, 8 };
        int a = 10;
        int b = 12;
        CustomArrResize(ref numbers, a, b);
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }
    static void CustomArrResize(ref int[] arr, params int[] num)
    {
        int[] newArr = new int[arr.Length + num.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            newArr[i] = arr[i];
        }
        for (int i = 0; i < num.Length; i++)
        {
            newArr[arr.Length + i] = num[i];
        }
        arr = newArr;
    }
}

