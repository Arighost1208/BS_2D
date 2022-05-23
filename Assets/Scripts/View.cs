using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class View : MonoBehaviour
{
    public Image lifeBar;

    Material _myMat;

    public Animator _anim;
    //public ParticleSystem part;

    public float _currSpeed;
    public float _lerpValue;
    public float _lerpSpeed = 1;

    void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
       // _myMat = GetComponent<Renderer>().material;
    }

    public void UpdateHudLife(float value)
    {
        lifeBar.fillAmount = value;
    }

    //public void HurtAnimation(float v)
    //{
    //    //_anim.SetTrigger("Hurt");
    //}

    public void DeathMaterial()
    {
        _myMat.color = Color.red;
    }

    public void Walk(float speed)
    {
        _anim.SetFloat("_speedX", speed);
    }

    public void Idle(bool idleCondition)
    {
        _anim.SetBool("_idle", idleCondition);
    }

    public void Jump ()
    {
        _anim.SetTrigger("_jump");
    }

    public void HeadShoot()
    {
        _anim.SetTrigger("_headAttack");
    }

    public void SetNewSpeed(float xAxis)
    {
        if (xAxis != _currSpeed)
        {
            _lerpValue = 0;
        }

        StartCoroutine(LerpAnimation(xAxis));
    }

    IEnumerator LerpAnimation(float xAxis)
    {
        while (_lerpValue < 1)
        {
            var animVal = Mathf.Lerp(_currSpeed, xAxis, _lerpValue);
            _anim.SetFloat("_speedX", animVal);
            _lerpValue += Time.deltaTime * _lerpSpeed;
            yield return new WaitForEndOfFrame();
        }

        _anim.SetFloat("_speedX", Mathf.Lerp(_currSpeed, xAxis, 1));
        _currSpeed = xAxis;
    }

    public void FeetShoot()
    {
        _anim.SetTrigger("_shoot");
    }

}
