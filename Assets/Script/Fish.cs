using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    float Num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Num = Random.Range(1, 4);
        switch (Num)
        {
            case 1:
                {
                    GameManager.instance.MaxFishHp = 100;
                    break;
                }
        }
    }
}
