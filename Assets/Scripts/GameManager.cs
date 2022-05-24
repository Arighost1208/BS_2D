using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI _goalCountPlayer;
    public TextMeshProUGUI _goalCountIA;
    public TextMeshProUGUI _goalTextPlayer;
    public TextMeshProUGUI _goalTextIA;
    public Transform _posDefaultBall;
    public Transform _posDefaultPlayer;
    public Transform _posDefaultIA;
    private Model _player;
    private IA _ia;
    private Ball _ball;
    private GameObject _colliderGoalLeft;
    private GameObject _colliderGoalRight;

    void Start()
    {
        _goalCountPlayer.text = "0";
        _goalCountIA.text = "0";
        _ball = GameObject.FindObjectOfType<Ball>();
        _player = GameObject.FindObjectOfType<Model>();
        _ia = GameObject.FindObjectOfType<IA>();
        _colliderGoalLeft = GameObject.FindGameObjectWithTag("GoalsLeft");
        _colliderGoalRight = GameObject.FindGameObjectWithTag("GoalsRight");
    }

    public void goalsColliders(bool _enabled)
    {
        _colliderGoalLeft.GetComponent<Collider>().enabled = _enabled;
        _colliderGoalRight.GetComponent<Collider>().enabled = _enabled;
    }
    public void goalPlayer()
    {
        addGoalCountPlayer();
        _goalTextPlayer.gameObject.SetActive(true);
        goalsColliders(false);
        Invoke("Respwan", 1.5f);
        _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Invoke("textGoalPlayerDesactive", 1.5f);
    }

    public void goalIA()
    {
        addGoalCountIA();
        //GameObject.FindObjectOfType<IA>().GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        _goalTextIA.gameObject.SetActive(true);
        goalsColliders(false);      
        Invoke("Respwan", 1.5f);
       _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Invoke("textGoalIADesactive", 1.5f);
    }

    public void textGoalIADesactive()
    {
        _goalTextIA.gameObject.SetActive(false);
    }

    public void textGoalPlayerDesactive()
    {
        _goalTextPlayer.gameObject.SetActive(false);
    }

    public void addGoalCountPlayer()
    {
        int _count = int.Parse(_goalCountPlayer.text) + 1;
        _goalCountPlayer.text = _count.ToString(); 
    }

    public void addGoalCountIA()
    {
        int _count = int.Parse(_goalCountIA.text) + 1;
        _goalCountIA.text = _count.ToString();
    }

    public void Respwan()
    {
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _player.transform.position = _posDefaultPlayer.position;
        _ia.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _ia.transform.position = _posDefaultIA.position; 
        _ball.transform.position = _posDefaultBall.position;
        _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        goalsColliders(true);

    }
}
