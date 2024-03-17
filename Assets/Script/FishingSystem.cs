using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FishingSystem : MonoBehaviour
{

    private bool Ishrowing;
    private bool IsFocus;


    // Start is called before the first frame update
    void Start()
    {
        Ishrowing = false;
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
                    GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower;
                    GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear;
                    if (GameManager.instance.CurrentFishHp == 0)
                    {
                        GameManager.instance.CurrentFishHp = GameManager.instance.MaxFishHp;
                        Ishrowing = false;
                    }
                }
                else
                {
                    Ishrowing = true;
                }
            }
        }
        if(GameManager.instance.CurrentFishRobHp <= 0)
        {
            Debug.Log("³«½Ã Á¾·á");
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        IsFocus = focus;
    }
}
