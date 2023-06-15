using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class SayTimeController : MonoBehaviour
{
    //private const hoursToAudioClip = [];
    private Dictionary<int, AudioClip> _hoursToAudioClip;
    private bool _sayMinutes;
    private int _remainder;
    private int _hours;
    private bool _needsStartRingPlay;

    private void Awake()
    {
        _needsStartRingPlay = true;
        
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
        _hoursToAudioClip.Add(20, AudioConfig.Instance.Twenty);
        _hoursToAudioClip.Add(21, AudioConfig.Instance.TwentyOne);
        _hoursToAudioClip.Add(22, AudioConfig.Instance.TwentySecond);
        _hoursToAudioClip.Add(23, AudioConfig.Instance.TwentyThird);
        _hoursToAudioClip.Add(24, AudioConfig.Instance.TwentyFourth);
    }

    public bool NeedsStartRingPlay {
        set {
            _needsStartRingPlay = value;
        }
    }
    
    public void SayTime(int hours, int minutes)
    {
        SayTime(hours,minutes == 30);
    }
    
    public void SayTime(int hours, bool sayMinutes)
    {
        _hours = hours;
        _sayMinutes = sayMinutes;

        if (_needsStartRingPlay)
        {
            _needsStartRingPlay = false;
            App.AudioController.PlaySound(AudioConfig.Instance.StartRing, OnFinishStartRing);
            return;
        }    
        
        if (hours >= 1 && hours <= 24)
        {
            App.AudioController.PlaySound(_hoursToAudioClip[hours], OnFinishHourSay);
        }
    }

    private void OnFinishStartRing()
    {
        SayTime(_hours, _sayMinutes);
    }
    
    private void OnFinishRemainderSay()
    {
        SayTime(_remainder, _sayMinutes);
    }

    private void OnFinishHourSay()
    {
        if (_sayMinutes)
            OnFinishMinutesSay();
    }

    private void OnFinishMinutesSay()
    {
        _sayMinutes = false;
        App.AudioController.PlaySound(AudioConfig.Instance.ThirtyMsinutes);
    }
}
