using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    private float _maxTime;
    private float _currentTime;
    public TextMeshProUGUI _currentTimeText;
    private GameManager _gameManager;
    void Start()
    {
        _maxTime = 10f;
        _currentTime = _maxTime;
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    
    void Update()
    {
        _currentTime -= Time.deltaTime;
        _currentTimeText.text = ((int)_currentTime).ToString();
        if (_currentTime <= 0f) 
        {
            _gameManager.CheckResultToFinishGame();
        }
    }
}
