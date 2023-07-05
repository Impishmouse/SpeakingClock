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
        
        private static WeatherData.WeatherType GetWeatherByID(int weatherId)
        {
            return weatherId switch
            {
                2 => WeatherData.WeatherType.Thunderstorm,
                3 => WeatherData.WeatherType.Drizzle,
                5 => WeatherData.WeatherType.Rain,
                6 => WeatherData.WeatherType.Snow,
                7 => WeatherData.WeatherType.Atmosphere,
                8 => WeatherData.WeatherType.Clear,
                9 => WeatherData.WeatherType.Clouds,
                _ => WeatherData.WeatherType.Undefined
            };
        }
        
    }
}