using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller //: MonoBehaviour
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
    }
    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if(_model.doJump())
                _view.Jump();
        }

        else if (Input.GetKeyDown(KeyCode.P))
        {
            _view.FeetShoot();        
            _model.doFeetShoot(true);        
        }

        else if (Input.GetKeyDown(KeyCode.K))
        {
            _view.FeetShoot();
            _model.doFeetShoot(false);           
        }


        float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
        //_model.transform.position += new Vector3(Input.GetAxis("Horizontal") * 5 * Time.deltaTime,0,0);
        //float _pos = Input.GetAxisRaw("Horizontal");
            
        Vector3 _pos = Vector3.Lerp(_model.transform.position, new Vector3(_model.transform.position.x + Input.GetAxisRaw("Horizontal") * _model._speed * Time.deltaTime, _model.transform.position.y, _model.transform.position.z), interpolationRatio);

        _model.doWalk(_pos);
        _view.SetNewSpeed(Input.GetAxisRaw("Horizontal"));      
        elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)

    }

    public void HeadShoot()
    {
        _view.HeadShoot();
    }
}
