using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Model _model;
    View _view;
    public int interpolationFramesCount = 10;
    int elapsedFrames = 0;

    private void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked;
    }
    public Controller(Model _m, View _v)
    {
        _model = _m;

        _view = _v;
        /*Agrego al Action de mi model la/s funcion/es que quiero que se ejecuten con el Action*/
        //_model.doAnimation += _v.DeathMaterial;


    }
    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(_model.doJump())
                _view.Jump();

        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            _model.doFeetShoot();
            _view.FeetShoot();

        }
            float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        //_model.transform.position += new Vector3(Input.GetAxis("Horizontal") * 5 * Time.deltaTime,0,0);
        //float _pos = Input.GetAxisRaw("Horizontal");
            
        Vector3 _pos = Vector3.Lerp(_model.transform.position, new Vector3(_model.transform.position.x + Input.GetAxisRaw("Horizontal") * 5 * Time.deltaTime, _model.transform.position.y, _model.transform.position.z), interpolationRatio);

        _model.doWalk(_pos);
        _view.SetNewSpeed(Input.GetAxisRaw("Horizontal"));
        // _view.Walk(Input.GetAxis("Horizontal"));
        //if (_pos != 0f)
        //{
        //    //_view.Idle(false);

        // }

        //else
        //{
        //    _view.Idle(true);
        //}

        //_view.Walk(_model.transform.position.x);

        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)

    }
}
