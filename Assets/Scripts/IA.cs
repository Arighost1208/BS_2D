using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public float rangerDenfece,_speed;
    public Transform denfece;
    Ball _ball;
    Rigidbody _rbIA;
    public bool _canShootAI,_canHead;
    Model _player;

    void Start()
    {
        _ball = GameObject.FindObjectOfType<Ball>();
        _rbIA = GetComponent<Rigidbody>();
        _player = GameObject.FindObjectOfType<Model>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (_canShootAI)
        {
            Shoot();
        }

        ////if (_canHead)
        ////{

        //}
    }

    public void Move()
    {
        if (Mathf.Abs(_ball.transform.position.x - transform.position.x)< rangerDenfece)
        {
            if (_ball.transform.position.x > transform.position.x)
            {
                if (Mathf.Abs(_player.transform.position.x - transform.position.x) >= 2.5f)
                    _rbIA.velocity = new Vector3(Time.deltaTime * _speed, _rbIA.velocity.y, _rbIA.velocity.z);
                else
                    _rbIA.velocity = new Vector3(-Time.deltaTime * _speed, _rbIA.velocity.y, _rbIA.velocity.z);
            }

            else
            {
                _rbIA.velocity = new Vector3(-Time.deltaTime * _speed, _rbIA.velocity.y, _rbIA.velocity.z);
            }
        }

        else
        {
            if (transform.position.x > denfece.position.x)
            {
                _rbIA.velocity = new Vector3(-Time.deltaTime * _speed, _rbIA.velocity.y, _rbIA.velocity.z);
            }
            
            else
            {
                _rbIA.velocity = new Vector3(0, _rbIA.velocity.y, _rbIA.velocity.z);
            }
        }
    }

    public void Shoot()
    {
        //_ball.GetComponent<Rigidbody>().velocity = new Vector3(0f, _ball.GetComponent<Rigidbody>().velocity.y,0);
        if (_ball.transform.position.x > transform.position.x)

            _ball.GetComponent<Rigidbody>().AddForce(new Vector3(20, 30, 0));

        else
            _ball.GetComponent<Rigidbody>().AddForce(new Vector3(20, 30, 0));

    }


    public void Jump()
    {
        _rbIA.velocity = new Vector3(-Time.deltaTime * _speed, 150f, _rbIA.velocity.z);
    }
}
