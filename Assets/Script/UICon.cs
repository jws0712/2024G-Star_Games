using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICon : MonoBehaviour
{
    public Slider HPSlider_L;
    public Slider HPSlider_L_E;

    public Slider HPSlider_R;
    public Slider HPSlider_R_E;

    public Slider APSlider;
    public Slider APSlider_E;

    public float LerpSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HPSlider_Value();
        APSlider_Value();
    }

    public void HPSlider_Value()
    {

        HPSlider_L.value = GameManager.instance.CurrentFishHp / GameManager.instance.MaxFishHp;

        HPSlider_L_E.value = Mathf.Lerp(HPSlider_L_E.value, GameManager.instance.CurrentFishHp / GameManager.instance.MaxFishHp, LerpSpeed * Time.deltaTime);

        HPSlider_R.value = GameManager.instance.CurrentFishHp / GameManager.instance.MaxFishHp;

        HPSlider_R_E.value = Mathf.Lerp(HPSlider_R_E.value, GameManager.instance.CurrentFishHp / GameManager.instance.MaxFishHp, LerpSpeed * Time.deltaTime);

    }
    void APSlider_Value()
    {
        APSlider.value = GameManager.instance.CurrentFishRobHp / GameManager.instance.MaxFishRobHp;
        APSlider_E.value = Mathf.Lerp(APSlider_E.value,GameManager.instance.CurrentFishRobHp / GameManager.instance.MaxFishRobHp, LerpSpeed * Time.deltaTime);

    }
}
