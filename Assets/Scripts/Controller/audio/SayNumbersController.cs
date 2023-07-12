using System;
using System.Collections.Generic;
using Data;
using ScriptableObjects;
using UnityEngine;

namespace Controller.audio
{
    public class SayNumbersController : MonoBehaviour
    {
        private Dictionary<int, AudioClip> numbersToAudioClip;
        
        private void Awake()
        {
            var weatherAudioData = AudioConfig.Instance.GetAudioByType(AudioData.AudioType.Numbers);

            numbersToAudioClip = new Dictionary<int, AudioClip>();
            numbersToAudioClip.Add(1, weatherAudioData.audioClips[0]);
            
        }

        public void SayWeather(WeatherData weatherGetterWeatherData)
        {
            Debug.Log($"Current temperature:{weatherGetterWeatherData.Temp}");

            //App.AudioController.PlaySound(weatherToAudioClip[weatherGetterWeatherData.Type]);
        }
    }
}