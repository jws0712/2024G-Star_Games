using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FishingSystem : MonoBehaviour
{
    private bool SwipeAction;
    private bool TouchAction;
    private bool HoldAction;
    private bool Ishrowing;
    private bool IsFocus;
    
    public enum ActionState
    {
        Swipe,
        Touch,
        Hold
    }

    public ActionState actionState;



    // Start is called before the first frame update
    void Start()
    {
        SwipeAction = false;
        TouchAction = false;
        SwipeAction = false;
        Ishrowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        Fishing_Mobile();
        //Fishing_PC();
    }

    void Fishing_Mobile()
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
    }

    void Fishing_PC()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
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

        if (GameManager.instance.CurrentFishRobHp <= 0)
        {
            Debug.Log("³«½Ã Á¾·á");
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        IsFocus = focus;
    }

    void TouchAction()
    {

    }

    void SwipeAction()
    {

    }

    void HoldAction()
    {

    }
}
