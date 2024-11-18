using System;
using System.Collections.Generic;
using System.Linq;

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsAvailable { get; set; } = true;

    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
    }
}

class Reader
{
    public string Name { get; set; }
    public List<Book> BorrowedBooks { get; set; } = new List<Book>();
    public int MaxBooksLimit { get; set; } = 3;

    public Reader(string name)
    {
        Name = name;
    }

    public bool BorrowBook(Book book)
    {
        if (BorrowedBooks.Count >= MaxBooksLimit)
        {
            Console.WriteLine($"{Name} уже арендовал максимальное количество книг.");
            return false;
        }

        if (book.IsAvailable)
        {
            book.IsAvailable = false;
            BorrowedBooks.Add(book);
            Console.WriteLine($"Книга \"{book.Title}\" успешно арендована {Name}.");
            return true;
        }
        else
        {
            Console.WriteLine($"Книга \"{book.Title}\" недоступна для аренды.");
            return false;
        }
    }

    public void ReturnBook(Book book)
    {
        if (BorrowedBooks.Remove(book))
        {
            book.IsAvailable = true;
            Console.WriteLine($"Книга \"{book.Title}\" успешно возвращена {Name}.");
        }
        else
        {
            Console.WriteLine($"Книга \"{book.Title}\" не была арендована {Name}.");
        }
    }
}

class Librarian
{
    public string Name { get; set; }

    public Librarian(string name)
    {
        Name = name;
    }
}

class Library
{
    public List<Book> Books { get; set; } = new List<Book>();

    public void DisplayBooks(bool includeBorrowed = false)
    {
        Console.WriteLine("Список книг в библиотеке:");
        foreach (var book in Books)
        {
            if (includeBorrowed || book.IsAvailable)
            {
                string status = book.IsAvailable ? "В наличии" : "Арендована";
                Console.WriteLine($"{book.Title} - {book.Author} (ISBN: {book.ISBN}) [{status}]");
            }
        }
    }

    public Book SearchBook(string searchTerm)
    {
        return Books.FirstOrDefault(b => b.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                                         b.Author.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();
        library.Books.Add(new Book("Война и мир", "Лев Толстой", "123-456"));
        library.Books.Add(new Book("Преступление и наказание", "Федор Достоевский", "789-101"));
        library.Books.Add(new Book("Мастер и Маргарита", "Михаил Булгаков", "112-131"));

        Reader reader = new Reader("Аппак");
        Librarian librarian = new Librarian("Салтанат");

        library.DisplayBooks();
        Book bookToBorrow = library.SearchBook("Война и мир");
        if (bookToBorrow != null)
        {
            reader.BorrowBook(bookToBorrow);
        }

        library.DisplayBooks(includeBorrowed: true);

        reader.ReturnBook(bookToBorrow);

        library.DisplayBooks();
    }
}
