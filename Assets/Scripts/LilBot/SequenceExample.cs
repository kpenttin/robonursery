﻿/*
    Example of sequencing multiple bot actions using a state machine
*/

using UnityEngine;
using System.Collections;

using LilBotNamespace;

namespace LilBotNamespace
{

public class SequenceExample : MonoBehaviour {
    
    private int state;
    
    public GameObject ball;
    
    public ArmControls armControls;
    public MovementControls movementControls;
    public PickupObject pickupRoutine;
    public bool loop;
    
    void Start ()
    {
        state = 0;
    }
	
	void FixedUpdate ()
    {
        switch (state)
        {
        case 0:
            armControls.SetStaticPosition("idle");
            if (movementControls.DriveTo(Vector3.zero, true) == 0)
            {
                state = 1;
            }
            break;
        case 1:
            if (pickupRoutine.Execute(ball) == 0)
            {
                state = 2;
            }
            break;
        case 2:
            if (movementControls.DriveTo(Vector3.zero, true) == 0)
            {
                pickupRoutine.Drop();
                state = 3;
            }
            break;
        case 3:
            armControls.SetStaticPosition("idle");
            if (loop)
            {
                state = 0;
            }
            break;
        }
    }
}

} // End namespace