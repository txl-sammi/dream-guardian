using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using System;


public class TimeController : MonoBehaviour
{
    [SerializeField]  float startHour;
    [SerializeField]  float timeMultiplier;
    [SerializeField]  TextMeshProUGUI timeText;


    private DateTime currentTime;
    private DateTime startTime;
    private TimeSpan elapsedTime;
    

    void Start()
    {
        currentTime = DateTime.Now.Date + TimeSpan.FromHours(startHour);
        startTime = currentTime;
        elapsedTime = currentTime - startTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        
    }
    
    private void UpdateTime(){
        currentTime = currentTime.AddSeconds(Time.deltaTime * timeMultiplier);
        if(timeText){
            timeText.text = currentTime.ToString("HH:mm");
        }
    }

    public TimeSpan totalTime(){
        return elapsedTime;
    }
}
