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
        btnStartCoroutines.onClick.AddListener(OnStartCoroutines);
        
        // TODO :  
        // BASE Alg. - Check current time and initiate a method to say how many time is now or schedule a coroutine to waite.
        // 1. Make a method to say a current time hour or half hour. 
        // 2. Check time if it equal hour or half hour call method to say a time.
        // 3. Schedule coroutine to next hour or half hour to call say a time method. 
        
        
        
    }

    private void OnStartCoroutines()
    {
        StartCoroutine(Countdown2());
    }

    private IEnumerator Countdown2() {
        while(true) {
            yield return new WaitForSeconds(2); //wait 2 seconds
            //do thing
            OnPlayButtonClickHandler();
            yield return new WaitForSeconds(5); //wait 2 seconds
        }
    }
    
    private void OnPlayButtonClickHandler()
    {
        App.SayTimeController.SayTime(10, true);
    }

    
}
