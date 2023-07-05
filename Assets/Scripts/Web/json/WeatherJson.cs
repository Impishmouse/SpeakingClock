using System.Collections.Generic;
using Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;

namespace Web.json
{
    public class WeatherJson
    {
        public static WeatherData Parse(string text)
        {
            var retData = new WeatherData();
            
            var dict = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(text);

            if (!dict.ContainsKey("weather"))
            {
                EditorUtility.DisplayDialog("Error parsing json", "Not found weather instance", "Ok");
            }

            var weather = dict["weather"][0] as JObject;
            if (weather != null)
            {
                var weatherID = int.Parse(weather["id"]!.ToString());
                
                if (weatherID <= 800) 
                    weatherID = weatherID / 100;
                
                if (weatherID > 800) 
                    weatherID = 9;

                retData.WeatherID = weatherID;
                retData.Type = GetWeatherByID(weatherID);
            }


            if (!dict.ContainsKey("main"))
                EditorUtility.DisplayDialog("Error parsing json", "Not found main instance", "Ok");
            
            var mainTemp = dict["main"] as JObject;
            if (mainTemp != null)
            {
                var temp = float.Parse(mainTemp["temp"]!.ToString());
                var intTemp = Mathf.FloorToInt(temp);
                retData.Temp = intTemp;
            }

            return retData;
        }
        
        private static int GetWeatherByID(int weatherId)
        {
            switch (weatherId)
            {
                case 2:
                    return (int)WeatherData.WeatherType.Thunderstorm;
                case 3:
                    return (int)WeatherData.WeatherType.Drizzle;
                case 5:
                    return (int)WeatherData.WeatherType.Rain;
                case 6:
                    return (int)WeatherData.WeatherType.Snow;
                case 7:
                    return (int)WeatherData.WeatherType.Atmosphere;
                case 8:
                    return (int)WeatherData.WeatherType.Clear;
                case 9:
                    return (int)WeatherData.WeatherType.Clouds;
                default:
                    return (int)WeatherData.WeatherType.Undefined;
            }
        }
        
    }
}