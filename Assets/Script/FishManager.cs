using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishManager : MonoBehaviour
{
    public static FishManager instance { private set; get; }

    private int TearNum;
    private int FishNum;
    public bool ChoiceFishTearOnce;
    public bool ChoiceFishOnce;

    [Serializable]
    public class S_FishList
    {
        public Sprite FishIcon;
        public string FishName;
        public float FishHp;
        public float FishPower;
    }


    public List<S_FishList> S_Fishlist;



    private void Awake()
    {
        FishManager.instance = this;
    }

    private void Start()
    {
        TearNum = 0;
        FishNum = 0;
        ChoiceFishTearOnce = false;
        ChoiceFishOnce = false;
    }

    public void ChoiceFish()
    {
        if (ChoiceFishTearOnce == false)
        {
            TearNum = UnityEngine.Random.Range(1, 101);
            ChoiceFishTearOnce = true;
        }
        if(TearNum > 0)
        {
            ChoiceFish_S();
        }

    }

    void ChoiceFish_S()
    {
        if (ChoiceFishOnce == false)
        {
            FishNum = UnityEngine.Random.Range(0, S_Fishlist.Count);
            ChoiceFishOnce = true;
        }

        GameManager.instance.MaxFishHp = S_Fishlist[FishNum].FishHp;
        GameManager.instance.FishRobWear = S_Fishlist[FishNum].FishPower;
        GameManager.instance.FishIcon = S_Fishlist[FishNum].FishIcon;
        GameManager.instance.FishName = S_Fishlist[FishNum].FishName;
    }
}