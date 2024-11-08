using MyNamespace;

internal class HotelFacade
{
    public void BookRoom(DateTime startDay, DateTime endDay, int people, string typeofBook)
    {
        RoomBookingSystem roomBookingSystem = new RoomBookingSystem();
        roomBookingSystem.Booking(startDay, endDay, people, typeofBook);

        CleaningService cleaningService = new CleaningService();
        cleaningService.NotificationCleaning(people, typeofBook);

        RestaurantSystem restaurantSystem = new RestaurantSystem();
        restaurantSystem.notificationkitchen(people, 201);

        Notification notification = new Notification();
        Notification.SentNotification("");

    }

}