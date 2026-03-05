using ITInventoryManager.Enums;

namespace ITInventoryManager.Models
{
    public class Device
    {
        public int Id { get; set; }

        // Zusätzliche Geräteinformationen für das Inventarsystem
        public string Manufacturer { get; set; } = "";   // Hersteller des Geräts
        public string Model { get; set; } = "";          // Modell des Geräts
        public string SerialNumber { get; set; } = "";   // Seriennummer des Geräts

        public string WarrantyUntil { get; set; } = "";  // Garantie bis (als Text gespeichert)
        public string Location { get; set; } = "";       // Standort oder Raum des Geräts
        public string Notes { get; set; } = "";          // Zusätzliche Bemerkungen

        public DeviceStatus Status { get; set; }
        public int? AssignedUserId { get; set; }
    }
}