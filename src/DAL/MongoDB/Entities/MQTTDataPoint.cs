namespace src.DAL.MongoDB.Entities
{
    public class MQTTDataPoint: DataPoint
    {
        public string Topic { get; set; }
        public int QualityOfService { get; set; }

    }
}