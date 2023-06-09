using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class SayTimeController : MonoBehaviour
{
    //private const hoursToAudioClip = [];
    private Dictionary<int, AudioClip> _hoursToAudioClip;
    private bool _sayMinutes;
    private int _remainder;

    private void Awake()
    {
        _hoursToAudioClip = new Dictionary<int, AudioClip>();
        _hoursToAudioClip.Add(1, AudioConfig.Instance.One);
        _hoursToAudioClip.Add(2, AudioConfig.Instance.Two);
        _hoursToAudioClip.Add(3, AudioConfig.Instance.Three);
        _hoursToAudioClip.Add(4, AudioConfig.Instance.Fore);
        _hoursToAudioClip.Add(5, AudioConfig.Instance.Five);
        _hoursToAudioClip.Add(6, AudioConfig.Instance.Six);
        _hoursToAudioClip.Add(7, AudioConfig.Instance.Seven);
        _hoursToAudioClip.Add(8, AudioConfig.Instance.Eight);
        _hoursToAudioClip.Add(9, AudioConfig.Instance.Nine);
        _hoursToAudioClip.Add(10, AudioConfig.Instance.Ten);
        _hoursToAudioClip.Add(11, AudioConfig.Instance.Eleven);
        _hoursToAudioClip.Add(12, AudioConfig.Instance.Twelve);
        _hoursToAudioClip.Add(13, AudioConfig.Instance.Thirteen);
        _hoursToAudioClip.Add(14, AudioConfig.Instance.Fourteen);
        _hoursToAudioClip.Add(15, AudioConfig.Instance.Fiveteen);
        _hoursToAudioClip.Add(16, AudioConfig.Instance.Sixteen);
        _hoursToAudioClip.Add(17, AudioConfig.Instance.Seventeen);
        _hoursToAudioClip.Add(18, AudioConfig.Instance.Eighteen);
        _hoursToAudioClip.Add(19, AudioConfig.Instance.Nineteen);
        _hoursToAudioClip.Add(20, AudioConfig.Instance.Twentieth);
    }

    public void SayTime(int hours, bool sayHalfHour)
    {
        _sayMinutes = sayHalfHour;
        
        if (hours >= 1 && hours <= 20)
        {
            App.AudioController.PlaySound(_hoursToAudioClip[hours], OnFinishHourSay);
        }
        else if (hours > 20 && hours <= 24)
        {
            _remainder = hours - 20;
            App.AudioController.PlaySound(AudioConfig.Instance.Twenty, OnFinishRemainderSay);
        }
    }

    private void OnFinishRemainderSay()
    {
        SayTime(_remainder, _sayMinutes);
    }

    private void OnFinishHourSay()
    {
        if (_sayMinutes)
            App.AudioController.PlaySound(AudioConfig.Instance.Hour, OnFinishMinutesSay);
        else
            App.AudioController.PlaySound(AudioConfig.Instance.Hour);            
        
    }

    private void OnFinishMinutesSay()
    {
        _sayMinutes = false;
        App.AudioController.PlaySound(AudioConfig.Instance.ThirtyMsinutes);
    }
}
