using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FishManager : MonoBehaviour
{
    public static FishManager instance { private set; get; }

    public int TearNum;
    public int FishNum;
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
    [Serializable]

    public class A_FishList
    {
        public Sprite FishIcon;
        public string FishName;
        public float FishHp;
        public float FishPower;
    }
    [Serializable]

    public class B_FishList
    {
        public Sprite FishIcon;
        public string FishName;
        public float FishHp;
        public float FishPower;
    }
    [Serializable]

    public class C_FishList
    {
        public Sprite FishIcon;
        public string FishName;
        public float FishHp;
        public float FishPower;
    }
    [Serializable]

    public class D_FishList
    {
        public Sprite FishIcon;
        public string FishName;
        public float FishHp;
        public float FishPower;
    }
    [Serializable]

    public class F_FishList
    {
        public Sprite FishIcon;
        public string FishName;
        public float FishHp;
        public float FishPower;
    }


    public List<S_FishList> S_Fishlist;
    public List<A_FishList> A_Fishlist;
    public List<B_FishList> B_Fishlist;
    public List<C_FishList> C_Fishlist;
    public List<D_FishList> D_Fishlist;
    public List<F_FishList> F_Fishlist;



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
        if(TearNum <= 1)
        {
            ChoiceFish_S();
        }
        else if (TearNum <= 5)
        {
            ChoiceFish_A();
        }
        else if (TearNum <= 15)
        {
            ChoiceFish_B();
        }
        else if (TearNum <= 25)
        {
            ChoiceFish_C();
        }
        else if (TearNum <= 60)
        {
            ChoiceFish_D();
        }
        else if (TearNum <= 100)
        {
            ChoiceFish_F();
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
        GameManager.instance.FishTear = "S";
    }

    void ChoiceFish_A()
    {
        if (ChoiceFishOnce == false)
        {
            FishNum = UnityEngine.Random.Range(0, S_Fishlist.Count);
            ChoiceFishOnce = true;
        }

        GameManager.instance.MaxFishHp = A_Fishlist[FishNum].FishHp;
        GameManager.instance.FishRobWear = A_Fishlist[FishNum].FishPower;
        GameManager.instance.FishIcon = A_Fishlist[FishNum].FishIcon;
        GameManager.instance.FishName = A_Fishlist[FishNum].FishName;
        GameManager.instance.FishTear = "A";

    }

    void ChoiceFish_B()
    {
        if (ChoiceFishOnce == false)
        {
            FishNum = UnityEngine.Random.Range(0, S_Fishlist.Count);
            ChoiceFishOnce = true;
        }

        GameManager.instance.MaxFishHp = B_Fishlist[FishNum].FishHp;
        GameManager.instance.FishRobWear = B_Fishlist[FishNum].FishPower;
        GameManager.instance.FishIcon = B_Fishlist[FishNum].FishIcon;
        GameManager.instance.FishName = B_Fishlist[FishNum].FishName;
        GameManager.instance.FishTear = "B";

    }

    void ChoiceFish_C()
    {
        if (ChoiceFishOnce == false)
        {
            FishNum = UnityEngine.Random.Range(0, S_Fishlist.Count);
            ChoiceFishOnce = true;
        }

        GameManager.instance.MaxFishHp = C_Fishlist[FishNum].FishHp;
        GameManager.instance.FishRobWear = C_Fishlist[FishNum].FishPower;
        GameManager.instance.FishIcon = C_Fishlist[FishNum].FishIcon;
        GameManager.instance.FishName = C_Fishlist[FishNum].FishName;
        GameManager.instance.FishTear = "C";

    }

    void ChoiceFish_D()
    {
        if (ChoiceFishOnce == false)
        {
            FishNum = UnityEngine.Random.Range(0, S_Fishlist.Count);
            ChoiceFishOnce = true;
        }

        GameManager.instance.MaxFishHp = D_Fishlist[FishNum].FishHp;
        GameManager.instance.FishRobWear = D_Fishlist[FishNum].FishPower;
        GameManager.instance.FishIcon = D_Fishlist[FishNum].FishIcon;
        GameManager.instance.FishName = D_Fishlist[FishNum].FishName;
        GameManager.instance.FishTear = "D";

    }

    void ChoiceFish_F()
    {
        if (ChoiceFishOnce == false)
        {
            FishNum = UnityEngine.Random.Range(0, S_Fishlist.Count);
            ChoiceFishOnce = true;
        }

        GameManager.instance.MaxFishHp = F_Fishlist[FishNum].FishHp;
        GameManager.instance.FishRobWear = F_Fishlist[FishNum].FishPower;
        GameManager.instance.FishIcon = F_Fishlist[FishNum].FishIcon;
        GameManager.instance.FishName = F_Fishlist[FishNum].FishName;
        GameManager.instance.FishTear = "F";

    }
}