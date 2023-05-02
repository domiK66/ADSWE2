using DAL.Influx;
using src.DAL.Influx.Samples;

namespace src.Tests
{
    public class InfluxDBTests
    {
        InfluxUnitOfWork uow = null;

        public InfluxDBTests()
        {
            uow = new InfluxUnitOfWork();
        }

        [Test]
        public async Task CreateFirstEntry()
        {
            NumericSample sample = new NumericSample();
            sample.Tag = "Test";
            sample.Value = 1111;
            sample.Timestamp = DateTime.Now;
            await uow.Influx.InsertOneAsync("Test", sample);
        }
    }
}
