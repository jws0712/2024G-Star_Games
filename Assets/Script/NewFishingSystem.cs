using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NewFishingSystem : MonoBehaviour
{
    private bool IsFocus;
    public float ActionTime;
    public float time;
    public float ActionNum;
    private bool Once;

    private Vector2 StartPoint;
    private Vector2 EndPoint;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.CurrentFishHp <= 0)
        {
            GameManager.instance.CurrentFishHp = GameManager.instance.MaxFishHp;
        }

        Fishing_Mobile();
    }

    void Fishing_Mobile()
    {

        if (actionState == ActionState.Idle)
        {
            ThrowRob();

        }
        if (actionState == ActionState.Touch)
        {
            TouchAction();
            time += Time.deltaTime;
            if (time >= ActionTime)
            {
                actionState = ActionState.Swipe;
            }
        }
        if (actionState == ActionState.Swipe)
        {
            ActionLogic();
        }
    }

    void ActionLogic()
    {
        if(Once == false)
        {
            ActionNum = Random.Range(1, 4);
            Once = true;
        }


        if(ActionNum == 1)
        {
            SwipeLeftAction();
            Debug.Log("角青1");

        }
        else if (ActionNum == 2)
        {
            SwipeRightAction();
            Debug.Log("角青2");

        }
        else if (ActionNum == 3)
        {
            SwipeUpAction();
            Debug.Log("角青3");

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
    void ThrowRob()
    {
        if (!IsFocus)
        {
            return;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    StartPoint = touch.position;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    EndPoint = touch.position;

                    if (EndPoint.y > StartPoint.y)
                    {
                        Debug.Log("带咙");
                        actionState = ActionState.Touch;
                    }
                }
            }

        }

    }

    void SwipeLeftAction()
    {

        if(Input.touchCount > 0 || !IsFocus)
        {
            Debug.Log("哭率角青");
            Touch touch = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    StartPoint = touch.position;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    EndPoint = touch.position;
                    if (EndPoint.x < StartPoint.x)
                    {
                        GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower * 5;
                        GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear * 3;
                        actionState = ActionState.Touch;
                        time = 0;
                        Once = false;
                    }
                }
            }

        }

    }

    void SwipeRightAction()
    {

        if (Input.touchCount > 0 || !IsFocus)
        {
            Touch touch = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                Debug.Log("坷弗率角青");
                if (touch.phase == TouchPhase.Began)
                {
                    StartPoint = touch.position;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    EndPoint = touch.position;

                    if (EndPoint.x > StartPoint.x)
                    {
                        GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower * 5;
                        GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear * 3;
                        actionState = ActionState.Touch;
                        time = 0;
                        Once = false;
                    }
                }
            }

        }

    }

    void SwipeUpAction()
    {

        if (Input.touchCount > 0 || !IsFocus)
        {
            Touch touch = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                Debug.Log("困率角青");
                if (touch.phase == TouchPhase.Began)
                {
                    StartPoint = touch.position;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    EndPoint = touch.position;

                    if (EndPoint.y > StartPoint.y)
                    {
                        GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower * 5;
                        GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear * 3;
                        actionState = ActionState.Touch;
                        time = 0;
                        Once = false;
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
