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
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance = this;

        CurrentFishHp = MaxFishHp;
        CurrentFishRobHp = MaxFishRobHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
