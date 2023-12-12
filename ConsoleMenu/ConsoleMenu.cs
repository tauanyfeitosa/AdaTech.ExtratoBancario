
namespace ConsoleMenuLibrary
{
    public class ConsoleMenu
    {
        private readonly string[] items;
        private int selectedIndex;

        public ConsoleMenu(string[] menuItems)
        {
            items = menuItems;
            selectedIndex = 0;
        }

        public int ShowMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                DisplayMenu();

                key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = Math.Max(0, selectedIndex - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = Math.Min(items.Length - 1, selectedIndex + 1);
                        break;
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine($"\nOpção selecionada: {items[selectedIndex]}\n\n");
            return selectedIndex;
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Selecione uma opção:");

            for (int i = 0; i < items.Length; i++)
            {
                Console.ForegroundColor = (i == selectedIndex) ? ConsoleColor.Black : ConsoleColor.Gray;
                Console.BackgroundColor = (i == selectedIndex) ? ConsoleColor.Gray : ConsoleColor.Black;

                Console.WriteLine($"{items[i]}");

                Console.ResetColor();
            }
        }
    }
}

