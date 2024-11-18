using System;
using System.Collections.Generic;

class Hotel
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string RoomClass { get; set; }
    public decimal PricePerNight { get; set; }

    public Hotel(string name, string location, string roomClass, decimal price)
    {
        Name = name;
        Location = location;
        RoomClass = roomClass;
        PricePerNight = price;
    }
}

class Booking
{
    public string User { get; set; }
    public Hotel Hotel { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public bool IsPaid { get; set; }

    public Booking(string user, Hotel hotel, DateTime checkIn, DateTime checkOut)
    {
        User = user;
        Hotel = hotel;
        CheckIn = checkIn;
        CheckOut = checkOut;
    }
}

class HotelService
{
    private List<Hotel> hotels = new List<Hotel>();

    public void AddHotel(Hotel hotel) => hotels.Add(hotel);

    public List<Hotel> SearchHotels(string location, string roomClass, decimal maxPrice) =>
        hotels.FindAll(h => h.Location == location && h.RoomClass == roomClass && h.PricePerNight <= maxPrice);
}

class BookingService
{
    private List<Booking> bookings = new List<Booking>();

    public bool BookRoom(string user, Hotel hotel, DateTime checkIn, DateTime checkOut)
    {
        if (bookings.Exists(b => b.Hotel == hotel && b.CheckIn < checkOut && b.CheckOut > checkIn)) return false;
        bookings.Add(new Booking(user, hotel, checkIn, checkOut));
        return true;
    }

    public List<Booking> GetUserBookings(string user) => bookings.FindAll(b => b.User == user);
}

class PaymentService
{
    public bool ProcessPayment(decimal amount, string method) => true;
}

class NotificationService
{
    public void SendNotification(string user, string message) => Console.WriteLine($"Notification to {user}: {message}");
}

class UserManagementService
{
    private HashSet<string> users = new HashSet<string>();

    public bool Register(string username) => users.Add(username);

    public bool Login(string username) => users.Contains(username);
}

class Program
{
    static void Main()
    {
        HotelService hotelService = new HotelService();
        BookingService bookingService = new BookingService();
        PaymentService paymentService = new PaymentService();
        NotificationService notificationService = new NotificationService();
        UserManagementService userManagementService = new UserManagementService();

        hotelService.AddHotel(new Hotel("Grand Hotel", "Paris", "Luxury", 250m));
        hotelService.AddHotel(new Hotel("Budget Inn", "Paris", "Economy", 50m));

        Console.Write("Введите имя пользователя для регистрации: ");
        string username = Console.ReadLine();
        if (!userManagementService.Register(username))
        {
            Console.WriteLine("Пользователь уже существует.");
            return;
        }

        Console.WriteLine("Поиск отелей...");
        var availableHotels = hotelService.SearchHotels("Paris", "Luxury", 300m);
        foreach (var hotel in availableHotels)
            Console.WriteLine($"{hotel.Name} - {hotel.RoomClass} - {hotel.PricePerNight:C}");

        Console.WriteLine("Введите номер отеля для бронирования: 1");
        var selectedHotel = availableHotels[0];

        Console.WriteLine("Введите даты бронирования (в формате yyyy-MM-dd):");
        DateTime checkIn = DateTime.Parse(Console.ReadLine());
        DateTime checkOut = DateTime.Parse(Console.ReadLine());

        if (!bookingService.BookRoom(username, selectedHotel, checkIn, checkOut))
        {
            Console.WriteLine("Номер недоступен для бронирования.");
            return;
        }

        if (paymentService.ProcessPayment(selectedHotel.PricePerNight * (checkOut - checkIn).Days, "Card"))
        {
            notificationService.SendNotification(username, "Ваше бронирование подтверждено.");
            Console.WriteLine("Бронирование успешно завершено.");
        }
        else
        {
            Console.WriteLine("Ошибка при обработке платежа.");
        }
    }
}
