using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FishingSystem : MonoBehaviour
{
    public float MaxFishHp;
    public float CurrentFishHp;
    public float FishRobHp;
    public float FishRobPower;
    public bool Ishrowing;
    private bool IsFocus;


    // Start is called before the first frame update
    void Start()
    {
        Ishrowing = false;
        CurrentFishHp = MaxFishHp;
    }

    // Update is called once per frame
    void Update()
    {
        Fishing();
    }

    void Fishing()
    {
        if(IsFocus == true)
        {
            if (Input.touchCount > 0)
            {
                for(int i = 0; i < Input.touchCount; i++)
                {
                    if (EventSystem.current.IsPointerOverGameObject(i) == false)
                    {
                        Touch touch = Input.GetTouch(0);
                        if (touch.phase == TouchPhase.Began)
                        {
                            if (Ishrowing)
                            {
                                CurrentFishHp -= FishRobPower;
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
                }

            }
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        IsFocus = focus;
    }
}
