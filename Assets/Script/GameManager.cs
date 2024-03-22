using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { private set; get; }

    public float FishRobWear;
    public float MaxFishHp;
    public float CurrentFishHp;
    public float MaxFishRobHp;
    public float CurrentFishRobHp;
    public float FishRobPower;
    public float CurrentFishingTime;
    public float MaxFishingTime;
    public bool UIOn;
    // Start is called before the first frame update
    private void Awake()
    {
        GameManager.instance = this;
        UIOn = false;
        CurrentFishingTime = 0;
        MaxFishingTime = 1.5f;
        CurrentFishingTime = MaxFishingTime;

    }

    void Start()
    {
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
