using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    public GameObject egg1Prefab;
    public GameObject egg2Prefab;
    public GameObject egg3Prefab;

    private GameObject clone;
    private Egg currentEgg;



    // Start is called before the first frame update
    void Start()
    {
        InstantiateEgg();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateEgg()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        clone = Instantiate(egg1Prefab, new Vector2(0, 0), Quaternion.identity);

        currentEgg = clone.GetComponent<Egg>();
    }

    public void ResetEgg()
    {
        Destroy(currentEgg);
        Destroy(clone);

        Start();
    }

    public void EggIncubationStartedEvent()
    {
        currentEgg.EggIncubationStartedEvent();
    }

    public void IncreaseEggTemperature()
    {
        currentEgg.IncreaseEggTemperatureByOne();
    }

    public void HatchEgg()
    {
        currentEgg.HatchEgg();
    }
}
