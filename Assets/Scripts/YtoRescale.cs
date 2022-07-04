using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YtoRescale : MonoBehaviour
{

    public Animator animY;

    void Start()
    {
        Invoke("Vanish", 1);
    }
    
   public void Vanish()
    {
        animY.Play("YtoRescale");

    }
}
