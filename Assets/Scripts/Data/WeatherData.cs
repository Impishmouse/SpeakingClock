namespace Data
{
    public class WeatherData
    {
        public int WeatherID;
        public int Temp;
        public int Type;
        
        public enum WeatherType
        {
            Undefined,
            Thunderstorm,
            Drizzle,
            Rain,
            Snow,
            Atmosphere,
            Clear,
            Clouds,
        }
      
    }
}