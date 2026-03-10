using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using ITInventoryManager.Enums;
using ITInventoryManager.Models;

namespace ITInventoryManager.Services
{
    public class InventoryService
    {
        private readonly List<Device> devices = new List<Device>();
        private int nextId = 1;
        private readonly string filePath = "devices.json";

        public InventoryService()
        {
            LoadFromFile();
        }

        private void SaveToFile()
        {
            var json = JsonSerializer.Serialize(devices, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }

        private void LoadFromFile()
        {
            if (!File.Exists(filePath))
                return;

            string json = File.ReadAllText(filePath);

            var loadedDevices = JsonSerializer.Deserialize<List<Device>>(json);

            if (loadedDevices != null)
            {
                devices.Clear();
                devices.AddRange(loadedDevices);

                if (devices.Count > 0)
                {
                    nextId = devices.Max(d => d.Id) + 1;
                }
            }
        }

        // Fügt ein neues Gerät mit Seriennummer hinzu
        public Device AddDevice(
            string manufacturer,
            string model,
            string serialNumber,
            string warrantyUntil,
            string location,
            string notes)
        {
            var device = new Device
            {
                Id = nextId++,
                Manufacturer = manufacturer,
                Model = model,
                SerialNumber = serialNumber,
                WarrantyUntil = warrantyUntil,
                Location = location,
                Notes = notes,
                Status = DeviceStatus.Available,
                AssignedUserId = null
            };

            devices.Add(device);   // Gerät wird zur Liste hinzugefügt
            SaveToFile();          // Daten werden in der JSON-Datei gespeichert

            return device;
        }

        // Gibt alle Geräte zurück
        public List<Device> GetAllDevices()
        {
            return devices;
        }

        // Löscht ein Gerät aus der Inventarliste anhand der Id
        public bool DeleteDeviceById(int id)
        {
            var device = devices.FirstOrDefault(d => d.Id == id);
            if (device == null)
                return false;

            devices.Remove(device);   // Gerät wird aus der Inventarliste entfernt
            SaveToFile();             // Änderungen werden in der JSON-Datei gespeichert

            return true;
        }

        // Ändert den Status eines Geräts
        public bool ChangeDeviceStatus(int id, DeviceStatus newStatus)
        {
            var device = devices.FirstOrDefault(d => d.Id == id);

            if (device == null)
                return false;

            device.Status = newStatus;   // Status des Geräts wird aktualisiert
            SaveToFile();                // Aktualisierte Daten werden gespeichert

            return true;
        }

        // Aktualisiert Standort und Notizen eines Geräts
        public bool UpdateDevice(int id, string location, string notes)
        {
            var device = devices.FirstOrDefault(d => d.Id == id);

            if (device == null)
                return false;

            device.Location = location;   // Standort wird aktualisiert
            device.Notes = notes;         // Notizen werden aktualisiert

            SaveToFile();                 // Änderungen werden in der JSON-Datei gespeichert

            return true;
        }

        // Gibt alle Geräte mit einem bestimmten Status zurück
        public List<Device> GetDevicesByStatus(DeviceStatus status)
        {
            return devices.Where(d => d.Status == status).ToList();
        }

        // Sucht Geräte nach Hersteller
        public List<Device> GetDevicesByManufacturer(string manufacturer)
        {
            return devices
                .Where(d => d.Manufacturer.Contains(manufacturer, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Sucht Geräte nach Standort
        public List<Device> GetDevicesByLocation(string location)
        {
            return devices
                .Where(d => d.Location.Contains(location, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Sucht ein Gerät anhand der Seriennummer
        public Device? GetDeviceBySerialNumber(string serialNumber)
        {
            return devices.FirstOrDefault(d =>
                d.SerialNumber.Equals(serialNumber, StringComparison.OrdinalIgnoreCase));
        }

        // Allgemeine Suche nach Hersteller, Modell oder Standort
        public List<Device> SearchDevices(string keyword)
        {
            return devices
                .Where(d =>
                    d.Manufacturer.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    d.Model.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    d.Location.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}