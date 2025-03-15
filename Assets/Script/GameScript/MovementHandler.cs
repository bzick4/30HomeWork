using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHandler : MonoBehaviour
{

    [SerializeField] private MoveBall _moveBall;
    [SerializeField] private float _BallSpeed;
   void Start()
    {
    
      if(_moveBall== null)
      Debug.Log("Input Ne naiden");  
    }

    private void MoveBall()
    {
        if(_moveBall.IsThereTouch())
        {
        Vector2 _currDelPos = _moveBall.GetTouchDelta();
        _currDelPos = _currDelPos * _BallSpeed;
        Vector3 _newGravityVector = new Vector3(_currDelPos.x, Physics.gravity.y, _currDelPos.y);
        Physics.gravity = _newGravityVector;
        }
 
    }

    void Update()
    {
        MoveBall();
    }
}
