using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netHeadPlayer : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        Ball _ball = collision.gameObject.GetComponent<Ball>();
        if (_ball != null)
        {
            GameObject.FindObjectOfType<Model>().doHeadShoot();
            _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _ball.GetComponent<Rigidbody>().AddForce(new Vector3(75, 20, 0));
        }
    }
}
