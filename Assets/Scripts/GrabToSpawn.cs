using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabToSpawn : MonoBehaviour
{
    public SteamVR_Action_Boolean grabAction;
    public GameObject objToSpawn;

    void OnColliderStay(Collider collider)
    {
        if (collider.tag == "Hand" && (grabAction.GetLastStateDown(SteamVR_Input_Sources.LeftHand) || grabAction.GetLastStateDown(SteamVR_Input_Sources.RightHand)))
        {
            Spawn(collider.transform.position);
            ControllerGrabScript grabber = collider.GetComponent<ControllerGrabScript>();
            if (grabber)
                grabber.GrabObject();
        }
    }

    void Spawn(Vector3 position)
    {
        Instantiate(objToSpawn, position, Quaternion.identity);
    }
}
