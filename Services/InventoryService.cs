using System.Collections.Generic;
using System.Linq;
using ITInventoryManager.Enums;
using ITInventoryManager.Models;

namespace ITInventoryManager.Services
{
    public class InventoryService
    {
        private readonly List<Device> devices = new List<Device>();
        private int nextId = 1;

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

            devices.Add(device);
            return device;
        }

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

            devices.Remove(device);
            return true;
        }
    }
}