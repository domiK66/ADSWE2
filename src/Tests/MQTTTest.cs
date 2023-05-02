using Services.Drivers;
using src.DAL.MongoDB.Entities;

namespace src.Tests
{
    public class MQTTTest
    {
        [Test]
        public async Task ReadMQTT()
        {
            MQTTDevice mqttDevice = new MQTTDevice();
            mqttDevice.Host = "127.0.0.1";
            mqttDevice.Port = 1883;
            mqttDevice.Name = "Test";
            mqttDevice.DeviceType = DAL.MongoDB.Entities.DeviceType.Water;
            mqttDevice.Active = true;

            List<MQTTDataPoint> dataPoints = new List<MQTTDataPoint>();
            MQTTDataPoint current = new MQTTDataPoint();
            current.DataType = DAL.MongoDB.DataType.Float;
            current.Topic = "WaterTemp";
            current.Name = "WaterTemp";

            dataPoints.Add(current);

            MQTTDriver driver = new MQTTDriver(mqttDevice, dataPoints);
            await driver.Connect();
            await Task.Delay(100);
            Assert.IsTrue(driver.IsConnected);
            await Task.Delay(4000);
            Assert.Greater(driver.Measurements.Count, 0);
            await driver.Disconnect();
        }
    }
}
