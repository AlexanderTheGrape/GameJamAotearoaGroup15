using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject egg1Prefab;
    public GameObject egg2Prefab;
    public GameObject egg3Prefab;
    public GameObject thermometerPrefab;

    private GameObject eggClone;
    private Egg currentEgg;
    private Transform currentEggLocation;

    private GameObject thermometerClone;
    private Thermometer thermometer;


    private int currentEggAsNum = 1;
    private bool hasThermometer = false;


    // Start is called before the first frame update
    void Start()
    {
        InstantiateEgg(currentEggAsNum);
        

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateEgg(int currentEggAsNum)
    {
        switch(currentEggAsNum)
        {
            case 1:
                eggClone = Instantiate(egg1Prefab, new Vector2(0, 0), Quaternion.identity);
                break;
            case 2:
                eggClone = Instantiate(egg2Prefab, new Vector2(0, 0), Quaternion.identity);
                break;
            case 3:
                eggClone = Instantiate(egg3Prefab, new Vector2(0, 0), Quaternion.identity);
                break;
            default:
                eggClone = Instantiate(egg1Prefab, new Vector2(0, 0), Quaternion.identity);
                break;
        }

        currentEgg = eggClone.GetComponent<Egg>();
        currentEggLocation = eggClone.GetComponent<Transform>();
    }

    public void ResetEgg()
    {
        RemoveEgg();
        Start();
    }

    private void RemoveEgg()
    {
        Destroy(currentEgg);
        Destroy(eggClone);
        Destroy(thermometer);
        Destroy(thermometerClone);
        hasThermometer = false;
    }

    public void EggIncubationStartedEvent()
    {
        currentEgg.EggIncubationStartedEvent();
    }

    public void IncreaseEggTemperature()
    {
        if (!hasThermometer)
        {
            hasThermometer = true;
            thermometerClone = Instantiate(thermometerPrefab, new Vector2(5, -1), Quaternion.identity);
            thermometer = thermometerClone.GetComponent<Thermometer>();
        }

        currentEgg.IncreaseEggTemperatureByOne();
        thermometer.IncreaseThermometerTemperatureByOne();
        
    }

    public void HatchEgg()
    {
        currentEgg.HatchEgg();
        eggClone.transform.SetPositionAndRotation(new Vector3(0, 1, 100), Quaternion.identity);
    }

    public void NextEgg()
    {
        RemoveEgg();
        
        if (currentEggAsNum >= 3)
        {
            currentEggAsNum = 1;
        } else
        {
            currentEggAsNum++;
        }

        InstantiateEgg(currentEggAsNum);
    }

    private void UpdateThermometer()
    {

    }
}
