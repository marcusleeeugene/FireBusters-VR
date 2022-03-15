using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_Behaviour_Pose))]
public class ControllerManager : MonoBehaviour
{
    public SteamVR_Action_Boolean grabAction;
    public SteamVR_Action_Boolean shootAction;
    public SteamVR_Action_Boolean teleportAction;

    private SteamVR_Input_Sources handType;
    private SteamVR_Behaviour_Pose controllerPose;
    private ControllerGrabScript grabber;
    private ControllerShootScript shooter;
    private ControllerTeleportScript teleporter;

    private GameObject objectInHand;

    // Start is called before the first frame update
    void Start()
    {
        controllerPose = GetComponent<SteamVR_Behaviour_Pose>();
        handType = controllerPose.inputSource;
        grabber = GetComponent<ControllerGrabScript>();
        shooter = GetComponent<ControllerShootScript>();
        teleporter = GetComponent<ControllerTeleportScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabber)
        {
            if (grabAction.GetLastStateDown(handType))
            {
                Debug.Log("Grabbing!");
                if (grabber.IsCollidingObject())
                {
                    Debug.Log("Touching: " + grabber.GetCollidingObject().name);
                    objectInHand = grabber.GrabObject();
                }
            }

            if (shooter)
            {
                if (shootAction.GetLastStateDown(handType) && objectInHand)
                {
                    Debug.Log("Released!");
                    grabber.ReleaseObject(controllerPose);
                    shooter.Shoot(objectInHand);
                    objectInHand = null;
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
    }
}
