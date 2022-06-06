using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour
{
    private Animator animator;

    int temperature = 0;

    bool needsUpdate = false;
    bool dumbBool = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("temperature", temperature);
    }

    void Update()
    {
        if (needsUpdate)
        {
            animator.SetInteger("temperature", temperature);
            needsUpdate = false;
            animator.SetBool("dumbBool", dumbBool);
        }
    }

    public void IncreaseThermometerTemperatureByOne()
    {
        temperature++;
        needsUpdate = true;
    }
}
