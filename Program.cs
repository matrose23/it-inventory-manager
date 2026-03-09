using System;
using ITInventoryManager.Enums;
using ITInventoryManager.Models;
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
                Console.WriteLine("3 - Gerät löschen");
                Console.WriteLine("4 - Status ändern");
                Console.WriteLine("0 - Beenden");
                Console.Write("Auswahl: ");

                string choice = Console.ReadLine() ?? "";
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Hersteller (z.B. Dell/HP/Lenovo): ");
                        string manufacturer = Console.ReadLine() ?? "";

                        if (string.IsNullOrWhiteSpace(manufacturer))
                        {
                            Console.WriteLine("Hersteller darf nicht leer sein.");
                            continue;
                        }
                        Console.Write("Modell (z.B. Latitude 5490): ");
                        string model = Console.ReadLine() ?? "";

                        Console.Write("Seriennummer: ");
                        string serial = Console.ReadLine() ?? "";

                        if (string.IsNullOrWhiteSpace(manufacturer) ||
                            string.IsNullOrWhiteSpace(model) ||
                            string.IsNullOrWhiteSpace(serial))
                        {
                            Console.WriteLine("Fehler: Hersteller, Modell und Seriennummer dürfen nicht leer sein.");
                            continue;
                        }

                        Console.Write("Garantie bis (z.B. 12/2027 oder unbekannt): ");
                        string warrantyUntil = Console.ReadLine() ?? "";

                        Console.Write("Standort/Raum (z.B. Büro 2 / Raum 101): ");
                        string location = Console.ReadLine() ?? "";

                        Console.Write("Bemerkung (optional): ");
                        string notes = Console.ReadLine() ?? "";

                        var added = service.AddDevice(
                            manufacturer.Trim(),
                            model.Trim(),
                            serial.Trim(),
                            warrantyUntil.Trim(),
                            location.Trim(),
                            notes.Trim()
                        );

                        Console.WriteLine($"OK: Gerät hinzugefügt. Id={added.Id}, Hersteller={added.Manufacturer}, Modell={added.Model}, SN={added.SerialNumber}, Status={added.Status}");
                        break;

                    case "2":
                        var devices = service.GetAllDevices();

                        if (devices.Count == 0)
                        {
                            Console.WriteLine("Keine Geräte vorhanden.");
                            break;
                        }

                        Console.WriteLine("---- Geräte-Liste ----");
                        Console.WriteLine("ID  Hersteller    Modell         SN             Garantie     Standort     Status     Bemerkung");
                        Console.WriteLine("------------------------------------------------------------------------------------------------");

                        foreach (Device d in devices)
                        {
                            Console.WriteLine(
                                $"{d.Id,-3} " +
                                $"{Fit(d.Manufacturer, 12)} " +
                                $"{Fit(d.Model, 13)} " +
                                $"{Fit(d.SerialNumber, 14)} " +
                                $"{Fit(d.WarrantyUntil, 10)} " +
                                $"{Fit(d.Location, 11)} " +
                                $"{Fit(d.Status.ToString(), 9)} " +
                                $"{Fit(d.Notes, 25)}"
                            );
                        }

                        break;

                    case "3":
                        Console.Write("Id zum Löschen: ");
                        string input = Console.ReadLine() ?? "";

                        if (!int.TryParse(input, out int id))
                        {
                            Console.WriteLine("Fehler: Bitte eine gültige Zahl eingeben.");
                            break;
                        }

                        bool deleted = service.DeleteDeviceById(id);

                        if (deleted)
                            Console.WriteLine("OK: Gerät wurde gelöscht.");
                        else
                            Console.WriteLine("Nicht gefunden: Kein Gerät mit dieser Id.");

                        break;

                    case "4":
                        Console.Write("Geräte ID: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Neuer Status:");
                        Console.WriteLine("0 - Available");
                        Console.WriteLine("1 - Assigned");
                        Console.WriteLine("2 - InRepair");
                        Console.WriteLine("3 - Retired");

                        int statusInput = int.Parse(Console.ReadLine());
                        DeviceStatus newStatus = (DeviceStatus)statusInput;

                        service.ChangeDeviceStatus(id, newStatus);
                        break;

                    case "5":
                        Console.Write("Geräte ID: ");
                        int editId = int.Parse(Console.ReadLine());

                        Console.Write("Neuer Standort: ");
                        string location = Console.ReadLine();

                        Console.Write("Neue Bemerkung: ");
                        string notes = Console.ReadLine();

                        service.UpdateDevice(editId, location, notes);
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

        // Passt Texte an eine feste Spaltenbreite für die Tabellenausgabe an
        static string Fit(string value, int width)
        {
            value = (value ?? "").Trim();

            if (value.Length > width)
                return value.Substring(0, width - 1) + "…";

            return value.PadRight(width);
        }
    }
}