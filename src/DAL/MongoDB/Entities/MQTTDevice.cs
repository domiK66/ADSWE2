namespace src.DAL.MongoDB.Entities
{
    public class MQTTDevice: Device
    {
        public String Host { get; set; }
        public int Port { get; set; }
        public int SlaveID { get; set; }
    }
    
}