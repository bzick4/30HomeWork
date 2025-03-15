using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private DoorOpen _doorOpen;

     private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                _panel.SetActive(true);
                PressKey();
            }
        }

     private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Ball"))
            {
                _panel.SetActive(false);
            }
        }

     private void PressKey()
        {
            if (Input.GetKey(KeyCode.E))
            {
                _doorOpen.OpenDoor();
                _doorOpen.GetComponent<Rigidbody>().isKinematic = false;
                Debug.Log("Press");
            }
        }
}
