using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Manager : MonoBehaviour
{
    [SerializeField] private PauseScript _pauseScript;
    [SerializeField] private GameObject _panelWin;
    [SerializeField] private GameObject _particleWin;
    
    private void Start()
    {
        _pauseScript.PausedGame();
    }

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("Finish"))
        {
            Invoke("ActivePanelWin",1f);
            _particleWin.SetActive(true);
            Invoke("Pause",1f);
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
}
