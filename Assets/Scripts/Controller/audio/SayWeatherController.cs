using System;
using System.Collections.Generic;
using Data;
using ScriptableObjects;
using UnityEngine;

namespace Controller.audio
{
    public class SayWeatherController :MonoBehaviour
    {
        private Dictionary<WeatherData.WeatherType, AudioClip> weatherToAudioClip;
        
        private void Awake()
        {
            var weatherAudioData = AudioConfig.Instance.GetAudioByType(AudioData.AudioType.Weather);

            weatherToAudioClip = new Dictionary<WeatherData.WeatherType, AudioClip>();
            weatherToAudioClip.Add(WeatherData.WeatherType.Thunderstorm, weatherAudioData.audioClips[0]);
            weatherToAudioClip.Add(WeatherData.WeatherType.Drizzle, weatherAudioData.audioClips[1]);
            weatherToAudioClip.Add(WeatherData.WeatherType.Rain, weatherAudioData.audioClips[2]);
            weatherToAudioClip.Add(WeatherData.WeatherType.Snow, weatherAudioData.audioClips[3]);
            weatherToAudioClip.Add(WeatherData.WeatherType.Atmosphere, weatherAudioData.audioClips[4]);
            weatherToAudioClip.Add(WeatherData.WeatherType.Clear, weatherAudioData.audioClips[5]);
            weatherToAudioClip.Add(WeatherData.WeatherType.Clouds, weatherAudioData.audioClips[6]);
        }

        public void SayWeather(WeatherData weatherGetterWeatherData)
        {
            App.AudioController.PlaySound(weatherToAudioClip[weatherGetterWeatherData.Type]);
        }
    }
}