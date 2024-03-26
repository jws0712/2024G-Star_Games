using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class NewFishingSystem : MonoBehaviour
{

    private float ActionTime;
    private float WaitFishTime;
    private float time;
    private float ActionNum;
    public float SwipeTime;

    private bool IsFocus;
    private bool AcitonOnce;
    private bool WaitOnce;

    [Header("UI")]

    public GameObject TouchUI;
    public GameObject SwipeUI_Up;
    public GameObject SwipeUI_Left;
    public GameObject SwipeUI_Right;
    public GameObject ThrowButton;

    private Vector2 StartPoint;
    private Vector2 EndPoint;

    public enum GameFlow
    {
        Idle,
        Wait,
        Swipe,
        Hold,
        Touch,
        result
    }

    public GameFlow flow;


    void Start()
    {
        ActionTime = 3;
        flow = GameFlow.Idle;
    }


    void Update()
    {
        SetGame();
        Fishing_Mobile();
    }

    

    void Fishing_Mobile()
    {

        if (flow == GameFlow.Idle)
        {
            ThrowButton.SetActive(true);
            SwipeUI_Up.SetActive(false);
            SwipeUI_Left.SetActive(false);
            SwipeUI_Right.SetActive(false);
            TouchUI.SetActive(false);
        }
        else if (flow == GameFlow.Touch)
        {
            GameManager.instance.UIOn = true;

            TouchAction();

            time += Time.deltaTime;
            if (time >= ActionTime)
            {
                flow = GameFlow.Swipe;
            }

            SwipeUI_Up.SetActive(false);
            SwipeUI_Left.SetActive(false);
            SwipeUI_Right.SetActive(false);
            TouchUI.SetActive(true);
        }
        else if (flow == GameFlow.Swipe)
        {
            ActionLogic();

            TouchUI.SetActive(false);
        }
        else if (flow == GameFlow.Wait)
        {
            WaitFish();

            SwipeUI_Up.SetActive(false);
            SwipeUI_Left.SetActive(false);
            SwipeUI_Right.SetActive(false);
            ThrowButton.SetActive(false);
        }
        else if (flow == GameFlow.result)
        {
            GameManager.instance.FishUIOn = true;
            SwipeUI_Up.SetActive(false);
            SwipeUI_Left.SetActive(false);
            SwipeUI_Right.SetActive(false);
            TouchUI.SetActive(false);
        }
    }

    public void GameResult()
    {
        flow = GameFlow.Idle;
        GameManager.instance.FishUIOn = false;
    }
    public void ThrowRob()
    {
        flow = GameFlow.Wait;
    }
    void WaitFish()
    {
        Debug.Log("���");
        time += Time.deltaTime;
        if (WaitOnce == false)
        {
            WaitFishTime = Random.Range(3, 9);
            WaitOnce = true;
        }
        if (time >= WaitFishTime)
        {
            CatchFish();
            TouchUI.SetActive(true);
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
                flow = GameFlow.Touch;
                time = 0;
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
                GameManager.instance.CurrentFishingTime = GameManager.instance.MaxFishingTime;
            }
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
            SwipeUI_Left.SetActive(true);

        }
        else if (ActionNum == 2)
        {
            SwipeRightAction();
            SwipeUI_Right.SetActive(true);


        }
        else if (ActionNum == 3)
        {
            SwipeUpAction();
            SwipeUI_Up.SetActive(true);

        }
    }

    void SwipeLeftAction()
    {

        if(Input.touchCount > 0 || !IsFocus)
        {
            Touch touch = Input.GetTouch(0);
            if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    SwipeTime = 0;
                    StartPoint = touch.position;
                }
                if(touch.phase == TouchPhase.Moved)
                {
                    SwipeTime += Time.deltaTime;
                }
                if (touch.phase == TouchPhase.Stationary)
                {
                    SwipeTime = 0;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    EndPoint = touch.position;
                    if (EndPoint.x < StartPoint.x && SwipeTime >= 0.09f)
                    {
                        GameManager.instance.CurrentFishingTime = GameManager.instance.MaxFishingTime;
                        GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower * 5;
                        GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear * 3;
                        flow = GameFlow.Touch;
                        time = 0;
                        SwipeTime = 0;
                        AcitonOnce = false;

                    }
                    else
                    {
                        SwipeTime = 0;
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
                if (touch.phase == TouchPhase.Began)
                {
                    SwipeTime = 0;
                    StartPoint = touch.position;
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    SwipeTime += Time.deltaTime;
                }
                if(touch.phase == TouchPhase.Stationary)
                {
                    SwipeTime = 0;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    EndPoint = touch.position;

                    if (EndPoint.x > StartPoint.x && SwipeTime >= 0.1005f)
                    {
                        GameManager.instance.CurrentFishingTime = GameManager.instance.MaxFishingTime;
                        GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower * 5;
                        GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear * 3;
                        flow = GameFlow.Touch;
                        time = 0;
                        SwipeTime = 0;
                        AcitonOnce = false;

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
                if (touch.phase == TouchPhase.Began)
                {
                    SwipeTime = 0;
                    StartPoint = touch.position;
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    SwipeTime += Time.deltaTime;
                }
                if (touch.phase == TouchPhase.Stationary)
                {
                    SwipeTime = 0;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    EndPoint = touch.position;

                    if (EndPoint.y > StartPoint.y && SwipeTime >= 0.1005f)
                    {
                        GameManager.instance.CurrentFishingTime = GameManager.instance.MaxFishingTime;
                        GameManager.instance.CurrentFishHp -= GameManager.instance.FishRobPower * 5;
                        GameManager.instance.CurrentFishRobHp -= GameManager.instance.FishRobWear * 3;
                        flow = GameFlow.Touch;
                        time = 0;
                        SwipeTime = 0;
                        AcitonOnce = false;

                    }
                }
            }
        }
    }

    void SetGame()
    {
        if (GameManager.instance.CurrentFishHp <= 0)
        {
            FishManager.instance.ChoiceFish();
            GameManager.instance.CurrentFishHp = GameManager.instance.MaxFishHp;
            GameManager.instance.CurrentFishingTime = GameManager.instance.MaxFishingTime;
            GameManager.instance.UIOn = false;
            flow = GameFlow.result;
            time = 0;
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        IsFocus = focus;
    }
}
