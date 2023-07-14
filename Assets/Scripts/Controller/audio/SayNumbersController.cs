using System;
using System.Collections.Generic;
using Data;
using DG.Tweening;
using ScriptableObjects;
using UnityEngine;

namespace Controller.audio
{
    public class SayNumbersController : MonoBehaviour
    {
        private Dictionary<int, AudioClip> numbersToAudioClip;
        
        private void Awake()
        {
            var numAudioData = AudioConfig.Instance.GetAudioByType(AudioData.AudioType.Numbers);

            numbersToAudioClip = new Dictionary<int, AudioClip>();
            numbersToAudioClip.Add(1, numAudioData.audioClips[0]);
            numbersToAudioClip.Add(2, numAudioData.audioClips[1]);
            numbersToAudioClip.Add(3, numAudioData.audioClips[2]);
            numbersToAudioClip.Add(4, numAudioData.audioClips[3]);
            numbersToAudioClip.Add(5, numAudioData.audioClips[4]);
            numbersToAudioClip.Add(6, numAudioData.audioClips[5]);
            numbersToAudioClip.Add(7, numAudioData.audioClips[6]);
            numbersToAudioClip.Add(8, numAudioData.audioClips[7]);
            numbersToAudioClip.Add(9, numAudioData.audioClips[8]);
            numbersToAudioClip.Add(10, numAudioData.audioClips[9]);
            numbersToAudioClip.Add(11, numAudioData.audioClips[10]);
            numbersToAudioClip.Add(12, numAudioData.audioClips[11]);
            numbersToAudioClip.Add(13, numAudioData.audioClips[12]);
            numbersToAudioClip.Add(14, numAudioData.audioClips[13]);
            numbersToAudioClip.Add(15, numAudioData.audioClips[14]);
            numbersToAudioClip.Add(16, numAudioData.audioClips[15]);
            numbersToAudioClip.Add(17, numAudioData.audioClips[16]);
            numbersToAudioClip.Add(18, numAudioData.audioClips[17]);
            numbersToAudioClip.Add(19, numAudioData.audioClips[18]);
            numbersToAudioClip.Add(20, numAudioData.audioClips[19]);
            numbersToAudioClip.Add(30, numAudioData.audioClips[20]);
            numbersToAudioClip.Add(40, numAudioData.audioClips[21]);
            numbersToAudioClip.Add(50, numAudioData.audioClips[22]);
            numbersToAudioClip.Add(60, numAudioData.audioClips[23]);
            numbersToAudioClip.Add(70, numAudioData.audioClips[24]);
            numbersToAudioClip.Add(80, numAudioData.audioClips[25]);
            numbersToAudioClip.Add(90, numAudioData.audioClips[26]);
            numbersToAudioClip.Add(100, numAudioData.audioClips[27]);
            
        }

        public void SayWeather(WeatherData weatherGetterWeatherData)
        {
            Debug.Log($"Current temperature:{weatherGetterWeatherData.Temp}");

            SayNumber(weatherGetterWeatherData.Temp);
        }

        private void SayNumber(int number, TweenCallback nextAction = null)
        {
            if (number <= 20)
            {
                App.AudioController.PlaySound(numbersToAudioClip[number], nextAction);
            }
            else if (number < 100)
            {
                var tens = ((number / 10) % 10) * 10;
                var first = number % 10;
                Debug.Log($"Tens:{tens}; first:{first}; in Number:{number}");
                App.AudioController.PlaySound(numbersToAudioClip[tens], () => { SayNumber(first); });
            }
        }
        
        public enum NumberType
        {
            Zero, 
            One,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Eleven,
            Twelve,
            Thirteen,
            Fourteen,
            Fifteen,
            Sixteen,
            Seventeen,
            Eighteen,
            Nineteen,
            Twenty,
            Thirty,
            Forty,
            Fifty,
            Sixty,
            Seventy,
            Eighty,
            Ninety,
            Hundred,
            Degree1,
            Degree2,
            Degree5,
            Hot,
            Cold,
            Percent,
            Percent2,
            Percent5
        }
    }
}