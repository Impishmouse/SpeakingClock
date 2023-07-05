using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioData 
{
    [SerializeField] public AudioType audioType;
    [SerializeField] public List<AudioClip> audioClips;
    
    public enum AudioType
    {
        Null,
        HourNumbers,
        Weather, 
        Numbers
    }
}
