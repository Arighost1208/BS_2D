using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netHeadIA : MonoBehaviour
{
    private IA _ia;
    public LayerMask _groundLayer;

    private void Start()
    {
        _ia = GameObject.FindObjectOfType<IA>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ball _ball = collision.gameObject.GetComponent<Ball>();
        if (_ball != null)
        {
            bool _grounded = Physics.CheckSphere(_ia.transform.position, 0.25f, _groundLayer);
            if (!_grounded)
            {
                GameObject.FindObjectOfType<IA>().doHeadShoot();
                _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                //_ball.GetComponent<Rigidbody>().AddForce(new Vector3(-75, 20, 0));
                _ball.GetComponent<Rigidbody>().AddForce(new Vector3(-1.5f, 0.2f, 0) , ForceMode.Impulse);
            }
           
        }
    }
}
