using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brightness : MonoBehaviour
{
    public Slider slider;
    public Image PanelBrightness;
    public float sliderValue;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Brightness", 0.5f);
        PanelBrightness.color = new Color ( PanelBrightness.color.r , PanelBrightness.color.g , PanelBrightness.color.b , slider.value );
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("Brightness", sliderValue);
        PanelBrightness.color = new Color ( PanelBrightness.color.r , PanelBrightness.color.g , PanelBrightness.color.b , slider.value );
    } 

  
}
