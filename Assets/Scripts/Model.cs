using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Model : MonoBehaviour
{
    Controller _myControl;

    private Rigidbody _rb;
    public float _speed, _jumpForce;
    private Ball _ball;
    public event Action doAnimation = delegate { };
    public bool _isJumping, _canShoot, _grounded;
    public LayerMask _groundLayer;
   
    void Start()
    {
        View _v = GetComponentInChildren<View>();
        _myControl = new Controller(this, _v);
       
        _rb = GetComponent<Rigidbody>();
        _ball = GameObject.FindObjectOfType<Ball>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _myControl.OnUpdate();
    }

    public bool doJump()
    {
        _grounded = Physics.CheckSphere(transform.position, 0.25f, _groundLayer);
  
         if (_grounded)
        {       
            _rb.velocity = new Vector3(_rb.velocity.x, 0, _rb.velocity.z);
            _rb.AddForce(new Vector3(_rb.velocity.x,1* _jumpForce, _rb.velocity.z), ForceMode.Impulse);
  
            return true;
        }
        return false;

    }
    public void doWalk(Vector3 _pos)
    {
        transform.position = _pos;
    }
    public void doFeetShoot(bool obliqueShoot)
    {
        if (_canShoot)
        {
            _rb.velocity = Vector3.zero;
            _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;

            if (obliqueShoot)
                //_ball.GetComponent<Rigidbody>().AddForce(new Vector3(40, 35, 0),ForceMode.Impulse);
                _ball.GetComponent<Rigidbody>().AddForce(new Vector3(1f ,0.9f, 0), ForceMode.Impulse);
            else
                _ball.GetComponent<Rigidbody>().AddForce(new Vector3(75f, _ball.GetComponent<Rigidbody>().velocity.y, 0));

               
        }
        _canShoot = false;
    }



    public void doHeadShoot()
    {
        _myControl.HeadShoot();
    }
   
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.25f);
    }
}
