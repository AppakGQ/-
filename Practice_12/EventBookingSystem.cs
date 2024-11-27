
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = new EventSystem();
            system.InitializeTestData();
            system.Run();
        }
    }

    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; } // Guest, User, Admin
    }

    public class Booking
    {
        public int ID { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
        public string Status { get; set; } // Confirmed, Cancelled
    }

    public class EventSystem
    {
        private List<Event> events = new List<Event>();
        private List<User> users = new List<User>();
        private List<Booking> bookings = new List<Booking>();
        private User currentUser;

        public void InitializeTestData()
        {
            events.Add(new Event { ID = 1, Name = "Music Concert", Date = DateTime.Now.AddDays(10), Location = "Hall A" });
            events.Add(new Event { ID = 2, Name = "Tech Conference", Date = DateTime.Now.AddDays(20), Location = "Hall B" });

            users.Add(new User { ID = 1, Name = "Alice", Role = "Admin" });
            users.Add(new User { ID = 2, Name = "Bob", Role = "User" });
            users.Add(new User { ID = 3, Name = "Charlie", Role = "Guest" });

            currentUser = users.First(); // Default to Admin
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine($"Logged in as: {currentUser.Name} ({currentUser.Role})");
                Console.WriteLine("1. View Events");
                Console.WriteLine("2. Book Event");
                Console.WriteLine("3. Cancel Booking");
                if (currentUser.Role == "Admin")
                {
                    Console.WriteLine("4. Add Event");
                    Console.WriteLine("5. Edit Event");
                    Console.WriteLine("6. Delete Event");
                    Console.WriteLine("7. View All Bookings");
                }
                Console.WriteLine("0. Exit");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": ViewEvents(); break;
                    case "2": BookEvent(); break;
                    case "3": CancelBooking(); break;
                    case "4": if (currentUser.Role == "Admin") AddEvent(); break;
                    case "5": if (currentUser.Role == "Admin") EditEvent(); break;
                    case "6": if (currentUser.Role == "Admin") DeleteEvent(); break;
                    case "7": if (currentUser.Role == "Admin") ViewAllBookings(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        private void ViewEvents()
        {
            foreach (var e in events)
            {
                Console.WriteLine($"ID: {e.ID}, Name: {e.Name}, Date: {e.Date}, Location: {e.Location}");
            }
        }

        private void BookEvent()
        {
            Console.WriteLine("Enter Event ID to book:");
            if (int.TryParse(Console.ReadLine(), out int eventId))
            {
                var ev = events.FirstOrDefault(e => e.ID == eventId);
                if (ev != null)
                {
                    var booking = new Booking
                    {
                        ID = bookings.Count + 1,
                        User = currentUser,
                        Event = ev,
                        Status = "Confirmed"
                    };
                    bookings.Add(booking);
                    Console.WriteLine("Event booked successfully.");
                }
                else
                {
                    Console.WriteLine("Event not found.");
                }
            }
        }

        private void CancelBooking()
        {
            Console.WriteLine("Enter Booking ID to cancel:");
            if (int.TryParse(Console.ReadLine(), out int bookingId))
            {
                var booking = bookings.FirstOrDefault(b => b.ID == bookingId && b.User.ID == currentUser.ID);
                if (booking != null)
                {
                    booking.Status = "Cancelled";
                    Console.WriteLine("Booking cancelled successfully.");
                }
                else
                {
                    Console.WriteLine("Booking not found or not authorized.");
                }
            }
        }

        private void AddEvent()
        {
            Console.WriteLine("Enter Event Name:");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Event Date (yyyy-MM-dd):");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Enter Event Location:");
                var location = Console.ReadLine();
                var ev = new Event { ID = events.Count + 1, Name = name, Date = date, Location = location };
                events.Add(ev);
                Console.WriteLine("Event added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid date.");
            }
        }

        private void EditEvent()
        {
            Console.WriteLine("Enter Event ID to edit:");
            if (int.TryParse(Console.ReadLine(), out int eventId))
            {
                var ev = events.FirstOrDefault(e => e.ID == eventId);
                if (ev != null)
                {
                    Console.WriteLine("Enter new Event Name (leave blank to keep current):");
                    var name = Console.ReadLine();
                    Console.WriteLine("Enter new Event Date (yyyy-MM-dd, leave blank to keep current):");
                    var dateInput = Console.ReadLine();
                    Console.WriteLine("Enter new Event Location (leave blank to keep current):");
                    var location = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(name)) ev.Name = name;
                    if (!string.IsNullOrWhiteSpace(dateInput) && DateTime.TryParse(dateInput, out DateTime date)) ev.Date = date;
                    if (!string.IsNullOrWhiteSpace(location)) ev.Location = location;

                    Console.WriteLine("Event updated successfully.");
                }
                else
                {
                    Console.WriteLine("Event not found.");
                }
            }
        }

        private void DeleteEvent()
        {
            Console.WriteLine("Enter Event ID to delete:");
            if (int.TryParse(Console.ReadLine(), out int eventId))
            {
                var ev = events.FirstOrDefault(e => e.ID == eventId);
                if (ev != null)
                {
                    events.Remove(ev);
                    Console.WriteLine("Event deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Event not found.");
                }
            }
        }

        private void ViewAllBookings()
        {
            foreach (var b in bookings)
            {
                Console.WriteLine($"ID: {b.ID}, User: {b.User.Name}, Event: {b.Event.Name}, Status: {b.Status}");
            }
        }
    }
}
