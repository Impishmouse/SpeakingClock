﻿using System.Collections;
using System.Collections.Generic;
using Controllers;
using ScriptableObjects;
using UnityEngine;


public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    private IEnumerator Start()
    {
        App.AudioController = FindObjectOfType<AudioController>();
        App.SayTimeController = FindObjectOfType<SayTimeController>();
        
        //UIManager.ChangeScreen<HomeScreen>();

        yield return null;

        //App.AudioController.PlayMusic(AudioConfig.Instance.MusicGameplay, 2f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
