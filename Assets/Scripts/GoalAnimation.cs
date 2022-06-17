using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalAnimation : MonoBehaviour
{
    public GameObject _goal;
    private Animator _anim;

    private void Start()
    {
        _anim = _goal.GetComponent<Animator>();
    }

    public void PlayGoalAnimation()
    {
        _anim.SetTrigger("Goal");
    }
}
