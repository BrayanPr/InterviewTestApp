using InterviewTestApp.Entities;
using InterviewTestApp.Infrestructure.Database;
using InterviewTestApp.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InterviewTestApp.Infrestructure.Repositories
{
    public class WeatherForecastRepository : IWeatherForecast
    {
        private readonly MyDbContext _dbContext;

        public WeatherForecastRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public List<WeatherForecast> GetAllForecasts()
        {
            var items = _dbContext.WeatherForecasts.Include(x => x.WeatherType).ToList();
            var output = new List<WeatherForecast>();

            items.ForEach(i =>
            {
                output.Add(new WeatherForecast
                {
                    Date = i.Date.ToString(),
                    Summary = i.Description.ToString(),
                    TemperatureC = (int)i.TemperatureCelseus,
                    TemperatureF = 32 + (int)(i.TemperatureCelseus / 0.5556),
                    WeatherType = (Typeofweatherenum)i.WeatherTypeId
                });
            });

            return output;
        }

        public async Task<WeatherForecast> GetForecast(int id)
        {
            var item = await _dbContext.WeatherForecasts.FindAsync(id);
            WeatherForecast singleOutput = singleOutput = new WeatherForecast
            {
                Date = item.Date.ToString(),
                Summary = item.Description.ToString(),
                TemperatureC = (int)item.TemperatureCelseus,
                TemperatureF = 32 + (int)(item.TemperatureCelseus / 0.5556),
                WeatherType = (Typeofweatherenum)item.WeatherTypeId
            };

            //for (int i = 0; i < items.Count; i++)
            //{
            //    var item = items[i];
            //    output.Add(new WeatherForecast
            //    {
            //        Date = item.Date.ToString(),
            //        Summary = item.Description.ToString(),
            //        TemperatureC = (int)item.TemperatureCelseus,
            //        TemperatureF = 32 + (int)(item.TemperatureCelseus / 0.5556),
            //        WeatherType = (Typeofweatherenum)item.WeatherType.Id
            //    });
            //    if (item.Id == id)
            //    {

            //    }
            //}
            return singleOutput;
        }


    }
}
