using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NewFishingSystem : MonoBehaviour
{
    private bool IsFocus;
    public float ActionTime;
    public float WaitFishTime;
    public float time;
    public float ActionNum;
    private bool AcitonOnce;
    private bool WaitOnce;
    public GameObject TouchUI;
    public GameObject SwipeUI;

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
        Wait,
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
            GameManager.instance.UIOn = false;
            GameManager.instance.CurrentFishingTime = GameManager.instance.MaxFishingTime;
            actionState = ActionState.Idle;
            time = 0;
        }

        Fishing_Mobile();
    }

    void WaitFish()
    {
        Debug.Log("���");
        time += Time.deltaTime;
        if(WaitOnce == false)
        {
            WaitFishTime = Random.Range(3, 9);
            WaitOnce = true;
        }
        if(time >= WaitFishTime)
        {
            CatchFish();
            TouchUI.SetActive(true);
        }
    }

    void Fishing_Mobile()
    {

        if (actionState == ActionState.Idle)
        {
            ThrowRob();
            SwipeUI.SetActive(true);
            TouchUI.SetActive(false);
        }
        else if (actionState == ActionState.Touch)
        {
            SwipeUI.SetActive(false);
            TouchUI.SetActive(true);
            GameManager.instance.UIOn = true;
            Debug.Log("����");
            TouchAction();
            time += Time.deltaTime;
            if (time >= ActionTime)
            {
                actionState = ActionState.Swipe;
            }
        }
        else if (actionState == ActionState.Swipe)
        {
            SwipeUI.SetActive(true);
            TouchUI.SetActive(false);
            ActionLogic();
        }
        else if (actionState == ActionState.Wait)
        {
            WaitFish();
            SwipeUI.SetActive(false);
        }
    }

    void ActionLogic()
    {
        if(AcitonOnce == false)
        {
            ActionNum = Random.Range(1, 4);
            AcitonOnce = true;
        }


        if(ActionNum == 1)
        {
            SwipeLeftAction();
            Debug.Log("����1");

        }
        else if (ActionNum == 2)
        {
            SwipeRightAction();
            Debug.Log("����2");

        }
        else if (ActionNum == 3)
        {
            SwipeUpAction();
            Debug.Log("����3");

        }
    }

    void CatchFish()
    {
        Debug.Log("���!");
        if (!IsFocus || Input.touchCount == 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);
        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        {
            if (touch.phase == TouchPhase.Began)
            {
                actionState = ActionState.Touch;
                time = 0;
            }
        }
    }

    void TouchAction()
    {
        Debug.Log("��ġ!");
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
                GameManager.instance.CurrentFishingTime = GameManager.instance.MaxFishingTime;
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
                        Debug.Log("����");
                        actionState = ActionState.Wait;
                    }
                }
            }

        }

    }

    void SwipeLeftAction()
    {

        if(Input.touchCount > 0 || !IsFocus)
        {
            Debug.Log("���ʽ���");
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
                        AcitonOnce = false;
                        GameManager.instance.CurrentFishingTime = GameManager.instance.MaxFishingTime;
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
                Debug.Log("�����ʽ���");
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
                        AcitonOnce = false;
                        GameManager.instance.CurrentFishingTime = GameManager.instance.MaxFishingTime;
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
                Debug.Log("���ʽ���");
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
                        AcitonOnce = false;
                        GameManager.instance.CurrentFishingTime = GameManager.instance.MaxFishingTime;
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
