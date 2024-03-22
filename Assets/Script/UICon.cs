using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICon : MonoBehaviour
{
    public Slider HPSlider_R;
    public Slider HPSlider_R_E;

    public Slider APSlider;
    public Slider APSlider_E;

    public Slider TimeBar;
    public Slider TimeBar_E;

    public float LerpSpeed = 0.5f;

    public GameObject[] Sliders;

    // Start is called before the first frame update
    void Start()
    {

        if (GameManager.instance.UIOn == false)
        {
            for (int i = 0; i < Sliders.Length; i++)
            {
                Sliders[i].gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.UIOn == false)
        {
            for (int i = 0; i < Sliders.Length; i++)
            {
                Sliders[i].gameObject.SetActive(false);
            }
        }
        else if (GameManager.instance.UIOn == true)
        {
            for (int i = 0; i < Sliders.Length; i++)
            {
                Sliders[i].gameObject.SetActive(true);
            }
        }

        HPSlider_Value();
        APSlider_Value();
        TimeSlider_Value();
    }

    public void HPSlider_Value()
    {

        HPSlider_R.value = GameManager.instance.CurrentFishHp / GameManager.instance.MaxFishHp;
        HPSlider_R_E.value = Mathf.Lerp(HPSlider_R_E.value, GameManager.instance.CurrentFishHp / GameManager.instance.MaxFishHp, LerpSpeed * Time.deltaTime);

    }
    void APSlider_Value()
    {
        APSlider.value = GameManager.instance.CurrentFishRobHp / GameManager.instance.MaxFishRobHp;
        APSlider_E.value = Mathf.Lerp(APSlider_E.value,GameManager.instance.CurrentFishRobHp / GameManager.instance.MaxFishRobHp, LerpSpeed * Time.deltaTime);

    }

    void TimeSlider_Value()
    {
        TimeBar.value = GameManager.instance.CurrentFishingTime / GameManager.instance.MaxFishingTime;
        TimeBar_E.value = Mathf.Lerp(TimeBar_E.value, GameManager.instance.CurrentFishingTime / GameManager.instance.MaxFishingTime, LerpSpeed * Time.deltaTime);
    }
}
