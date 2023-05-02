using System.ComponentModel.DataAnnotations;
using DAL.MongoDB.Entities;

namespace src.DAL.MongoDB
{
    public class DataPoint: Entity
    {
        public String Name {get; set;}
        public String Description { get; set; }
        public String DeviceName { get; set; }

        public int Offset {get; set;}

        [EnumDataType(typeof(DataType))]
        public DataType DataType { get; set; }
    }

    public enum DataType {
        Boolean,
        Float,
        Integer
    }
}