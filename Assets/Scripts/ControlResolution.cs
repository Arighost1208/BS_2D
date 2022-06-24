using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlResolution : MonoBehaviour
{
    public float aspect;
    public float rounded;
    UnityEngine.UI.CanvasScaler cv;

    void Start()
    {
        cv = this.GetComponent<UnityEngine.UI.CanvasScaler>();
    }

    // Update is called once per frame
    void UpdateResolution()
    {
        //si 1920x1080 su division es 1.77777 eso es aspect
        aspect = Camera.main.aspect;
        rounded = (int)(aspect * 100.0f) / 100.0f;

        // 1920x1080
        if (rounded == 1.77f)
            Addratios(0.5f, 5.97f);

        // 1024x768
        else if (rounded == 1.33f)
            Addratios(0.5f, 8.28f);

        //2560x1600
        else if (rounded == 1.6f)
            Addratios(0.5f, 6.79f);

        // FreeAspect
        else if (rounded == 1.99f)
            Addratios(0.5f, 5.65f);

    }
    
    void Addratios(float m, float sz)
    {
        if (cv != null) cv.matchWidthOrHeight = m;
        Camera.main.orthographicSize = sz;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)) UpdateResolution();
    }
}
