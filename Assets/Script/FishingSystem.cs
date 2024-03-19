using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FishingSystem : MonoBehaviour
{
    public bool OnDisplay;
    private bool IsFocus;
    public float ActionTime;
    public float holdTIme;
    private int ActionNum;
    public float time = 0;
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
        OnDisplay = false;
        actionState = ActionState.Idle;
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
            Debug.Log("¾ÆÀÌµé");
        }
        if(actionState == ActionState.Touch)
        {
            SwipeLeftAction();
            //TouchAction();
            //time += Time.deltaTime;
            //if(time >= ActionTime)
            //{
            //    SwipeLeftAction();
            //}
        }
    }

    void ActionLogic()
    {
        SwipeLeftAction();
        //if(ChoiceAction == false)
        //{
        //    ActionNum = Random.Range(1, 4);
        //    ChoiceAction = true;
        //}

        //switch (ActionNum)
        //{
        //    case 1:
        //        {
        //            SwipeLeftAction();
        //            Debug.Log("¿Þ½º");

        //            break;
        //        }
        //    case 2:
        //        {
        //            SwipeRightAction();
        //            Debug.Log("¿À½º");

        //            break;
        //        }
        //    case 3:
        //        {
        //            SwipeUpAction();
        //            Debug.Log("¾÷½º");

        //            break;
        //        }
        //    case 4:
        //        {
        //            HoldAction();
        //            Debug.Log("È¦µå");

        //            break;
        //        }
        //}
    }

    void ThrowRob()
    {
        Debug.Log("´øÁö±â");
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
                OnDisplay = true;
                StartTocuh = Input.GetTouch(0).position;
                Debug.Log(StartTocuh);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                
                EndTocuh = Input.GetTouch(0).position;
                Debug.Log(EndTocuh);

                if (StartTocuh.y < EndTocuh.y && OnDisplay)
                {
                    actionState = ActionState.Touch;
                    OnDisplay = false;
                    Debug.Log("´øÁü");
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


    void SwipeLeftAction()
    {
        Vector2 StartTocuh = Vector2.zero;
        Vector2 EndTocuh = Vector2.zero;

        if (!IsFocus || Input.touchCount == 0)
        {
            Debug.Log("ÀÌ°Å");
            return;
        }
        Touch touch = Input.GetTouch(0);

        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            if (touch.phase == TouchPhase.Began)
            {
                OnDisplay = true;
                StartTocuh = Input.GetTouch(0).position;
                Debug.Log(StartTocuh);
            }

            if (touch.phase == TouchPhase.Ended)
            {

                EndTocuh = Input.GetTouch(0).position;
                Debug.Log(EndTocuh);


                if (StartTocuh.x > EndTocuh.x)
                {
                    Debug.Log("¿Þ½º");
                    GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower * 3;
                    GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear * 2;
                }
            }
        }
    }

    //void HoldAction()
    //{
    //    actionState = ActionState.Hold;
    //    float timeer = 0;

    //    if (!IsFocus || Input.touchCount == 0)
    //    {
    //        return;
    //    }
    //    Touch touch = Input.GetTouch(0);

    //    if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
    //    {
    //        if(touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
    //        {
    //            timeer += Time.deltaTime;
    //            if(timeer >= holdTIme)
    //            {
    //                if(touch.phase == TouchPhase.Ended)
    //                {
    //                    actionState = ActionState.Touch;
    //                    GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower * 5;
    //                    GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear * 4;

    //                }
    //            }
    //        }
    //    }
    //}

    void Fail()
    {
        actionState = ActionState.Touch;
    }

    private void OnApplicationFocus(bool focus)
    {
        IsFocus = focus;
    }
}
