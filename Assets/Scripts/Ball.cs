using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private IA ia;
    private GameManager _gm;
    void Start()
    {
        ia = GameObject.FindObjectOfType<IA>();
        _gm = GameObject.FindObjectOfType<GameManager>();
    }

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

       
        if (collision.gameObject.tag == "HeadIA")
        {
            ia._canHead = true;
            return;
        }
        //Gol del player
        if (collision.gameObject.layer == LayerMask.NameToLayer("GoalsRight"))
        {
            Vector3 vec = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = new Vector3(vec.x / 2, vec.y / 2, 0);
            _gm.goalPlayer();
            Debug.Log("GOOOOOL a la IA");
            return;
        }
        //Gol del CPU
        if (collision.gameObject.layer == LayerMask.NameToLayer("GoalsLeft"))
        {
            Vector3 vec = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = new Vector3(vec.x/2, vec.y/2,0);
            _gm.goalIA();
            Debug.Log("GOOOOOL al Player");
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

        if (collision.gameObject.tag == "HeadIA")
        {
            ia._canHead = false;
            return;
        }
        
    }

    
}
