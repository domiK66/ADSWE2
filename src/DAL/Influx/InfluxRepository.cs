using System.Collections.Concurrent;
using src.DAL.Influx.Samples;
using src.DAL.InfluxDB;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Writes;
using Serilog;
using src.DAL.MongoDB;
using Utils;

namespace src.DAL.Influx
{
    public class InfluxRepository: IInfluxRepository
    {
        protected ILogger log = Logger.ContextLog<InfluxRepository>();
        protected InfluxDBContext InfluxDBContext = null;
        String organisation;
        TimeSpan utcOffset;

        public InfluxRepository(InfluxDBContext Context) {
            this.InfluxDBContext = Context;
            organisation = InfluxDBContext.Organisation;
            utcOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.UtcNow);
        }

        public Task CreateBucket(string bucket)
        {
            throw new NotImplementedException();
        }

        public Task<List<Sample>> GetInRange(
            string bucket,
            DataPoint dp,
            DateTime from,
            DateTime to
        )
        {
            throw new NotImplementedException();
        }

        public Task<Sample> GetLast(string bucket, DataPoint dp)
        {
            throw new NotImplementedException();
        }

        public Task InsertManyAsync(string bucket, ConcurrentBag<Sample> measurement)
        {
            throw new NotImplementedException();
        }

        public async Task InsertOneAsync(String bucket, Sample measurement)
        {
            var point = GeneratePoint(measurement);

            await InfluxDBContext.WriteAPI.WritePointAsync(
                point,
                bucket,
                InfluxDBContext.Organisation
            );
        }

        private PointData GeneratePoint(Sample measurement)
        {
            if (measurement.GetType() == typeof(BinarySample))
            {
                var point = PointData
                    .Measurement(measurement.Tag)
                    .Tag("measurement", measurement.Tag)
                    .Field("value", measurement.AsBoolean())
                    .Timestamp(measurement.Timestamp.ToUniversalTime(), WritePrecision.S);
                return point;
            }
            else
            {
                var point = PointData
                    .Measurement(measurement.Tag)
                    .Tag("measurement", measurement.Tag)
                    .Field("value", measurement.AsNumeric())
                    .Timestamp(measurement.Timestamp.ToUniversalTime(), WritePrecision.S);
                return point;
            }
        }

        private List<Sample> GetSamples(DataPoint dp, List<FluxTable> tables)
        {
            List<Sample> returnval = new List<Sample>();
            if (dp.DataType == DataType.Boolean)
            {
                foreach (var record in tables.SelectMany(table => table.Records))
                {
                    BinarySample smp = new BinarySample();
                    smp.Timestamp = record
                        .GetTime()
                        .Value.ToDateTimeUtc()
                        .ToLocalTime()
                        .AddHours(utcOffset.Hours);
                    smp.Value = Boolean.Parse(record.GetValue().ToString());
                    smp.Tag = record.GetMeasurement();

                    returnval.Add(smp);
                }
            }
            else
            {
                foreach (var record in tables.SelectMany(table => table.Records))
                {
                    NumericSample smp = new NumericSample();
                    smp.Timestamp = record
                        .GetTime()
                        .Value.ToDateTimeUtc()
                        .ToLocalTime()
                        .AddHours(utcOffset.Hours);
                    smp.Value = float.Parse(record.GetValue().ToString());
                    smp.Tag = record.GetMeasurement();

                    returnval.Add(smp);
                }
            }
            return returnval;
        }
    }
}
