using System.Collections;
using System.Xml;
using Tools;
using UnityEngine;
using UnityEngine.Networking;

namespace Web
{
    public class WebRequestLoader : MonoSingleton<WebRequestLoader>
    {
        public void Execute(WebRequestBase request)
        {
            StartCoroutine(LoadCoroutine(request));
        }
        
        private IEnumerator LoadCoroutine(WebRequestBase request)
        {
            var webRequest = GetWebRequest(request);
			
            var downloadHandler = new DownloadHandlerBuffer();

            webRequest.downloadHandler = downloadHandler;

            yield return webRequest.SendWebRequest();

            var result = new RequestResultData
            {
                Text = downloadHandler.text
            };
			
            // TODO Uncomment if requests logs need later.
            /*Debug.Log($"WeatherLoader => webRequest.url = {webRequest.url}");
            Debug.Log($"WeatherLoader => webRequest.error = {webRequest.error}");
            Debug.Log($"WeatherLoader => webRequest.method = {webRequest.method}");
            Debug.Log($"WeatherLoader => webRequest.isDone = {webRequest.isDone}");
            Debug.Log($"WeatherLoader => webRequest.responseCode = {webRequest.responseCode}");*/

            if (!string.IsNullOrEmpty(webRequest.error))
            {
                result.Error = webRequest.error;
            }

            request.Callback?.Invoke(result);
        }
        
        private UnityWebRequest GetWebRequest(WebRequestBase request)
        {
            UnityWebRequest webRequest;

            if (request.Parameters?.Count > 0)
            {
                webRequest = UnityWebRequest.Post(request.Method, request.Parameters);
            }
            else
            {
                webRequest = UnityWebRequest.Get(request.Method);
            }

            foreach (var pair in request.Headers)
            {
                webRequest.SetRequestHeader(pair.Key, pair.Value);
            }			

            return webRequest;
        }
        
        
    }
}