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
    public TextMeshProUGUI _WinText;
    public TextMeshProUGUI _LooseText;
    public TextMeshProUGUI _DeuceText;
    public GameObject _button;
    public Transform _posDefaultBall;
    public Transform _posDefaultPlayer;
    public Transform _posDefaultIA;
    private Model _player;
    private IA _ia;
    private Ball _ball;
    private GameObject _colliderGoalLeft;
    private GameObject _colliderGoalRight;
    private RigidbodyConstraints _rbc;
    private bool _isGoalIA;
    private int countGoalIA, countGoalPlayer;
    private Timer _timer;
    private void Awake()
    {
        Time.timeScale = 1f;
        _LooseText.gameObject.SetActive(false);
        _WinText.gameObject.SetActive(false);
        _DeuceText.gameObject.SetActive(false);
        _button.SetActive(false);
    }

    void Start()
    {
        _goalCountPlayer.text = "0";
        _goalCountIA.text = "0";
        _ball = GameObject.FindObjectOfType<Ball>();
        _player = GameObject.FindObjectOfType<Model>();
        _ia = GameObject.FindObjectOfType<IA>();
        _colliderGoalLeft = GameObject.FindGameObjectWithTag("GoalsLeft");
        _colliderGoalRight = GameObject.FindGameObjectWithTag("GoalsRight");
        _timer = GameObject.FindObjectOfType<Timer>();
    }

    public void goalsColliders(bool _enabled)
    {
        _colliderGoalLeft.GetComponent<Collider>().enabled = _enabled;
        _colliderGoalRight.GetComponent<Collider>().enabled = _enabled;
    }

    public void goalPlayer()
    {
        _timer.StopTime = true;
        addGoalCountPlayer();  
        //_goalTextPlayer.gameObject.SetActive(true);
        goalsColliders(false);
        _isGoalIA = false;
        Invoke("Respwan", 1.5f);
        _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        Invoke("textGoalPlayerDesactive", 1.5f);
    
    }

    public void goalIA()
    {
        _timer.StopTime = true;
        addGoalCountIA();
        
        //_goalTextIA.gameObject.SetActive(true);
        goalsColliders(false);
        _isGoalIA = true;
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
        countGoalPlayer = _count;
        _goalCountPlayer.text = _count.ToString(); 
    }

    public void addGoalCountIA()
    {
        int _count = int.Parse(_goalCountIA.text) + 1;
        countGoalIA = _count;
        _goalCountIA.text = _count.ToString();
        _ia.MustToReturnToDefaultPos = true;
    }

    public void Respwan()
    {
        _timer.StopTime = false;
        _player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _player.transform.position = _posDefaultPlayer.position;
        _ia.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _ia.transform.position = _posDefaultIA.position; 
        _ball.transform.position = _posDefaultBall.position;
        _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (!_isGoalIA)
            //_ball.GetComponent<Rigidbody>().AddForce(new Vector3(50, -30, 0));
            _ball.ObliqueMoveIA();
        else
        {
            _ia.MustToReturnToDefaultPos = false;
            _ball.ObliqueMovePlayer();
        }
            //_ball.GetComponent<Rigidbody>().AddForce(new Vector3(-50, -30, 0));
            

        goalsColliders(true);

    }

    public void CheckResultToFinishGame()
    {
        Time.timeScale = 0f;
        if (countGoalIA > countGoalPlayer)
        {
            _LooseText.gameObject.SetActive(true);
        }
        else if (countGoalPlayer > countGoalIA)
        {
            _WinText.gameObject.SetActive(true);
        }
        else if (countGoalIA == countGoalPlayer)
        {
            _DeuceText.gameObject.SetActive(true);
        }
        _button.SetActive(true);
    }
}
