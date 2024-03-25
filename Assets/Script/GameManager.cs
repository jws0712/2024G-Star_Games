using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { private set; get; }

    [Header("FishingSysetem")]

    public float MaxFishHp;
    public float CurrentFishHp;

    public float MaxFishRobHp;
    public float CurrentFishRobHp;

    public float FishRobPower;
    public float FishRobWear;

    public float CurrentFishingTime;
    public float MaxFishingTime;

    [Header("UI")]

    public bool UIOn;
    public bool FishUIOn;

    [Header("FishInfo")]

    public Sprite FishIcon;
    public string FishName;
    public float Money;

    private void Awake()
    {
        
        GameManager.instance = this;
    }

    void Start()
    {
        FishManager.instance.ChoiceFish();
        UIOn = false;
        CurrentFishingTime = 0;
        MaxFishingTime = 1.5f;
        CurrentFishingTime = MaxFishingTime;
        CurrentFishHp = MaxFishHp;
        CurrentFishRobHp = MaxFishRobHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.UIOn == true)
        {
            CurrentFishingTime -= Time.deltaTime;
        }
        
    }
}
