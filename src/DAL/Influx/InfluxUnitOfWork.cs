using Context.DataBaseSettings;
using src.DAL.InfluxDB;
using Microsoft.Extensions.Configuration;
using Serilog;
using src.DAL.Influx;
using Utils;

namespace DAL.Influx;
public class InfluxUnitOfWork {
      protected ILogger log = Logger.ContextLog<InfluxUnitOfWork>();

        public InfluxDBContext Context { get; private set; } = null;

        private IInfluxRepository Repository = null;

        public InfluxUnitOfWork()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Constants.CurrentFolder).AddJsonFile("appsettings.json");

            InfluxDBSettings settings = builder.Build().GetSection("InfluxDbSettings").Get<InfluxDBSettings>();
            InfluxDBContext context = new InfluxDBContext(settings);
            Context = context;

            Repository = new InfluxRepository(Context);
        }

        public IInfluxRepository Influx
        {
            get
            {
                return Repository;
            }
        }
}
