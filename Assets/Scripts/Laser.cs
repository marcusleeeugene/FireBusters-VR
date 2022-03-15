using Valve.VR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    //public SteamVR_Action_Boolean action;

    public GameObject laserPrefab; 
    private GameObject laser;
    private Transform laserTransform; 
    private Vector3 hitPoint; 

    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(laserPrefab);
        laserTransform = laser.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // if (action.GetState(handType))
        // {
            
        // }
        // else 
        // {
        //     laser.SetActive(false);
        // }
        
        RaycastHit hit;

        if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100))
        {
            hitPoint = hit.point;
            Global.laserInFocus = hit.transform.gameObject;
            ShowLaser(hit);
        } else {
            laser.SetActive(false);
        }
    }

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        laserTransform.LookAt(hitPoint);
        laserTransform.localScale = new Vector3(laserTransform.localScale.x,
                                                laserTransform.localScale.y,
                                                hit.distance);
    }
}
