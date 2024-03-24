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
        public GameObject FihsIcon;
        public string FishName;
        public float FishHp;
        public float FishPower;
        public float MoneyValue;
    }

    [Serializable]
    public class A_FishList
    {
        public GameObject FihsIcon;
        public string FishName;
        public float FishHp;
        public float FishPower;
        public float MoneyValue;
    }

    [Serializable]
    public class B_FishList
    {
        public GameObject FihsIcon;
        public string FishName;
        public float FishHp;
        public float FishPower;
        public float MoneyValue;
    }

    [Serializable]
    public class C_FishList
    {
        public GameObject FihsIcon;
        public string FishName;
        public float FishHp;
        public float FishPower;
        public float MoneyValue;
    }

    [Serializable]
    public class D_FishList
    {
        public GameObject FihsIcon;
        public string FishName;
        public float FishHp;
        public float FishPower;
        public float MoneyValue;
    }

    [Serializable]
    public class F_FishList
    {
        //public GameObject FihsIcon;
        //public string FishName;
        public float FishHp;
        public float FishPower;
        //public float MoneyValue;
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
        if(TearNum >= 100)
        {
            ChoiceFish_F();
        }
        //else if(TearNum >= )
        //{
        //    ChoiceFish_D();
        //}
        //else if (TearNum >= )
        //{
        //    ChoiceFish_C();
        //}
        //else if (TearNum >= )
        //{
        //    ChoiceFish_B();
        //}
        //else if (TearNum >= )
        //{
        //    ChoiceFish_A();
        //}
        else if(TearNum >= 1)
        {
            ChoiceFish_S();
        }
        
    }

    void ChoiceFish_S()
    {
        if(ChoiceFishOnce == false)
        {
            FishNum = UnityEngine.Random.Range(0, S_Fishlist.Count);
            ChoiceFishOnce = true;
        }

        S_Fishlist[FishNum].FishHp = GameManager.instance.MaxFishHp;
        S_Fishlist[FishNum].FishPower = GameManager.instance.FishRobWear;

        
    }
    void ChoiceFish_A()
    {
        if (ChoiceFishOnce == false)
        {
            FishNum = UnityEngine.Random.Range(0, S_Fishlist.Count);
            ChoiceFishOnce = true;
        }

        A_Fishlist[FishNum].FishHp = GameManager.instance.MaxFishHp;
        A_Fishlist[FishNum].FishPower = GameManager.instance.FishRobWear;


    }
    void ChoiceFish_B()
    {
        if (ChoiceFishOnce == false)
        {
            FishNum = UnityEngine.Random.Range(0, S_Fishlist.Count);
            ChoiceFishOnce = true;
        }

        B_Fishlist[FishNum].FishHp = GameManager.instance.MaxFishHp;
        B_Fishlist[FishNum].FishPower = GameManager.instance.FishRobWear;


    }
    void ChoiceFish_C()
    {
        if (ChoiceFishOnce == false)
        {
            FishNum = UnityEngine.Random.Range(0, S_Fishlist.Count);
            ChoiceFishOnce = true;
        }

        C_Fishlist[FishNum].FishHp = GameManager.instance.MaxFishHp;
        C_Fishlist[FishNum].FishPower = GameManager.instance.FishRobWear;


    }
    void ChoiceFish_D()
    {
        if (ChoiceFishOnce == false)
        {
            FishNum = UnityEngine.Random.Range(0, S_Fishlist.Count);
            ChoiceFishOnce = true;
        }

        D_Fishlist[FishNum].FishHp = GameManager.instance.MaxFishHp;
        D_Fishlist[FishNum].FishPower = GameManager.instance.FishRobWear;


    }
    void ChoiceFish_F()
    {
        if (ChoiceFishOnce == false)
        {
            FishNum = UnityEngine.Random.Range(0, S_Fishlist.Count);
            ChoiceFishOnce = true;
        }

        F_Fishlist[FishNum].FishHp = GameManager.instance.MaxFishHp;
        F_Fishlist[FishNum].FishPower = GameManager.instance.FishRobWear;


    }
}
