using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netHeadPlayer : MonoBehaviour
{
    private Model _model;
    public LayerMask _groundLayer;
    private void Start()
    {
        _model = GameObject.FindObjectOfType<Model>();
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Ball _ball = collision.gameObject.GetComponent<Ball>();
    //    if (_ball != null)
    //    {
    //        GameObject.FindObjectOfType<Model>().doHeadShoot();
    //        _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
    //        _ball.GetComponent<Rigidbody>().AddForce(new Vector3(30, 1, 0));
    //    }
    //}

    private void OnTriggerEnter(Collider collision)
    {
        Ball _ball = collision.gameObject.GetComponent<Ball>();
        if (_ball != null)
        {

            bool _grounded = Physics.CheckSphere(_model.transform.position, 0.25f, _groundLayer);
           
            //If player isnt stay in the ground , he can shoot with head

            if (!_grounded)
            {
                GameObject.FindObjectOfType<Model>().doHeadShoot();
                _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
                _ball.GetComponent<Rigidbody>().AddForce(new Vector3(75, 20, 0));
            }
            
        }
    }
}
