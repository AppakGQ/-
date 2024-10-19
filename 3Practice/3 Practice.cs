using System;
using System.Collections.Generic;

public class Member
{
    public string FullName { get; set; }
    public string Contact { get; set; }
    public string UserType { get; set; }

    public Member(string fullName, string contact, string userType)
    {
        FullName = fullName;
        Contact = contact;
        UserType = userType;
    }
}

public class MemberManager
{
    private List<Member> members = new List<Member>();

    public void AddMember(string fullName, string contact, string userType)
    {
        members.Add(new Member(fullName, contact, userType));
    }

    public void RemoveMember(string contact)
    {
        members.RemoveAll(m => m.Contact == contact);
    }

    public void UpdateMember(string contact, string newFullName, string newUserType)
    {
        Member member = members.Find(m => m.Contact == contact);
        if (member != null)
        {
            member.FullName = newFullName;
            member.UserType = newUserType;
        }
    }

    public void DisplayMembers()
    {
        foreach (var member in members)
        {
            Console.WriteLine($"Full Name: {member.FullName}, Contact: {member.Contact}, User Type: {member.UserType}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        MemberManager memberManager = new MemberManager();
        memberManager.AddMember("Иван Петров", "ivan.petrov@example.com", "Администратор");
        memberManager.AddMember("Анна Смирнова", "anna.smirnova@example.com", "Обычный пользователь");

        Console.WriteLine("Члены после добавления:");
        memberManager.DisplayMembers();

        memberManager.UpdateMember("ivan.petrov@example.com", "Иван Иванов", "Супер администратор");
        Console.WriteLine("\nЧлены после обновления Ивана:");
        memberManager.DisplayMembers();

        memberManager.RemoveMember("anna.smirnova@example.com");
        Console.WriteLine("\nЧлены после удаления Анны:");
        memberManager.DisplayMembers();
    }
}
