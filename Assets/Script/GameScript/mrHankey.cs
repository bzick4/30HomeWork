using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mrHankey : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
   

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _panel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            _panel.SetActive(false);
        }
    }

   
}
