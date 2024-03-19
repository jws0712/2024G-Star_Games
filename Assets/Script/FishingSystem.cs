using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FishingSystem : MonoBehaviour
{
    private bool IsThrowing;
    private bool IsFocus;
    private float ActionTime;
    private float holdTIme;

    public enum PlayState
    {
        Play,
        End,
        Pause
    }
    public enum ActionState
    {
        Idle,
        Swipe,
        Hold,
        Touch,
    }

    public ActionState actionState;
    public PlayState playState;



    // Start is called before the first frame update
    void Start()
    {
        actionState = ActionState.Idle;
        IsThrowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.CurrentFishHp == 0)
        {
            GameManager.instance.CurrentFishHp = GameManager.instance.MaxFishHp;
        }

        Fishing_Mobile();
    }

    void Fishing_Mobile()
    {
        if(actionState == ActionState.Idle)
        {
            ThrowRob();
        }
        if(actionState == ActionState.Touch)
        {
            TouchAction();
            InvokeRepeating("ActionLogic", 0f, ActionTime);
        }
    }

    void ActionLogic()
    {
        float ActionNum = Random.Range(1, 4);
        switch (ActionNum)
        {
            case 1:
                {
                    SwipeLeftAction();
                    break;
                }
            case 2:
                {
                    SwipeRightAction();
                    break;
                }
            case 3:
                {
                    SwipeUpAction();
                    break;
                }
            case 4:
                {
                    HoldAction();
                    break;
                }
        }
    }

    void ThrowRob()
    {
        Vector2 StartTocuh = Vector2.zero;
        Vector2 EndTocuh = Vector2.zero;

        if (!IsFocus || Input.touchCount == 0)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);

        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            if (touch.phase == TouchPhase.Began)
            {
                StartTocuh = Input.GetTouch(0).position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                EndTocuh = Input.GetTouch(0).position;

                if (StartTocuh.y > EndTocuh.y)
                {
                    actionState = ActionState.Touch;
                }
            }
        }
    }


    void TouchAction()
    {
        if (!IsFocus || Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);
        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            if (touch.phase == TouchPhase.Began)
            {
                GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower;
                GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear;
            }
        }
    }

    void SwipeUpAction()
    {
        actionState = ActionState.Swipe;
        Vector2 StartTocuh = Vector2.zero;
        Vector2 EndTocuh = Vector2.zero;
        if (!IsFocus || Input.touchCount == 0)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);

        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            if(touch.phase == TouchPhase.Began)
            {
                StartTocuh = Input.GetTouch(0).position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                EndTocuh = Input.GetTouch(0).position;

                if(StartTocuh.y > EndTocuh.y)
                {
                    GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower * 5;
                    GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear * 2;
                    actionState = ActionState.Touch;
                }
            }
        }
    }

    void SwipeLeftAction()
    {
        actionState = ActionState.Swipe;
        Vector2 StartTocuh = Vector2.zero;
        Vector2 EndTocuh = Vector2.zero;
        if (!IsFocus || Input.touchCount == 0)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);

        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            if (touch.phase == TouchPhase.Began)
            {
                StartTocuh = Input.GetTouch(0).position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                EndTocuh = Input.GetTouch(0).position;

                if (StartTocuh.x > EndTocuh.x)
                {
                    GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower * 3;
                    GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear * 2;
                    actionState = ActionState.Touch;
                }
            }
        }
    }

    void SwipeRightAction()
    {
        actionState = ActionState.Swipe;
        Vector2 StartTocuh = Vector2.zero;
        Vector2 EndTocuh = Vector2.zero;
        if (!IsFocus || Input.touchCount == 0)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);

        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            if (touch.phase == TouchPhase.Began)
            {
                StartTocuh = Input.GetTouch(0).position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                EndTocuh = Input.GetTouch(0).position;

                if (StartTocuh.x < EndTocuh.x)
                {
                    GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower * 3;
                    GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear * 2;
                    actionState = ActionState.Touch;
                }
            }
        }
    }

    void HoldAction()
    {
        actionState = ActionState.Hold;
        float timeer = 0;

        if (!IsFocus || Input.touchCount == 0)
        {
            return;
        }
        Touch touch = Input.GetTouch(0);

        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                timeer += Time.deltaTime;
                if(timeer >= holdTIme)
                {
                    if(touch.phase == TouchPhase.Ended)
                    {
                        GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower * 5;
                        GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear * 4;
                        actionState = ActionState.Touch;
                    }
                }
            }
        }
    }

    void Fail()
    {
        actionState = ActionState.Touch;
    }

    private void OnApplicationFocus(bool focus)
    {
        IsFocus = focus;
    }
}
