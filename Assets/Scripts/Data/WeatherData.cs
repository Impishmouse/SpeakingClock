namespace Data
{
    public class WeatherData
    {
        public int WeatherID;
        public int Temp;
        public WeatherType Type;
        
        public enum WeatherType
        {
            Thunderstorm,
            Drizzle,
            Rain,
            Snow,
            Atmosphere,
            Clear,
            Clouds,
            Undefined,
        }
      
    }
}