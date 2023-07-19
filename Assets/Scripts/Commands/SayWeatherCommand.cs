using System.Threading.Tasks;
using Data;

namespace Commands
{
    public class SayWeatherCommand : ICommand
    {
        private WeatherData weatherData;
        private bool isSaid;

        public SayWeatherCommand(WeatherData weatherGetterWeatherData)
        {
            weatherData = weatherGetterWeatherData;
        }

        public async Task Execute()
        {
            isSaid = false;
            App.SayNumbersController.CompleteEvent += OnCompleteSaid;
            App.SayNumbersController.WeatherData = weatherData;
            App.SayNumbersController.SayTemperatureNumber();

            while (!isSaid)
            {
                await Task.Yield();
            }

            await Task.Delay(500);
            isSaid = false;
            App.SayNumbersController.SayFelling();
            
            while (!isSaid)
            {
                await Task.Yield();
            }
            

            await Task.Delay(500);
            App.SayWeatherController.SayWeather(weatherData);
        }

        private void OnCompleteSaid(bool value)
        {
            isSaid = value;
        }
    }
}