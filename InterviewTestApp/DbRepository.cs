using Microsoft.EntityFrameworkCore;

namespace InterviewTestApp
{
    public class DbRepository : DbRepositoryInterface
    {
        private readonly MyDbContext _dbContext;

        public DbRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<WeatherForecast> GetAllForecasts()
        {
            var items = _dbContext.WeatherForecasts.Include(x => x.WeatherType).ToList();
            var output = new List<WeatherForecast>();
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                output.Add(new WeatherForecast 
                { 
                    Date = item.Date.ToString(),
                    Summary = item.Description.ToString(),
                    TemperatureC = (int)item.TemperatureCelseus,
                    TemperatureF = 32 + (int)(item.TemperatureCelseus / 0.5556),
                    WeatherType = (Typeofweatherenum)item.WeatherType.Id
                });
            }
            return output;
        }

        public async Task<WeatherForecast> GetForecast(string id)
        {
            var items = await _dbContext.WeatherForecasts.Include(x => x.WeatherType).ToListAsync();
            var output = new List<WeatherForecast>();
            WeatherForecast singleOutput = new WeatherForecast();
            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];
                output.Add(new WeatherForecast
                {
                    Date = item.Date.ToString(),
                    Summary = item.Description.ToString(),
                    TemperatureC = (int)item.TemperatureCelseus,
                    TemperatureF = 32 + (int)(item.TemperatureCelseus / 0.5556),
                    WeatherType = (Typeofweatherenum)item.WeatherType.Id
                });
                if (item.Id == Guid.Parse(id))
                {
                    singleOutput = new WeatherForecast
                    {
                        Date = item.Date.ToString(),
                        Summary = item.Description.ToString(),
                        TemperatureC = (int)item.TemperatureCelseus,
                        TemperatureF = 32 + (int)(item.TemperatureCelseus / 0.5556),
                        WeatherType = (Typeofweatherenum)item.WeatherType.Id
                    };
                }
            }
            return singleOutput;
        }
    }
}
