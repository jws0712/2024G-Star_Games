using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FishingSystem : MonoBehaviour
{
    public float FishRobWear;
    public float MaxFishHp;
    public float CurrentFishHp;
    public float MaxFishRobHp;
    public float CurrentFishRobHp;
    public float FishRobPower;
    public bool Ishrowing;
    private bool IsFocus;


    // Start is called before the first frame update
    void Start()
    {
        Ishrowing = false;
        CurrentFishHp = MaxFishHp;
        CurrentFishRobHp = MaxFishRobHp;
    }

    // Update is called once per frame
    void Update()
    {
        Fishing();
    }

    void Fishing()
    {
        if(!IsFocus || Input.touchCount == 0)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);

        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (Ishrowing)
                {
                    CurrentFishHp -= FishRobPower;
                    CurrentFishRobHp -= FishRobWear;
                    if (CurrentFishHp == 0)
                    {
                        CurrentFishHp = MaxFishHp;
                        Ishrowing = false;
                    }
                }
                else
                {
                    Ishrowing = true;
                }
            }
        }
        if(CurrentFishRobHp <= 0)
        {
            Debug.Log("³«½Ã Á¾·á");
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        IsFocus = focus;
    }
}
