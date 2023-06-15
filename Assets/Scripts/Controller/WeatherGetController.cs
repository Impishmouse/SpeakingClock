using System.Collections;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class WeatherGetController : MonoBehaviour
{
    private const string targetURL = "https://api.openweathermap.org/data/2.5/weather?id=702550&units=metric&lang=ua&appid=789ce2a5ee25556243a78f50f5aa1547"; // Замініть це на ваше посилання
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // Відкриття посилання
        Application.OpenURL(targetURL);

        // Очікування деякого часу для завантаження сторінки
        yield return new WaitForSeconds(5f); // Змініть цей час за потребою

        // Отримання відповіді зі сторінки
        UnityWebRequest request = UnityWebRequest.Get(targetURL);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string responseText = request.downloadHandler.text;
            
            /*// Конвертація відповіді в JSON
            JSONObject json = new JSONObject(responseText);

            // Доступ до даних в форматі JSON
            Debug.Log("Response JSON: " + json.ToString());*/
        }
        else
        {
            Debug.LogError("Request failed with error: " + request.error);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
