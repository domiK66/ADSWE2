using System.ComponentModel.DataAnnotations;

namespace src.DAL.MongoDB.Entities
{
    public class ModbusDataPoint: DataPoint
    {
        [EnumDataType(typeof(RegisterType))]
        public RegisterType RegisterType { get; set; }

        [EnumDataType(typeof(RegisterType))]
        public ReadingType ReadingType { get; set; }
        public int Register { get; set; }
        public int RegisterCount { get; set; }
        
    }
    public enum RegisterType {
        InputRegister,
        HoldingRegister,
        Coil,
        InputStatus
    }

    public enum ReadingType {
        LowToHigh,
        HighToLow
    }
}