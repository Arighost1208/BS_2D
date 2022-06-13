using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeGame : MonoBehaviour
{

    public Slider slider;
    public float sliderValue;
    //public Image imageMute;

    
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VolumeAudio", 0.5f);
        AudioListener.volume = slider.value;
        //Ismutetrue();
        
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("VolumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        //Ismutetrue();
    }

    //public void Ismutetrue()
    //{
    //    if(sliderValue == 0)
    //    {
    //        imageMute.enabled = true;
    //    }
    //    else
    //    {
    //        imageMute.enabled = false;
    //    }
    //}
}
