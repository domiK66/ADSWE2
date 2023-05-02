using System.Collections.Concurrent;
using src.DAL.Influx.Samples;
using src.DAL.MongoDB;

namespace src.DAL.InfluxDB;
public interface IInfluxRepository
    {
        Task InsertOneAsync(String bucket, Sample measurement);
        Task InsertManyAsync(String bucket, ConcurrentBag<Sample> measurement);
        Task<List<Sample>> GetInRange(String bucket, DataPoint dp, DateTime from, DateTime to);
        Task<Sample> GetLast(String bucket, DataPoint dp);
        Task CreateBucket(String bucket);
    }
