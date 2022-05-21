using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class EggController : MonoBehaviour
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

    private int eggIncubationPeriodMilliseconds { get; set; }

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isHatching", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetTimer(int milliseconds)
    {
        // Create a timer with a ___ second interval
        var timer = new System.Timers.Timer(5000);
        timer.AutoReset = false;
        timer.Enabled = true;

        // The event to be triggered once the timer is done
        timer.Elapsed += new ElapsedEventHandler(EggHatchedEvent);
    }

    private void EggHatchedEvent(object source, ElapsedEventArgs e)
    {
        this.hatchStatus = HatchStatus.hatched;
        animator.SetBool("isHatching", false);
    }

    public void EggIncubationStartedEvent()
    {
        this.hatchStatus = HatchStatus.incubating;
        animator.SetBool("isHatching", true);
        SetTimer(eggIncubationPeriodMilliseconds);
    }

    public void IncreaseEggTemperature(int temperatureIncreaseCelcius)
    {
        this.tempDegreesCelcius += temperatureIncreaseCelcius;
    }
}



