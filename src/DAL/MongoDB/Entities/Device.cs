using System.ComponentModel.DataAnnotations;
using DAL.MongoDB.Entities;

namespace src.DAL.MongoDB.Entities
{
    public class Device: Entity
    {
        public String Name { get; set; }
        public String Description { get; set; }

        public Boolean Active { get; set; }

        public String Aquarium { get; set; }

        public String Humidity { get; set; }
        
        [EnumDataType(typeof(DeviceType))]
        public DeviceType DeviceType { get; set; }

    }

    public enum DeviceType {
        Pump,
        Water
    }
}