using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingSystem : MonoBehaviour
{
    [SerializeField] private Button FishingBt;
    [SerializeField] private Text FishingBtText;
    public float MaxFishHp;
    public float CurrentFishHp;
    public float FishRobHp;
    public float FishRobPower;
    public bool Ishrowing;

    // Start is called before the first frame update
    void Start()
    {
        Ishrowing = false;
        CurrentFishHp = MaxFishHp;
        FishingBt.onClick.AddListener(Fishing);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Fishing()
    {
        if(Ishrowing)
        {
            CurrentFishHp -= FishRobPower;
            if (CurrentFishHp == 0)
            {
                FishingBtText.text = "������";
                CurrentFishHp = MaxFishHp;
                Ishrowing = false;
            }
        }
        else
        {
            FishingBtText.text = "���";
            Ishrowing = true;
        }

    }
}
