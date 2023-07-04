using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class SayTimeController : MonoBehaviour
{
    /**
     * 
     *  Simple say time audio controller.
     *  Which plays hours and 30 minutes by play short audio sources in correct sequence.   
     *  
     */
    
    
    private Dictionary<int, AudioClip> _hoursToAudioClip;
    private bool _sayMinutes;
    private int _remainder;
    private int _hours;
    private bool _needsStartRingPlay;

    private void Awake()
    {
        _needsStartRingPlay = true;
        
        var numberHours = AudioConfig.Instance.GetAudioByType(AudioData.AudioType.HourNumbers); 
        
        _hoursToAudioClip = new Dictionary<int, AudioClip>();
        _hoursToAudioClip.Add(1, numberHours.audioClips[0]);
        _hoursToAudioClip.Add(2, numberHours.audioClips[1]);
        _hoursToAudioClip.Add(3, numberHours.audioClips[2]);
        _hoursToAudioClip.Add(4, numberHours.audioClips[3]);
        _hoursToAudioClip.Add(5, numberHours.audioClips[4]);
        _hoursToAudioClip.Add(6, numberHours.audioClips[5]);
        _hoursToAudioClip.Add(7, numberHours.audioClips[6]);
        _hoursToAudioClip.Add(8, numberHours.audioClips[7]);
        _hoursToAudioClip.Add(9, numberHours.audioClips[8]);
        _hoursToAudioClip.Add(10, numberHours.audioClips[9]);
        _hoursToAudioClip.Add(11, numberHours.audioClips[10]);
        _hoursToAudioClip.Add(12, numberHours.audioClips[11]);
        _hoursToAudioClip.Add(13, numberHours.audioClips[12]);
        _hoursToAudioClip.Add(14, numberHours.audioClips[13]);
        _hoursToAudioClip.Add(15, numberHours.audioClips[14]);
        _hoursToAudioClip.Add(16, numberHours.audioClips[15]);
        _hoursToAudioClip.Add(17, numberHours.audioClips[16]);
        _hoursToAudioClip.Add(18, numberHours.audioClips[17]);
        _hoursToAudioClip.Add(19, numberHours.audioClips[18]);
        _hoursToAudioClip.Add(20, numberHours.audioClips[19]);
        _hoursToAudioClip.Add(21, numberHours.audioClips[20]);
        _hoursToAudioClip.Add(22, numberHours.audioClips[21]);
        _hoursToAudioClip.Add(23, numberHours.audioClips[22]);
        _hoursToAudioClip.Add(24, numberHours.audioClips[23]);
        _hoursToAudioClip.Add(25, numberHours.audioClips[24]);
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
        App.AudioController.PlaySound(_hoursToAudioClip[25]);
    }
}
