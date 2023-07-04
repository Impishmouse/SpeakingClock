using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class WeatherGetController : MonoBehaviour
{
    private const string targetURL = "https://api.openweathermap.org/data/2.5/weather?id=702550&units=metric&lang=ua&appid=789ce2a5ee25556243a78f50f5aa1547"; // Замініть це на ваше посилання
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Debug.Log("Test call URL");
        
        // Отримання відповіді зі сторінки
        UnityWebRequest request = UnityWebRequest.Get(targetURL);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            
            // TODO move this code to JSON  weather parser
            
            var dict = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(responseText);

            if (!dict.ContainsKey("weather"))
            {
                EditorUtility.DisplayDialog("Error parsing json", "Not found weather instance", "Ok");
                yield break;
            }

            var weather = dict["weather"][0] as JObject;
            if (weather != null)
            {
                var weatherID = int.Parse(weather["id"]!.ToString());
                
                if (weatherID <= 800) 
                    weatherID = weatherID / 100;
                
                if (weatherID > 800) 
                    weatherID = 9;
                Debug.Log("Weather id:" + weatherID);

                Debug.Log("Weather: " + GetWeatherByID(weatherID));

            }


            if (!dict.ContainsKey("main"))
            {
                EditorUtility.DisplayDialog("Error parsing json", "Not found main instance", "Ok");
                yield break;
            }
            
            var mainTemp = dict["main"] as JObject;
            if (mainTemp != null)
            {
                var temp = float.Parse(mainTemp["temp"]!.ToString());
                var intTemp = Mathf.FloorToInt(temp);
            
                Debug.Log("Main temp:" + intTemp);
            }
        }
        else
        {
            Debug.LogError("Request failed with error: " + request.error);
        }
    }

    private string GetWeatherByID(int weatherId)
    {
        switch (weatherId)
        {
            case 2:
                return "thunderstorm";
            case 3:
                return "drizzle";
            case 5:
                return "rain";
            case 6:
                return "snow";
            case 7:
                return "atmosphere";
            case 8:
                return "clear";
            case 9:
                return "clouds";
            default:
                return "_undefined_";
        }
    }
}
