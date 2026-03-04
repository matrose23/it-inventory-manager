using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITInventoryManager.Enums;

namespace ITInventoryManager.Models
{
    public class Device
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DeviceStatus Status { get; set; }

        public int? AssignedUserId { get; set; }
    }
}