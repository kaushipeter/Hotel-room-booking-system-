using System;
using System.Collections.Generic;

namespace HotelManagementSystem
{
class Program
{
// Room class
public class Room
{
public int RoomNumber { get; set; }
public string Type { get; set; } // Single, Double, Suite
public bool IsBooked { get; set; }
}
 
 
    // Booking class
    public class Booking
    {
        public int RoomNumber { get; set; }
        public string GuestName { get; set; }
    }

    static List<Room> rooms = new List<Room>();
    static List<Booking> bookings = new List<Booking>();

    static void Main(string[] args)
    {
        // Preload some rooms
        rooms.Add(new Room { RoomNumber = 101, Type = "Single", IsBooked = false });
        rooms.Add(new Room { RoomNumber = 102, Type = "Double", IsBooked = false });
        rooms.Add(new Room { RoomNumber = 103, Type = "Suite", IsBooked = false });

        while (true)
        {
            Console.WriteLine("\n--- Hotel Management System ---");
            Console.WriteLine("1. View Available Rooms");
            Console.WriteLine("2. Book a Room");
            Console.WriteLine("3. Cancel a Booking");
            Console.WriteLine("4. View All Bookings");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewAvailableRooms();
                    break;
                case "2":
                    BookRoom();
                    break;
                case "3":
                    CancelBooking();
                    break;
                case "4":
                    ViewAllBookings();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void ViewAvailableRooms()
    {
        Console.WriteLine("\nAvailable Rooms:");
        foreach (var room in rooms)
        {
            if (!room.IsBooked)
                Console.WriteLine($"Room {room.RoomNumber} - {room.Type}");
        }
    }

    static void BookRoom()
    {
        Console.Write("Enter your name: ");
        string guestName = Console.ReadLine();

        Console.Write("Enter room number to book: ");
        int roomNumber = int.Parse(Console.ReadLine());

        Room room = rooms.Find(r => r.RoomNumber == roomNumber);

        if (room != null && !room.IsBooked)
        {
            room.IsBooked = true;
            bookings.Add(new Booking { RoomNumber = roomNumber, GuestName = guestName });
            Console.WriteLine($"Room {roomNumber} booked successfully for {guestName}!");
        }
        else
        {
            Console.WriteLine("Room is either not available or already booked.");
        }
    }

    static void CancelBooking()
    {
        Console.Write("Enter room number to cancel: ");
        int roomNumber = int.Parse(Console.ReadLine());

        Booking booking = bookings.Find(b => b.RoomNumber == roomNumber);

        if (booking != null)
        {
            bookings.Remove(booking);
            Room room = rooms.Find(r => r.RoomNumber == roomNumber);
            room.IsBooked = false;
            Console.WriteLine($"Booking for Room {roomNumber} has been canceled.");
        }
        else
        {
            Console.WriteLine("No booking found for this room.");
        }
    }

    static void ViewAllBookings()
    {
        Console.WriteLine("\nAll Bookings:");
        foreach (var booking in bookings)
        {
            Console.WriteLine($"Room {booking.RoomNumber} booked by {booking.GuestName}");
        }
    }
}
 

}
