using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    private IA ia;
    private GameManager _gm;
    private Rigidbody _rb;
    private float _speedX = -12;
    public Transform _posPlayerDefault;
    public Transform _posIADefault;
    //[SerializeField] AudioClip audioGool;
    public UnityEvent eventGool;

    void Start()
    {
        ia = GameObject.FindObjectOfType<IA>();
        _gm = GameObject.FindObjectOfType<GameManager>();
        _rb = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        //Debug.Log("Velocidad horizontal :" + _rb.velocity.x);
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
            // SoundManager.PlayClip(audioGool);
            eventGool?.Invoke();
            _gm.goalPlayer();
            collision.gameObject.GetComponent<GoalAnimation>().PlayGoalAnimation();
            Debug.Log("GOOOOOL a la IA");
            return;
        }
        //Gol del CPU
        if (collision.gameObject.layer == LayerMask.NameToLayer("GoalsLeft"))
        {
            Vector3 vec = GetComponent<Rigidbody>().velocity;
            GetComponent<Rigidbody>().velocity = new Vector3(vec.x/2, vec.y/2,0);
            eventGool?.Invoke(); 
            //SoundManager.PlayClip(audioGool);
            _gm.goalIA();
            collision.gameObject.GetComponent<GoalAnimation>().PlayGoalAnimation();
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

    private float Gravity { get { return Physics.gravity.y; } }

    public void ObliqueMovePlayer()
    {
        float _totalTime = Mathf.Sqrt(Mathf.Abs(((_posPlayerDefault.position.y - transform.position.y) * (-2f)) / Gravity));

        float VIy = Gravity * (_totalTime);
        _rb.AddForce(new Vector3(-30f, VIy, _rb.velocity.z));
    }

    public void ObliqueMoveIA()
    {
        float _totalTime = Mathf.Sqrt(Mathf.Abs(((_posIADefault.position.y - transform.position.y) * (-2f)) / Gravity));

        float VIy = Gravity * (_totalTime);
        _rb.AddForce(new Vector3(30f, VIy, _rb.velocity.z));
    }

}
