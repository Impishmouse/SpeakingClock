using System;
using System.Collections.Generic;

namespace Web
{
    public class WeatherWebRequest : WebRequestBase
    {
        public WeatherWebRequest(Dictionary<string, string> parameters,  Action<RequestResultData> callback)
        {
            Method = "https://api.openweathermap.org/data/2.5/weather?id=702550&units=metric&lang=ua&appid=789ce2a5ee25556243a78f50f5aa1547";
            Parameters = parameters;
            Callback = callback;
        }
    }
}