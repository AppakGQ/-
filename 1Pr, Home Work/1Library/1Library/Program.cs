using System;
using System.Collections.Generic;

public class Publication
{
    public string Name { get; set; }
    public string Writer { get; set; }
    public int AvailableCopies { get; set; }

    public Publication(string name, string writer, int availableCopies)
    {
        Name = name;
        Writer = writer;
        AvailableCopies = availableCopies;
    }
}

public class User
{
    public string FullName { get; set; }
    public int UserId { get; set; }

    public User(string fullName, int userId)
    {
        FullName = fullName;
        UserId = userId;
    }
}

public class Bookstore
{
    private List<Publication> publications = new List<Publication>();
    private List<User> users = new List<User>();

    public void AddPublication(Publication publication) => publications.Add(publication);
    public void RegisterUser(User user) => users.Add(user);

    public void LendPublication(int userId, string publicationName)
    {
        Publication publication = publications.Find(p => p.Name == publicationName);
        if (publication != null && publication.AvailableCopies > 0)
        {
            publication.AvailableCopies--;
            Console.WriteLine($"{publicationName} выдано пользователю {userId}.");
        }
        else
        {
            Console.WriteLine($"Публикация {publicationName} недоступна.");
        }
    }

    public void AcceptPublication(string publicationName)
    {
        Publication publication = publications.Find(p => p.Name == publicationName);
        if (publication != null)
        {
            publication.AvailableCopies++;
            Console.WriteLine($"{publicationName} возвращена.");
        }
    }
}

public class Program
{
    public static void Main()
    {
        Bookstore bookstore = new Bookstore();

        bookstore.AddPublication(new Publication("Властелин колец", "Дж. Р. Р. Толкин", 3));
        bookstore.AddPublication(new Publication("451 градус по Фаренгейту", "Рэй Брэдбери", 2));

        bookstore.RegisterUser(new User("Сергей", 1));
        bookstore.RegisterUser(new User("Ольга", 2));

        bookstore.LendPublication(1, "Властелин колец");
        bookstore.AcceptPublication("Властелин колец");
    }
}
