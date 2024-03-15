using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishingSystem : MonoBehaviour
{
    [SerializeField] private Button FishingBt;
    public float FishHP;
    public float FishRobPower;

    // Start is called before the first frame update
    void Start()
    {
        FishingBt.onClick.AddListener(Fishing);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fishing()
    {
        FishHP -= FishRobPower;
    }
}
