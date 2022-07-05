using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ball _ball = collision.gameObject.GetComponent<Ball>();

        if (_ball != null)
        { 
            if (_ball.transform.position.x < 0)
                _ball.GetComponent<Rigidbody>().AddForce(new Vector3(-0.15f, 0f, 0), ForceMode.Impulse);
            else
                _ball.GetComponent<Rigidbody>().AddForce(new Vector3(0.15f, 0f, 0), ForceMode.Impulse);
        }
    }
}
