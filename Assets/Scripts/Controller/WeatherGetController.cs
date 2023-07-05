using System;
using Data;
using UnityEngine;
using Web;
using Web.json;

namespace Controller
{
    public class WeatherGetController : MonoBehaviour
    {
        private WeatherData weatherData;

        public WeatherData WeatherData
        {
            get => weatherData;
            set => weatherData = value;
        }

        public event Action<bool> CompleteEvent;
    
        private void OnCompleteLoad(RequestResultData result)
        {
            weatherData = WeatherJson.Parse(result.Text);
            CompleteEvent?.Invoke(true);
        }

        public void Execute()
        {
            var request = new WeatherWebRequest(null, OnCompleteLoad);
            WebRequestLoader.Instance.Execute(request);
        }

    }
}
