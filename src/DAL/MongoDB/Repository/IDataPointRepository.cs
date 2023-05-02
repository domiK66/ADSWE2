using DAL.MongoDB.Repository;
using src.DAL.Influx;
using src.DAL.MongoDB.Entities;

namespace src.DAL.MongoDB.Repository
{
    public interface IDataPointRepository: IRepository<DataPoint>
    {
        List<DataPoint> GetDataPointsForDevice(DeviceType deviceType);

        
    }
}