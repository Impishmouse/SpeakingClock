using System;
using System.Collections;
using Controller;
using Core.UI.Manager.Abstract;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HomeScreen : BaseScreen
{
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnSecondTest;
    
    private WeatherGetController weatherGetter;
    
    protected override void Awake()
    {
        base.Awake();
        btnPlay.onClick.AddListener(OnPlayButtonClickHandler);
        btnSecondTest.onClick.AddListener(OnTestSecondButtonClick);

        // TODO :   Clock controller and time sayer
        // BASE Alg. - Check current time and initiate a method to say how many time is now or schedule a coroutine to waite.
        // Done 1. Make a method to say a current time hour or half hour. 
        // Done 2. Check time if it equal hour or half hour call method to say a time.
        // Done 3. Schedule coroutine to next hour or half hour to call say a time method.
        // Done 4. Make a next schedule for next period, may be add delay in 30 minutes ? 
        
        // TODO :  Weather controller sayer.
        // Done!    1. Use  Base get data from  https://api.openweathermap.org/data/2.5/weather?id=702550&units=metric&lang=ua&appid=789ce2a5ee25556243a78f50f5aa1547
        // Done!    2. Say weather type.
        //          3. Say current temperature 
        //              3.0. Make with PyCharm dictionary of the sounds which can say temperature from -30 to +30
        //              3.1. Say it by writing a NumbersSayController
        //          4. Say Humidity in % with step 5%.
        //              4.0  Make with PyCharm dictionary of the sounds which can say percentage of the humidity.
        //              4.1 Say it by writing a PercentageSayController
        //          5. Write a task system which can execute some tasks async until its Complete.
        //          6. Organize all process to (start ring)=>(say time)=>(say weather full)
        //             6.1. by press the button or message from the telegram add to the end of the queue (say weather short).
        //             6.2. Think about interrupt current task like a waite 30m or full hour add and execute new task 
        //                  and later comeback to execution off the interrupted task.   
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
        weatherGetter = FindObjectOfType<WeatherGetController>();
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

    private void OnTestSecondButtonClick()
    {
        weatherGetter.CompleteEvent += OnSuccessWeatherGot;
        weatherGetter.Execute();
    }

    private void OnSuccessWeatherGot(bool obj)
    {
        weatherGetter.CompleteEvent -= OnSuccessWeatherGot;
        //App.SayWeatherController.SayWeather(weatherGetter.WeatherData);
        App.SayNumbersController.SayWeather(weatherGetter.WeatherData);
    }

    private void OnPlayButtonClickHandler()
    {
        App.SayTimeController.NeedsStartRingPlay = true;
        SayCurrentTime();
    }
}