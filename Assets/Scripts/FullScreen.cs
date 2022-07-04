using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;

    public TMP_Dropdown ResolutionDropDown;
    Resolution[] resolutions;

    void Start()
    {

        if (Screen.fullScreen)
            toggle.isOn = true;

        else
            toggle.isOn = false;

        SeeResolutions();
    }

    public void ActivateFullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

   public void SeeResolutions()
    {
        resolutions = Screen.resolutions;
        ResolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolution = 0;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                currentResolution = i;

        }
        ResolutionDropDown.AddOptions(options);
        ResolutionDropDown.value = currentResolution;
        ResolutionDropDown.RefreshShownValue();

        ResolutionDropDown.value = PlayerPrefs.GetInt("numberResolution", 0);
    }

    public void ChangeResolution(int indexResolution)
    {
        PlayerPrefs.SetInt("numberResolution", ResolutionDropDown.value);

        Resolution resolucion = resolutions[indexResolution];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
}
