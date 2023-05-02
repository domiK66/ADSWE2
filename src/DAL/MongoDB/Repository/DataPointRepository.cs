using System.Data;
using DAL.MongoDB.Repository;
using DAL.MongoDB.UnitOfWork;
using src.DAL.Influx;
using src.DAL.MongoDB.Entities;

namespace src.DAL.MongoDB.Repository
{
    public class DataPointRepository : Repository<DataPoint>, IDataPointRepository
    {
        public DataPointRepository(DBContext context) : base(context)
        {
        }
        public List<DataPoint> GetDataPointsForDevice(DeviceType deviceType)
        {
            throw new NotImplementedException();
        }
    }
}