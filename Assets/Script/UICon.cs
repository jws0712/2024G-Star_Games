using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICon : MonoBehaviour
{
    public Slider HPSlider_L;
    public Slider HPSlider_R;
    public Slider APSlider;

    // Start is called before the first frame update
    void Start()
    {
        HPSlider_L.onValueChanged.AddListener(delegate { HPSlider_Value(); });    
        HPSlider_R.onValueChanged.AddListener(delegate { HPSlider_Value(); });
        APSlider.onValueChanged.AddListener(delegate { APSlider_Value(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HPSlider_Value()
    {
        HPSlider_L.value = GameManager.instance.CurrentFishHp / GameManager.instance.MaxFishHp;
        HPSlider_R.value = GameManager.instance.CurrentFishHp / GameManager.instance.MaxFishHp;
    }
    void APSlider_Value()
    {
        APSlider.value = GameManager.instance.CurrentFishRobHp / GameManager.instance.MaxFishRobHp;
    }
}
