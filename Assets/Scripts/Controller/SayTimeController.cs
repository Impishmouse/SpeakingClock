using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using ScriptableObjects;
using UnityEngine;

public class SayTimeController : MonoBehaviour
{
    //private const hoursToAudioClip = [];
    private Dictionary<int, AudioClip> hoursToAudioClip = new Dictionary<int, AudioClip>();
    private bool _sayMinutes;
    private int _remainder;

    private void Awake()
    {
        hoursToAudioClip.Add(1, AudioConfig.Instance.One);
        hoursToAudioClip.Add(2, AudioConfig.Instance.Two);
        hoursToAudioClip.Add(3, AudioConfig.Instance.Three);
        hoursToAudioClip.Add(4, AudioConfig.Instance.Fore);
        hoursToAudioClip.Add(5, AudioConfig.Instance.Five);
        hoursToAudioClip.Add(6, AudioConfig.Instance.Six);
        hoursToAudioClip.Add(7, AudioConfig.Instance.Seven);
        hoursToAudioClip.Add(8, AudioConfig.Instance.Eight);
        hoursToAudioClip.Add(9, AudioConfig.Instance.Nine);
        hoursToAudioClip.Add(10, AudioConfig.Instance.Ten);
        hoursToAudioClip.Add(11, AudioConfig.Instance.Eleven);
        hoursToAudioClip.Add(12, AudioConfig.Instance.Twelve);
        hoursToAudioClip.Add(13, AudioConfig.Instance.Thirteen);
        hoursToAudioClip.Add(14, AudioConfig.Instance.Fourteen);
        hoursToAudioClip.Add(15, AudioConfig.Instance.Fiveteen);
        hoursToAudioClip.Add(16, AudioConfig.Instance.Sixteen);
        hoursToAudioClip.Add(17, AudioConfig.Instance.Seventeen);
        hoursToAudioClip.Add(18, AudioConfig.Instance.Eighteen);
        hoursToAudioClip.Add(19, AudioConfig.Instance.Nineteen);
        hoursToAudioClip.Add(20, AudioConfig.Instance.Twentieth);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SayTime(int hours)
    {
        
    }

    public void SayTime(int hours, bool sayHalfHour)
    {
        _sayMinutes = sayHalfHour;
        
        if (hours >= 1 && hours <= 20)
        {
            App.AudioController.PlaySound(hoursToAudioClip[hours], OnFinishHourSay);
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
