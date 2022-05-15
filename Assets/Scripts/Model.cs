using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Model : MonoBehaviour
{
    Controller _myControl;

    public Rigidbody _rb;
    public float _speed, _jumpForce;
    private Ball _ball;
    public event Action doAnimation = delegate { };
    public bool _isJumping, _canShoot, _grounded;
    // public Transform _checkGround;
    public LayerMask _groundLayer, _BallLayer;
    //public Animator _anim;
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
        //if (!_isJumping)
         if (_grounded)
        {

            // _rb.velocity = new Vector3(_rb.velocity.x,0f, _rb.velocity.z);
            //transform.position = Vector3.Lerp(transform.position, transform.position+transform.up*25,0.5f);
            _rb.AddForce(new Vector3(_rb.velocity.x,1* _jumpForce, _rb.velocity.z), ForceMode.Impulse);

            //_rb.velocity=new Vector3(_rb.velocity.x, 50f, _rb.velocity.z);
            // _rb.transform.position += _rb.transform.up * 50f * Time.deltaTime;          
            _isJumping = Physics.CheckSphere(transform.position, 0.25f, _BallLayer);
            if (_isJumping)
            {

            }
            return true;
        }
        return false;

    }
    public void doWalk(Vector3 _pos)
    {
        transform.position = _pos;
    }
    public void doFeetShoot()
    {
        if (_canShoot)
        {
            _rb.velocity = Vector3.zero;
            _ball.GetComponent<Rigidbody>().AddForce(new Vector3(-30, 35, 0));
        }
    }

    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Grass"))
    //    {
    //        _isJumping = true;
    //    }
    //}

    //public void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.layer == LayerMask.NameToLayer("Grass"))
    //    {
    //        _isJumping = false;
    //    }
    //}

    private void OnDrawGizmos()
    {
     //   _grounded = Physics.CheckSphere(transform.position, 0.25f, _groundLayer);
       // if (_grounded)
        Gizmos.DrawWireSphere(transform.position, 0.25f);
    }
}
