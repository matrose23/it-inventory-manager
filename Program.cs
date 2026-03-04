using System;
using ITInventoryManager.Services;

namespace ITInventoryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryService service = new InventoryService();

            bool running = true;

            while (running)
            {
                Console.WriteLine("==== IT Inventory Manager ====");
                Console.WriteLine("1 - Gerät hinzufügen");
                Console.WriteLine("2 - Geräte anzeigen");
                Console.WriteLine("0 - Beenden");
                Console.Write("Auswahl: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Gerät hinzufügen (noch nicht implementiert)");
                        break;

                    case "2":
                        Console.WriteLine("Geräte anzeigen (noch nicht implementiert)");
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Ungültige Auswahl");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}