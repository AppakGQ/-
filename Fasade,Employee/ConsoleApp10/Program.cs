using System;

namespace MyNamespace
{

    public class RoomBookingSystem
    {
        public void Booking(DateTime startDay, DateTime endDay, int people, string typeBooking)
        {

        }
    }

    public class CleaningService
    {
        public void CleanRoom(int roomnumber)
        {

        }

        public void NotificationCleaning(int roomnumber, string message)
        {

        }

        public void checkout(int roomnumber)
        {

        }

    }

    public class RestaurantSystem
    {
        public void bookTable(int people, DateTime time)
        {

        }

        public void notificationkitchen(int people, int roomnumber)
        {

        }
    }

    public class Notification
    {
        public void SentNotification(string message)
        {

        }
    }

    public class HotelFacade
    {

    }
}