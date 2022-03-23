using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_Behaviour_Pose))]
public class ControllerManager : MonoBehaviour
{
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean teleportAction;
    public SteamVR_Action_Boolean showInstructionAction;

    private SteamVR_Input_Sources handType;
    private SteamVR_Behaviour_Pose controllerPose;
    private ControllerGrabScript grabber;
    private ControllerTeleportScript teleporter;
    private ControllerInstructionScript instruction;

    private GameObject objectInHand;

    // Start is called before the first frame update
    void Start()
    {
        controllerPose = GetComponent<SteamVR_Behaviour_Pose>();
        handType = controllerPose.inputSource;
        grabber = GetComponent<ControllerGrabScript>();
        teleporter = GetComponent<ControllerTeleportScript>();
        instruction = GetComponent<ControllerInstructionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabber)
        {
            if (grabAction.GetLastStateDown(handType))
            {
                if (grabber.IsCollidingObject())
                {
                    Debug.Log("Touching: " + grabber.GetCollidingObject().name);
                    objectInHand = grabber.GrabObject();
                }
            }
        }

        if (teleporter)
        {
            if (teleportAction.GetState(handType))
            {
                teleporter.TryLaser(controllerPose);
            }
            else
            {
                teleporter.DisableLaser();
            }

            if (teleportAction.GetStateUp(handType) && teleporter.ShouldTeleport())
            {
                teleporter.Teleport();
            }
        }

        if (instruction) 
        {
            if (showInstructionAction.GetState(handType))
            {
                instruction.ToggleInstruction();
            }
        }
    }
}
