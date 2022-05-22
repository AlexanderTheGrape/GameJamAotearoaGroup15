using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class Egg : MonoBehaviour
{
    private enum HatchStatus
    {
        unactivated,
        incubating,
        hatched,
        done
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

        this.tempDegreesCelcius = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("isFinishedHatching") == true)
        {
            HatchEgg();
            this.hatchStatus = HatchStatus.done;
        }
        if (this.hatchStatus == HatchStatus.hatched)
        {
            HatchEgg();
            this.hatchStatus = HatchStatus.done;
        }
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
    }

    public void HatchEgg()
    {

        //animator.SetBool("isHatching", false);

        //// TODO REMOVE THIS
        //this.animator.SetBool("isCritter1", true);
        //this.animator.SetBool("isHatching", false);
        switch (this.tempDegreesCelcius)
        {
            case 0:
                animator.SetBool("isCritter1", true);
                break;
            case 1:
                animator.SetBool("isCritter2", true);
                break;
            case 2:
                animator.SetBool("isCritter3", true);
                break;
            default:
                animator.SetBool("isFritter", true);
                break;
        }
    }

    public void EggIncubationStartedEvent()
    {
        this.hatchStatus = HatchStatus.incubating;
        animator.SetBool("isHatching", true);
        animator.speed = 0.1f;

        // Should be commented out in favour of animation-end timing
        SetTimer(eggIncubationPeriodMilliseconds);
    }

    public void IncreaseEggTemperature(int temperatureIncreaseCelcius)
    {
        this.tempDegreesCelcius += temperatureIncreaseCelcius;
    }

    public void IncreaseEggTemperatureByOne()
    {
        this.tempDegreesCelcius += 1;
    }

    public void ResetEgg()
    {
        animator.SetBool("needsReset", true);
    }
}



