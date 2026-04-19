using System;
using System.Collections.Generic;
using System.Text;

namespace _10_GenericTypesCollections.Models
{
    internal class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Book> BorrowedBooks { get; set; }
        public Member(int id, string name, string email)
        {

            Id = id;
            Name = name;
            Email = email;
            BorrowedBooks = new List<Book>();
            
        }
        public void BorrowBook(Book book)
        {
            if (BorrowedBooks.Count >= 3)
            {
                Console.WriteLine("Maksimum 3 kitab goture bilersiniz!!");
                return;
            }
            BorrowedBooks.Add(book);
            Console.WriteLine($"Kitab goturuldu:{book.Title}");
        }
        public void ReturnBook(int bookId)
        {
            Book foundBook = null;
            foreach (Book book in BorrowedBooks)
            {
                if (book.Id == bookId)
                {
                    foundBook = book;
                    break;
                }
                if (foundBook!=null)
                {
                    BorrowedBooks.Remove(foundBook);
                    Console.WriteLine($"Kitab qaytarildi:{foundBook.Title}");
                }

            } 
            
        }
        public void DisplayBorrowedBooks()
        {
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("Borc kitab yoxdur!");
            }
            foreach (Book book in BorrowedBooks)
            {
                Console.WriteLine($"Id:{book.Id},Title:{book.Title},Author:{book.Author},Year:{book.Year},PageCount:{book.PageCount}");
            }
        }
    }
}
