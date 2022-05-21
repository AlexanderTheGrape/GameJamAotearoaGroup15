using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public abstract class EggController : MonoBehaviour
{
    private enum HatchStatus
    {
        unactivated,
        incubating,
        hatched
    }
    private HatchStatus hatchStatus;
    private int tempDegreesCelcius { get; set; }
    private List<int> temperatureThresholdsForTransformation { get; set; }
    private int nestType { get; set; } // Change this later as I get more details on it


    


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private static void SetTimer(int milliseconds)
    {
        // Create a timer with a ___ second interval
        var timer = new System.Timers.Timer(milliseconds);
        timer.AutoReset = false;
        timer.Enabled = true;

        // The event to be triggered once the timer is done
        //timer.Elapsed += 
    }

    private static void EggInitiatedEvent(object source, ElapsedEventArgs e)
    {
        hatchStatus = HatchStatus.incubating;
    }

    public void increaseEggTemperature(int temperatureIncreaseCelcius)
    {
        this.tempDegreesCelcius += temperatureIncreaseCelcius;
    }
}



