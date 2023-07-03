using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AudioData 
{
    [SerializeField] private AudioType audioType;
    [SerializeField] private List<AudioClip> audioClips;
    
    public enum AudioType
    {
        Null,
        HourNumbers,
        Weather, 
        Numbers
    }
}
