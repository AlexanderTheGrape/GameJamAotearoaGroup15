using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EggController : MonoBehaviour
{
    private enum hatchStatus
    {
        unactivated,
        incubating,
        hatched
    }
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
        var aSetTimer = new System.Timers.Timer(milliseconds);
        aSetTimer.AutoReset = true;
        aSetTimer.Enabled = true;
    }

    public void increaseEggTemperature(int temperatureIncreaseCelcius)
    {
        this.tempDegreesCelcius += temperatureIncreaseCelcius;
    }
}



