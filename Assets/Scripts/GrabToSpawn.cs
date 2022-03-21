using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GrabToSpawn : MonoBehaviour
{
    public SteamVR_Action_Boolean grabAction;
    public GameObject objToSpawn;
    public bool spawnOnHand = true;
    [Tooltip("Required if spawnOnHand is false.")]
    public Transform placeToSpawn;

    void OnColliderStay(Collider collider)
    {
        if (collider.tag == "Hand" && (grabAction.GetLastStateDown(SteamVR_Input_Sources.LeftHand) || grabAction.GetLastStateDown(SteamVR_Input_Sources.RightHand)))
        {
            if (spawnOnHand) {
                Spawn(collider.transform.position, Quaternion.identity);
                ControllerGrabScript grabber = collider.GetComponent<ControllerGrabScript>();
                if (grabber)
                    grabber.GrabObject();
            } else if (placeToSpawn) {
                Spawn(placeToSpawn.position, placeToSpawn.rotation);
            }
        }
    }

    void Spawn(Vector3 position, Quaternion rotation)
    {
        Instantiate(objToSpawn, position, rotation);
    }
}
