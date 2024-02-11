using RestaurantReservation;

namespace RestaurantReservation
{
    public class Program
    {
        public static void Main()
        {
            Menu menu = new();
            try
            {
                menu.greeting();
                var name = Console.ReadLine();


                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Invalid name. Please provide a valid name.");
                    return;
                }

                var user = new User(name);
                Console.WriteLine("Do you have a reservation with us?");
                var option = menu.returnMenuOptions();
                if (option == 1)
                {
                    Console.WriteLine("We'll check that for you");
                    System.Threading.Thread.Sleep(300);
                    Console.WriteLine("Loading...");
                    System.Threading.Thread.Sleep(100);

                    bool hasReservation = ReservationService.HasReservation(user);

                    if (hasReservation)
                    {
                        Console.WriteLine("You are all set!");
                    }
                    else
                    {
                        Console.WriteLine("We couldn't find your reservation, but we can get you a table right away.");
                    }
                }
                else
                {
                    Console.WriteLine("Would you like to make a reservation?");
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
        private static List<string> ReservationList = new List<string> { "Alice", "Bob", "Charlie" };

        public static bool HasReservation(User user)
        {
            return ReservationList.Contains(user.Name);
        }

        public static bool AddReservation(User user)
        {
            ReservationList.Add(user.Name);
            return HasReservation(user);
        }
    }
}
