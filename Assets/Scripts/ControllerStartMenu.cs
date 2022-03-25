using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerStartMenu : MonoBehaviour
{
    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTransform;

    public LayerMask UIMask;
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
        
    }

    public void TryLaser(SteamVR_Behaviour_Pose controllerPose)
    {
        RaycastHit hit;

        if (Physics.Raycast(controllerPose.transform.position, transform.forward, out hit, 100, UIMask))
        {
            if(hit.transform.gameObject.layer == UIMask) {
                hitPoint = hit.point;
                ShowLaser(hit, controllerPose);
            }
        }
    }

    public void DisableLaser()
    {
        laser.SetActive(false);
    }

    private void ShowLaser(RaycastHit hit, SteamVR_Behaviour_Pose controllerPose)
    {
        Debug.Log("Hitting the UI!");
        laser.SetActive(true);
        // shouldTeleport = true;
        // laserTransform.position = Vector3.Lerp(controllerPose.transform.position, hitPoint, .5f);
        // laserTransform.LookAt(hitPoint);
        // laserTransform.localScale = new Vector3(laserTransform.localScale.x,
        //                                         laserTransform.localScale.y,
        //                                         hit.distance);
    }
}
