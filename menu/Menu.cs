using System.Text;

namespace RestaurantReservation
{
  internal class Menu
  {
    internal int returnMenu()
    {
      Console.Clear();
      Console.OutputEncoding = Encoding.UTF8;
      Console.CursorVisible = false;
      Console.ForegroundColor = ConsoleColor.Cyan;


      Console.WriteLine("Welcome to the restaurant WithoutAName");
      Console.WriteLine("Do you have a reservation with us?");
      Console.ResetColor();
      Console.WriteLine("\n Use arrow Up/Down to navigate and press \u001b[32mEnter/Return\u001b[0m to select:");

      (int left, int top) = Console.GetCursorPosition();
      var option = 1;
      var decorator = "\u001b[32m";
      ConsoleKeyInfo key;
      bool isSelected = false;

      while (!isSelected)
      {
        Console.SetCursorPosition(left, top);

        Console.WriteLine($"{(option == 1 ? decorator : "   ")}Yes\u001b[0m");
        Console.WriteLine($"{(option == 2 ? decorator : "   ")}No\u001b[0m");

        key = Console.ReadKey(false);

        switch (key.Key)
        {
          case ConsoleKey.UpArrow:
            option = option == 1 ? 2 : option - 1;
            break;
          case ConsoleKey.DownArrow:
            option = option == 2 ? 1 : option + 1;
            break;
          case ConsoleKey.Enter:
            isSelected = true;
            break;
        }
      }
      return option;
    }
  }
}
