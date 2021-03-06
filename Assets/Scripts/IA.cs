using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public float _rangerDefense, _speed ;
    public int _jumpForce;
    public Transform _defense,_checkGrounded;
    public bool _canShootAI, _canHead, _grounded;
    public LayerMask _groundLayer;

    private Ball _ball;
    private Rigidbody _rbIA;  
    private Model _player;
    private  Animator _anim;
    private Vector3 _posDefault;
    private bool _mustToReturnToDefaultPos;
    private bool walkback;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _ball = GameObject.FindObjectOfType<Ball>();
        _rbIA = GetComponent<Rigidbody>();
        _player = GameObject.FindObjectOfType<Model>();
        _posDefault = transform.position;
        MustToReturnToDefaultPos = false;  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (MustToReturnToDefaultPos)
        {    
            backToDefaultPosition();
        }
        else
        {   
            Move();

            _grounded = Physics.CheckSphere(_checkGrounded.position, 0.25f, _groundLayer);
            if (_canShootAI)
            {
                Shoot();
                _canShootAI = false;
            }

            if (_canHead && _grounded)
            {
                Jump();
            }
        }
    }

    public bool MustToReturnToDefaultPos
    {
        get => _mustToReturnToDefaultPos;
        set { _mustToReturnToDefaultPos = value;  }
    }
    public void Move()
    {
        float _currentSpeed = 0f;
        //float _distance = Vector3.Distance(transform.position, _player.transform.position);
        //if (_distance <= 3f)
        //{
        //    walkback = true;
        //    StartCoroutine(BackToDefaultPosition());
          
        //}

        //else
        //{
            if (!walkback)
            {
                if (Mathf.Abs(_ball.transform.position.x - transform.position.x) < _rangerDefense)
                {
                    if (_ball.transform.position.x > transform.position.x)
                    {
                        _currentSpeed = Time.deltaTime * _speed;
                        _rbIA.velocity = new Vector3(_currentSpeed, _rbIA.velocity.y, _rbIA.velocity.z);
                    }

                    else
                    {
                        _currentSpeed = -Time.deltaTime * _speed;
                        _rbIA.velocity = new Vector3(_currentSpeed, _rbIA.velocity.y, _rbIA.velocity.z);
                    }
                }
                //    //Si la distancia entre la pelota y la IA es menor al rango de Defensa
                //    if (Mathf.Abs(_ball.transform.position.x - transform.position.x)< _rangerDefense)
                //     {
                //    //evaluo si la pelota esta por detras de la IA
                //        if (_ball.transform.position.x > transform.position.x)
                //        {
                //            if (Mathf.Abs(_player.transform.position.x - transform.position.x) <= 2.5f)
                //            {
                //            _currentSpeed = Time.deltaTime * _speed;
                //            _rbIA.velocity = new Vector3(_currentSpeed, _rbIA.velocity.y, _rbIA.velocity.z);
                //            }

                //            else
                //            {
                //            _currentSpeed = -Time.deltaTime * _speed;
                //            _rbIA.velocity = new Vector3(_currentSpeed, _rbIA.velocity.y, _rbIA.velocity.z);

                //            }
                //        }


                //    //Si la pelota  esta por delante de la IA
                //        else
                //        {
                //            if (Mathf.Abs(_player.transform.position.x - transform.position.x) <= 2.5f)
                //            {
                //            _currentSpeed = Time.deltaTime * _speed;
                //            _rbIA.velocity = new Vector3(_currentSpeed, _rbIA.velocity.y, _rbIA.velocity.z);
                //            }

                //            else
                //            {
                //            _currentSpeed = -Time.deltaTime * _speed;
                //            _rbIA.velocity = new Vector3(_currentSpeed, _rbIA.velocity.y, _rbIA.velocity.z);

                //            }
                //        _currentSpeed = -Time.deltaTime * _speed;
                //        _rbIA.velocity = new Vector3(_currentSpeed, _rbIA.velocity.y, _rbIA.velocity.z);
                //        }
                //    }
                ////Si la distancia entre la pelota y la IA es mayor al rango de Defensa
                //else
                //{
                //    //Chequeo si la IA esta por delante de la zona Defensiva
                //    if (transform.position.x > _defense.position.x)//cambiar signo
                //    {
                //        _currentSpeed = -Time.deltaTime * _speed;
                //        _rbIA.velocity = new Vector3(_currentSpeed, _rbIA.velocity.y, _rbIA.velocity.z);
                //    }

                //    //Si la IA esta por detras de la zona Defensiva
                //    else
                //    {
                //        _currentSpeed = 0;
                //        _rbIA.velocity = new Vector3(_currentSpeed, _rbIA.velocity.y, _rbIA.velocity.z);
                //    }
                //}

                _anim.SetFloat("_speedX", _currentSpeed);
            //}           
        }
        
    }

    public void Shoot()
    {
        int _option = Random.Range(1, 3);

        if (_ball.transform.position.x > transform.position.x)
        {
            _rbIA.velocity = Vector3.zero;
            _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (_option == 1)
                _ball.GetComponent<Rigidbody>().AddForce(new Vector3(-1f, 0.9f, 0), ForceMode.Impulse);
            else
                _ball.GetComponent<Rigidbody>().AddForce(new Vector3(75f, _ball.GetComponent<Rigidbody>().velocity.y, 0));

        }
        else 
        {
            _rbIA.velocity = Vector3.zero;
            _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (_option == 1)
                //_ball.GetComponent<Rigidbody>().AddForce(new Vector3(-35, 45, 0));
                _ball.GetComponent<Rigidbody>().AddForce(new Vector3(-1f, 0.7f, 0), ForceMode.Impulse);
            else
                _ball.GetComponent<Rigidbody>().AddForce(new Vector3(-75f, _ball.GetComponent<Rigidbody>().velocity.y, 0));
        }

        _anim.SetTrigger("_shoot");
    }


    public void Jump()
    {
        _anim.SetTrigger("_jump");
        _rbIA.velocity = new Vector3(_rbIA.velocity.x,0, _rbIA.velocity.z);
        _rbIA.AddForce(new Vector3(_rbIA.velocity.x, _jumpForce, _rbIA.velocity.z), ForceMode.Impulse);
    }

    public void doHeadShoot()
    {
        _anim.SetTrigger("_headAttack");
    }

    private void OnDrawGizmos()
    {
       
        Gizmos.DrawWireSphere(_checkGrounded.position, 0.25f);
    }

    public void backToDefaultPosition()
    {
        transform.position = Vector3.Lerp(transform.position, _posDefault, Time.deltaTime * 0.5f);
    }

    //IEnumerator BackToDefaultPosition()
    //{
    //    float time = 3f;
    //    while (time >= 0f)
    //    {

    //        transform.position = Vector3.Lerp(transform.position, _posDefault, Time.deltaTime * 0.05f);
    //        time -= Time.deltaTime;
    //    }
    //    walkback = false;
    //    yield return null;
    //}
}
