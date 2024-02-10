using System;
using System.Collections.Generic;

namespace RestaurantReservation
{
    public class Program
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Welcome to our restaurant! To get started, please state your name below:");
                string name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid name. Please provide a valid name.");
                    return;
                }

                var user = new User(name);

                bool hasReservation = ReservationService.HasReservation(user);

                if (hasReservation)
                {
                    Console.WriteLine("You're all set!");
                }
                else
                {
                    Console.WriteLine("No reservation found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    public class User
    {
        public string Name { get; }
        public DateTime CreatedAt { get; }

        public User(string name)
        {
            Name = name;
            CreatedAt = DateTime.Now;
        }
    }

    public static class ReservationService
    {
        // Simulate reservations data
        private static readonly List<string> ReservationList = new List<string> { "Alice", "Bob", "Charlie" };

        public static bool HasReservation(User user)
        {
            return ReservationList.Contains(user.Name);
        }
    }
}
