using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerGrabScript : MonoBehaviour
{
    private GameObject collidingObject;
    private GameObject objectInHand;
    public AudioSource grabAudio;
    private string grabbableTag = "Grabbable";

    // Start is called before the first frame update
    void Start()
    {

    }

    public GameObject GrabObject()
    {
   //     grabAudio.Play();

        objectInHand = collidingObject;
        collidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

        return objectInHand;
    }

    public GameObject GrabExtinguisher(Quaternion handRotation)
    {
        collidingObject.transform.rotation = handRotation;
        return GrabObject();
    }

    public void ReleaseObject(SteamVR_Behaviour_Pose controllerPose)
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
        }
        objectInHand = null;
    }

    public bool IsExtinguisher()
    {
        return IsCollidingObject() && collidingObject.GetComponent<Extinguisher>() != null;
    }

    public bool IsCollidingObject()
    {
        return collidingObject != null;
    }

    public GameObject GetCollidingObject()
    {
        return collidingObject;
    }

    public bool IsGrabbing()
    {
        return objectInHand != null;
    }
    
    void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }

        collidingObject = col.gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == grabbableTag)
        {
            SetCollidingObject(other);
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.tag == grabbableTag)
        {
            SetCollidingObject(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }
}
