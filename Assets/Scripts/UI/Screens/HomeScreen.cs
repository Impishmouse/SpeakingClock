using System;
using System.Collections;
using Core.UI.Manager.Abstract;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : BaseScreen
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnStartCoroutines;

    protected override void Awake()
    {
        base.Awake();
        btnPlay.onClick.AddListener(OnPlayButtonClickHandler);
        btnStartCoroutines.onClick.AddListener(OnTestMinutesSay);

        // TODO :   Clock controller and time sayer
        // BASE Alg. - Check current time and initiate a method to say how many time is now or schedule a coroutine to waite.
        // Done 1. Make a method to say a current time hour or half hour. 
        // Done 2. Check time if it equal hour or half hour call method to say a time.
        // Done 3. Schedule coroutine to next hour or half hour to call say a time method.
        // Done 4. Make a next schedule for next period, may be add delay in 30 minutes ? 
        
        // TODO :  Weather controller sayer.
        // Base get data from  https://api.openweathermap.org/data/2.5/weather?id=702550&units=metric&lang=ua&appid=789ce2a5ee25556243a78f50f5aa1547
    }

    protected void Start()
    {
        var time = GetCurrentTime();
        // If at start need to say current time cause full hour or half hour 
        if (time.Minute is 0 or 30)
        {
            SayAndScheduleNext();
        }
        else // schedule a coroutine to next full hour or half hour.
        {
            var delay = MinToSec((time.Minute > 30 ? 60 : 30) - time.Minute);
            Debug.Log("Set delay to (" + delay + ") seconds");
            StartCoroutine(ScheduleTimeToSay(delay));
        }
    }

    private DateTime GetCurrentTime()
    {
        var time = System.DateTime.UtcNow.ToLocalTime();
        Debug.Log(time.ToString());
        return time;
    }

    private IEnumerator ScheduleTimeToSay(int waiteTime)
    {
        yield return new WaitForSeconds(waiteTime); //wait time in seconds
        SayAndScheduleNext();
        yield return null;
    }

    private void SayCurrentTime()
    {
        var time = GetCurrentTime();
        App.SayTimeController.SayTime(time.Hour, time.Minute);
    }

    private void SayAndScheduleNext()
    {
        SayCurrentTime();
        StartCoroutine(ScheduleTimeToSay(MinToSec(30)));
    }

    private int MinToSec(int minutes)
    {
        return minutes * 60;
    }

    private void OnTestMinutesSay()
    {
        //App.SayTimeController.SayTime(10, 30);
        
        var weather = gameObject.AddComponent<WeatherGetController>() ;
        
    }

    private void OnPlayButtonClickHandler()
    {
        App.SayTimeController.NeedsStartRingPlay = true;
        SayCurrentTime();
    }
}