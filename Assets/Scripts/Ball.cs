using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Model _player = collision.gameObject.GetComponentInChildren<Model>();

    //    if (_player != null)
    //    {
    //        _player._canShoot = true;
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    Model _player = collision.gameObject.GetComponentInChildren<Model>();

    //    if (_player != null)
    //    {
    //        _player._canShoot = false;
    //    }
    //}
    private void OnTriggerEnter(Collider collision)
    {
        Model _player = collision.gameObject.GetComponentInChildren<Model>();

        if (_player != null)
        {
            _player._canShoot = true;
            return;
        }

        IA _ia = collision.gameObject.GetComponentInChildren<IA>();

        if (_ia != null)
        {
            _ia._canShootAI = true;
            return;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        Model _player = collision.gameObject.GetComponentInChildren<Model>();

        if (_player != null)
        {
            _player._canShoot = false;
            return;
        }

        IA _ia = collision.gameObject.GetComponentInChildren<IA>();

        if (_ia != null)
        {
            _ia._canShootAI = false;
            return;
        }
    }

    
}
