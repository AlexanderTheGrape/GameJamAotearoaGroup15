using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    public GameObject egg1Prefab;
    public GameObject egg2Prefab;
    public GameObject egg3Prefab;
    public GameObject warmingUpText;
    public GameObject buttonClickObject;

    private int currentEggAsNum = 1;

    private GameObject clone;
    private Egg currentEgg;
    private Transform currentEggLocation;
    private GameObject warmingUpTextObj;
    private AudioSource buttonClickAudio;



    // Start is called before the first frame update
    void Start()
    {
        InstantiateEgg(currentEggAsNum);
        

        SetupAudio();
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupAudio()
    {
        buttonClickAudio = buttonClickObject.GetComponent<AudioSource>();
    }

    void InstantiateEgg(int currentEggAsNum)
    {
        switch(currentEggAsNum)
        {
            case 1:
                clone = Instantiate(egg1Prefab, new Vector2(0, 0), Quaternion.identity);
                break;
            case 2:
                clone = Instantiate(egg2Prefab, new Vector2(0, 0), Quaternion.identity);
                break;
            case 3:
                clone = Instantiate(egg3Prefab, new Vector2(0, 0), Quaternion.identity);
                break;
            default:
                clone = Instantiate(egg1Prefab, new Vector2(0, 0), Quaternion.identity);
                break;
        }

        currentEgg = clone.GetComponent<Egg>();
        currentEggLocation = clone.GetComponent<Transform>();
    }

    public void ResetEgg()
    {
        RemoveEgg();
        Start();
    }

    private void RemoveEgg()
    {
        Destroy(currentEgg);
        Destroy(clone);
    }

    public void EggIncubationStartedEvent()
    {
        currentEgg.EggIncubationStartedEvent();
    }

    public void IncreaseEggTemperature()
    {
        ButtonClickSound();
        currentEgg.IncreaseEggTemperatureByOne();

        warmingUpTextObj = Instantiate(warmingUpText, new Vector2(5, -1), Quaternion.identity);
    }

    public void HatchEgg()
    {
        currentEgg.HatchEgg();
        clone.transform.SetPositionAndRotation(new Vector3(0, 1, 100), Quaternion.identity);
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

    public void ButtonClickSound()
    {
        buttonClickAudio.Play(0);
    }
}
