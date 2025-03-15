using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private float _open=300, _door;
    
    private HingeJoint hingeJoint;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
    }
    
    public void OpenDoor()
    {
        hingeJoint.useMotor = true;
        JointMotor door = hingeJoint.motor;
        door.force = _open;
        door.targetVelocity = _door;
        hingeJoint.motor = door;
    }
}
