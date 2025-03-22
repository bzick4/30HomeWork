using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BallWalk : MonoBehaviour
{
    private Rigidbody ball;
    private Animator animator;
    private float vert, horiz;
    private Vector3 moveDirection;
    [SerializeField] private Transform cameraTransform;
    [SerializeField, Range(0,15)] private float _speed, _maxSpeed;
    [SerializeField] private PauseScript _pauseScript;
    [SerializeField] private GameObject _panelWin, _panelLose, _panelChek;
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private GameObject _particleLose, _particleWin;
    

    private void Start()
    {
        ball = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        _pauseScript.PausedGame();
    }
    
    private void Update()
    {
        // vert = Input.GetAxis("Vertical");
        // horiz = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        Walk();
        LimitSpeed();
    }

    public void Walk()
    {

        Vector3 inputDirection = new Vector3(horiz, 0, vert);
        inputDirection.Normalize();

        moveDirection = transform.TransformDirection(inputDirection);

        Vector3 targetVelocity = moveDirection * _speed;
        targetVelocity.y = ball.velocity.y;

        Vector3 velocityChange = targetVelocity - ball.velocity;

        ball.AddForce(velocityChange, ForceMode.VelocityChange);
        animator.SetFloat("Velocity", ball.velocity.magnitude);
        
    }

    public void LimitSpeed()
    {
        if (ball.velocity.magnitude > _maxSpeed)
        {
            ball.velocity = ball.velocity.normalized * _maxSpeed;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RestartScene"))
        {
            Invoke("ActivePanelLose",1f);
            _particleLose.SetActive(true);
            Invoke("Pause",1f);
        }

        if (other.CompareTag("Finish"))
        {
            if (_coinManager.totalCoin >= 6)
            {
                Invoke("ActivePanelWin",1f);
                _particleWin.SetActive(true);
                Invoke("Pause",1f);
            }
            else
            {
                _panelChek.SetActive(true);
                Pause();
            }
        }
    }

    private void Pause()
    {
        _pauseScript.PausedGame();
    }

    private void ActivePanelWin()
    {
        _panelWin.SetActive(true);
    }

    private void ActivePanelLose()
    {
        _panelLose.SetActive(true);
    }
}
