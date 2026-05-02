using _10_GenericTypesCollections.Models;
using System.Diagnostics.CodeAnalysis;
using static System.Net.WebRequestMethods;
using static System.Reflection.Metadata.BlobBuilder;

namespace _10_GenericTypesCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new(1, "Martin Eden", "Jack London", 1909, 400);
            book1.DisplayInfo();
            Book book2 = new(2, "1984", "George Orwell", 1949, 328);
            book2.DisplayInfo();
            Book book3 = new(3, "Animal Farm", "George Orwell", 1945, 112);
            book3.DisplayInfo();
            Book book4 = new(4, "Ag Gemi", "Cingiz Aytmatov", 1970, 200);
            book4.DisplayInfo();
            Book book5 = new(5, "Qiriq Budaq", "Elcin", 1998, 350);
            book5.DisplayInfo();
            Console.WriteLine("-----------------------");
            List<Book> list = new();

            list.Add(book1);
            list.Add(book2);
            list.Add(book3);
            list.Add(book4);
            list.Add(book5);
            Console.WriteLine($"Kitab sayi:{list.Count}");
            Console.WriteLine($"indeksi 0 :{list[0].Title}");
            Console.WriteLine($"indeksi 2 :{list[2].Title}");
            Console.WriteLine($"Butun kitablar:");
            foreach (var book in list)
            {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine("----------------------------------");
            List<Member> members = new();
            Member member1 = new(1, "Ali Məmmədov", "ali@mail.com");
            members.Add(member1);
            Member member2 = new(2, "Leyla Həsənova", "leyla@mail.com");
            members.Add(member2);
            Member member3 = new(3, "Vüqar Əliyev", "ali@mail.com");
            members.Add(member3);

            members[0].BorrowBook(book1);
            members[0].BorrowBook(book2);
            Console.WriteLine("Borc kitablar:");
            members[0].DisplayBorrowedBooks();
            members[0].ReturnBook(1);
            Console.WriteLine("Borc kitablar:");
            members[0].DisplayBorrowedBooks();
            members[0].BorrowBook(book3);
            members[0].BorrowBook(book4);
            //members[0]BorrowBook(book5);
            Console.WriteLine("---------------------------------");
            BookManager bookManager = new BookManager();
            bookManager.AddBook(book1);
            bookManager.AddBook(book2);
            bookManager.AddBook(book3);
            bookManager.AddBook(book4);
            bookManager.AddBook(book5);
            Console.WriteLine("George Orwell kitablari:");
            var GeorgeOrwellBooks = bookManager.GetBooksByAuthor("George Orwell");

            foreach (var item in GeorgeOrwellBooks)
            {

                item.DisplayInfo();

            }


            Console.WriteLine("Cingiz Aytmatov kitablari:");
            var CingizAytmatovBooks = bookManager.GetBooksByAuthor("Cingiz Aytmatov");

            foreach (var item in CingizAytmatovBooks)
            {

                item.DisplayInfo();
            }


            Console.WriteLine("Jack London kitablari:");
            var JackLondonBooks = bookManager.GetBooksByAuthor("Jack London");

            foreach (var item in JackLondonBooks)
            {

                item.DisplayInfo();

            }

            //Console.WriteLine("Dostoyevski kitablari:");
            //var DostoyevskiBooks = bookManager.GetBooksByAuthor("Dostoyevski");

            //foreach (var item in Dostoyevski)
            //{

            //    item.DisplayInfo();

            //}
            Console.WriteLine("------------------------------------");
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Nigar");
            queue.Enqueue("Resad");
            queue.Enqueue("Sebine");
            Console.WriteLine("Novbedekiler:" + queue.Count());
            Console.WriteLine("Xidmet edildi:" + queue.Dequeue());
            Console.WriteLine("Xidmet edildi:" + queue.Dequeue());
            Console.WriteLine("Novbedekiler:" + queue.Count());
            Console.WriteLine("Xidmet edildi:" + queue.Dequeue());
            Console.WriteLine("Novbe bosdur:" + (queue.Count == 0));
            Console.WriteLine("---------------------------------");
            Stack<Book> stack = new Stack<Book>();
            stack.Push(book1);
            stack.Push(book2);
            stack.Push(book3);
            Console.WriteLine("Gozlenilen:" + stack.Count());
            Console.WriteLine("Gozlenilen:");
            stack.Peek().DisplayInfo();
            Console.WriteLine("Cixarildi");
            stack.Pop().DisplayInfo();
            Console.WriteLine("Gozlenilen:" + stack.Count());
            Console.WriteLine("Son kitab:");
            stack.Peek().DisplayInfo();
            Library library = new();

            Console.WriteLine("Axtarilan kitab:");
            var foundBook = bookManager.SearchByTitle("1984");
            if ( foundBook!= null)
            {
                foundBook.DisplayInfo();
            }

            Console.WriteLine("Olmayan kitab:");
            var foundBook1 = bookManager.SearchByTitle("Harry Potter");
            if (foundBook1 == null)
            {

                Console.WriteLine("Not found");
            }

           
            Console.WriteLine("Umumi kitab sayi: " + bookManager.Books.Count);


            Console.WriteLine("Umumi uzv sayi: " + members.Count);


            Console.WriteLine("Novbe sayi: " + bookManager.WaitingQueue.Count);


            Console.WriteLine("  Stack-de Kitab sayi: " + bookManager.RecentlyReturned.Count);

            int min = int.MaxValue;
            int max = int.MinValue;

            foreach (var b in bookManager.Books)
            {
                if (b.Year < min) min = b.Year;
                if (b.Year > max) max = b.Year;
            }

            Console.WriteLine("En kohne: " + min);


            Console.WriteLine("En yeni: " + max);
        }
    }
}
