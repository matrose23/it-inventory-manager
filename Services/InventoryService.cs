using ITInventoryManager.Models;

namespace ITInventoryManager.Services
{
    public class InventoryService
    {
        private List<Device> devices = new List<Device>();

        public void AddDevice(Device device)
        {
            devices.Add(device);
        }

        public List<Device> GetAllDevices()
        {
            return devices;
        }
    }
}