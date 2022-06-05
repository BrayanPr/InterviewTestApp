namespace InterviewTestApp.Entities
{
    public class WeatherForecast
    {
        public string Date { get; set; }
        public Typeofweatherenum WeatherType { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string? Summary { get; set; }
    }

    public enum Typeofweatherenum
    {
        RAIN = 1,
        SNOW = 2,
        SUN = 3
    }

    public class LstWeatherType
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public virtual ICollection<TableWeatherForecast>? WeatherForecasts { get; set; }
    }

    public class TableWeatherForecast
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int WeatherTypeId { get; set; }
        public virtual LstWeatherType? WeatherType { get; set; } = null;
        public double TemperatureCelseus { get; set; }
        public string? Description { get; set; }
    }
}