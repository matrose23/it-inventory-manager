using System;
using ITInventoryManager.Enums;
using ITInventoryManager.Services;

namespace ITInventoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryService inventoryService = new InventoryService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n===== IT Inventory Manager =====");
                Console.WriteLine("1 - Gerät hinzufügen");
                Console.WriteLine("2 - Alle Geräte anzeigen");
                Console.WriteLine("3 - Gerät löschen");
                Console.WriteLine("4 - Status ändern");
                Console.WriteLine("5 - Gerät bearbeiten");
                Console.WriteLine("6 - Geräte nach Status anzeigen");
                Console.WriteLine("7 - Geräte nach Hersteller suchen");
                Console.WriteLine("8 - Geräte nach Standort suchen");
                Console.WriteLine("9 - Gerät nach Seriennummer suchen");
                Console.WriteLine("10 - Allgemeine Suche");
                Console.WriteLine("0 - Beenden");
                Console.Write("Bitte wählen Sie eine Option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string manufacturer = ReadRequiredText("Hersteller");
                        string model = ReadRequiredText("Modell");
                        string serialNumber = ReadRequiredText("Seriennummer");
                        string warrantyUntil = ReadRequiredText("Garantie bis");
                        string location = ReadRequiredText("Standort");

                        Console.Write("Notizen: ");
                        string notes = Console.ReadLine() ?? "";

                        var newDevice = inventoryService.AddDevice(
                            manufacturer,
                            model,
                            serialNumber,
                            warrantyUntil,
                            location,
                            notes);

                        Console.WriteLine($"Gerät wurde hinzugefügt. ID: {newDevice.Id}");
                        break; ;

                    case "2":
                        var allDevices = inventoryService.GetAllDevices();

                        if (allDevices.Count == 0)
                        {
                            Console.WriteLine("Keine Geräte vorhanden.");
                        }
                        else
                        {
                            foreach (var device in allDevices)
                            {
                                Console.WriteLine($"ID: {device.Id}");
                                Console.WriteLine($"Hersteller: {device.Manufacturer}");
                                Console.WriteLine($"Modell: {device.Model}");
                                Console.WriteLine($"Seriennummer: {device.SerialNumber}");
                                Console.WriteLine($"Garantie bis: {device.WarrantyUntil}");
                                Console.WriteLine($"Standort: {device.Location}");
                                Console.WriteLine($"Notizen: {device.Notes}");
                                Console.WriteLine($"Status: {device.Status}");
                                Console.WriteLine("-----------------------------------");
                            }
                        }
                        break;

                    case "3":
                        Console.Write("Bitte geben Sie die ID des Geräts ein: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            bool deleted = inventoryService.DeleteDeviceById(deleteId);
                            Console.WriteLine(deleted
                                ? "Gerät wurde gelöscht."
                                : "Gerät nicht gefunden.");
                        }
                        else
                        {
                            Console.WriteLine("Ungültige ID.");
                        }
                        break;

                    case "4":
                        Console.Write("Bitte geben Sie die ID des Geräts ein: ");
                        if (!int.TryParse(Console.ReadLine(), out int statusId))
                        {
                            Console.WriteLine("Ungültige ID.");
                            break;
                        }

                        Console.WriteLine("Neuen Status wählen:");
                        Console.WriteLine("1 - Available");
                        Console.WriteLine("2 - InUse");
                        Console.WriteLine("3 - InRepair");
                        Console.WriteLine("4 - Retired");

                        if (!int.TryParse(Console.ReadLine(), out int statusChoice) || statusChoice < 1 || statusChoice > 4)
                        {
                            Console.WriteLine("Ungültige Eingabe.");
                            break;
                        }

                        DeviceStatus newStatus = (DeviceStatus)(statusChoice - 1);
                        bool statusChanged = inventoryService.ChangeDeviceStatus(statusId, newStatus);

                        Console.WriteLine(statusChanged
                            ? "Status wurde geändert."
                            : "Gerät nicht gefunden.");
                        break;

                    case "5":
                        Console.Write("Bitte geben Sie die ID des Geräts ein: ");
                        if (!int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.WriteLine("Ungültige ID.");
                            break;
                        }

                        Console.Write("Neuer Standort: ");
                        string newLocation = Console.ReadLine();

                        Console.Write("Neue Notizen: ");
                        string newNotes = Console.ReadLine();

                        bool updated = inventoryService.UpdateDevice(updateId, newLocation, newNotes);

                        Console.WriteLine(updated
                            ? "Gerät wurde aktualisiert."
                            : "Gerät nicht gefunden.");
                        break;

                    case "6":
                        Console.WriteLine("Status wählen:");
                        Console.WriteLine("1 - Available");
                        Console.WriteLine("2 - InUse");
                        Console.WriteLine("3 - InRepair");
                        Console.WriteLine("4 - Retired");

                        if (!int.TryParse(Console.ReadLine(), out int filterStatusChoice) || filterStatusChoice < 1 || filterStatusChoice > 4)
                        {
                            Console.WriteLine("Ungültige Eingabe.");
                            break;
                        }

                        DeviceStatus selectedStatus = (DeviceStatus)(filterStatusChoice - 1);
                        var devicesByStatus = inventoryService.GetDevicesByStatus(selectedStatus);

                        if (devicesByStatus.Count == 0)
                        {
                            Console.WriteLine("Keine Geräte mit diesem Status gefunden.");
                        }
                        else
                        {
                            foreach (var device in devicesByStatus)
                            {
                                Console.WriteLine($"{device.Id} - {device.Manufacturer} {device.Model} - {device.Status}");
                            }
                        }
                        break;

                    case "7":
                        Console.Write("Bitte Hersteller eingeben: ");
                        string searchManufacturer = Console.ReadLine();

                        var devicesByManufacturer = inventoryService.GetDevicesByManufacturer(searchManufacturer);

                        if (devicesByManufacturer.Count == 0)
                        {
                            Console.WriteLine("Keine Geräte gefunden.");
                        }
                        else
                        {
                            foreach (var device in devicesByManufacturer)
                            {
                                Console.WriteLine($"{device.Id} - {device.Manufacturer} {device.Model} - {device.Location}");
                            }
                        }
                        break;

                    case "8":
                        Console.Write("Bitte Standort eingeben: ");
                        string searchLocation = Console.ReadLine();

                        var devicesByLocation = inventoryService.GetDevicesByLocation(searchLocation);

                        if (devicesByLocation.Count == 0)
                        {
                            Console.WriteLine("Keine Geräte gefunden.");
                        }
                        else
                        {
                            foreach (var device in devicesByLocation)
                            {
                                Console.WriteLine($"{device.Id} - {device.Manufacturer} {device.Model} - {device.Location}");
                            }
                        }
                        break;

                    case "9":
                        Console.Write("Bitte Seriennummer eingeben: ");
                        string searchSerialNumber = Console.ReadLine();

                        var deviceBySerial = inventoryService.GetDeviceBySerialNumber(searchSerialNumber);

                        if (deviceBySerial == null)
                        {
                            Console.WriteLine("Kein Gerät gefunden.");
                        }
                        else
                        {
                            Console.WriteLine($"ID: {deviceBySerial.Id}");
                            Console.WriteLine($"Hersteller: {deviceBySerial.Manufacturer}");
                            Console.WriteLine($"Modell: {deviceBySerial.Model}");
                            Console.WriteLine($"Seriennummer: {deviceBySerial.SerialNumber}");
                            Console.WriteLine($"Standort: {deviceBySerial.Location}");
                            Console.WriteLine($"Status: {deviceBySerial.Status}");
                        }
                        break;

                    case "10":
                        Console.Write("Suchbegriff eingeben: ");
                        string keyword = Console.ReadLine();

                        var searchResults = inventoryService.SearchDevices(keyword);

                        if (searchResults.Count == 0)
                        {
                            Console.WriteLine("Keine Geräte gefunden.");
                        }
                        else
                        {
                            foreach (var device in searchResults)
                            {
                                Console.WriteLine($"{device.Id} - {device.Manufacturer} {device.Model} - {device.Location} - {device.Status}");
                            }
                        }
                        break;

                    case "0":
                        running = false;
                        Console.WriteLine("Programm beendet.");
                        break;

                    default:
                        Console.WriteLine("Ungültige Auswahl.");
                        break;
                }
            }
        }
        static string ReadRequiredText(string fieldName)
        {
            while (true)
            {
                Console.Write($"{fieldName}: ");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                    return input.Trim();

                Console.WriteLine("Dieses Feld darf nicht leer sein.");
            }
        }

    }
}